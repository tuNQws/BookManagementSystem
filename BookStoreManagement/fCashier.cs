using BookStoreManagement.DAO;
using BookStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStoreManagement
{
    partial class fCashier : Form
    {
        BindingSource bookList = new BindingSource();

        BindingSource invoiceDetailList = new BindingSource();

        private int invoiceId;

        private int empId;

        private int totalAmount;

        public int InvoiceId { get => invoiceId; set => invoiceId = value; }
        public int EmpId { get => empId; set => empId = value; }
        public int TotalAmount { get => totalAmount; set => totalAmount = value; }

        public fCashier()
        {
            InitializeComponent();

            LoadData();
        }

        public fCashier(int invoiceId, int empId)
        {
            InitializeComponent();

            InvoiceId = invoiceId;

            EmpId = empId;

            LoadData();
        }

        void LoadData()
        {
            TotalAmount = 0;
            dtgvBook.DataSource = bookList;
            dtgvInvoiceDetail.DataSource = invoiceDetailList;
            txbIdInvoice.Text = InvoiceId.ToString();
            txbEmployeeName.Text = EmployeeDAO.Instance.GetEmployeeNameWithInvoiceId(InvoiceId);
            dtpkInvoiceDate.Value = DateTime.Now;
            txbTotalAmount.Text = TotalAmount.ToString();

            LoadListBook();
            AddBookBinding();

            LoadListInvoiceDetail();
            AddInvoiceDetailBinding();
        }

        void LoadListBook()
        {
            bookList.DataSource = BookDAO.Instance.GetListBooks();
        }

        List<Book> SearchBookByName(string name)
        {
            List<Book> list = BookDAO.Instance.SearchBookByName(name);

            return list;
        }

        void AddBookBinding()
        {
            txbIdBook.DataBindings.Add(new Binding("Text", dtgvBook.DataSource, "id", true, DataSourceUpdateMode.Never));
            txbTitle.DataBindings.Add(new Binding("Text", dtgvBook.DataSource, "title", true, DataSourceUpdateMode.Never));
            txbPrice.DataBindings.Add(new Binding("Text", dtgvBook.DataSource, "price", true, DataSourceUpdateMode.Never));
        }

        void AddInvoiceDetailBinding()
        {
            txbBookIdDelete.DataBindings.Add(new Binding("Text", dtgvInvoiceDetail.DataSource, "book_id", true, DataSourceUpdateMode.Never));
            txbQuantity.DataBindings.Add(new Binding("Text", dtgvInvoiceDetail.DataSource, "quantity", true, DataSourceUpdateMode.Never));
        }

        void LoadListInvoiceDetail()
        {
            invoiceDetailList.DataSource = InvoiceDetailDAO.Instance.GetInvoiceDetailsByInvoiceId(InvoiceId);
            
        }


        private void btnSearchBook_Click(object sender, EventArgs e)
        {
            bookList.DataSource = SearchBookByName(txbSearchBook.Text);
        }

        private void btnAddToInvoice_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbIdBook.Text);
            int price = Convert.ToInt32(txbPrice.Text);
            int quantity = (int)nudNumber.Value;

            if (InvoiceDetailDAO.Instance.InsertInvoiceDetail(InvoiceId, id, quantity, price)
                && BookDAO.Instance.CheckStockByBookId(id, quantity))
            {
                LoadListInvoiceDetail();
                TotalAmount += price * quantity;
                txbTotalAmount.Text = TotalAmount.ToString();
                if (insertInvoiceDetail != null)
                    insertInvoiceDetail(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm sách vào hóa đơn");
            }
        }

        private void btnDeleteFromInvoice_Click(object sender, EventArgs e)
        {
            if (txbBookIdDelete.Text != "") {
                int book_id = Convert.ToInt32(txbBookIdDelete.Text);
                int invoice_id = Convert.ToInt32(txbIdInvoice.Text);
                int quantity = Convert.ToInt32(txbQuantity.Text);
                InvoiceDetail invoice_detail = InvoiceDetailDAO.Instance.GetInvoiceDetail(invoice_id, book_id);
                TotalAmount -= invoice_detail.Unit_price * invoice_detail.Quantity;
                InvoiceDetailDAO.Instance.DeleteInvoiceDetail(invoice_id, book_id);
                txbTotalAmount.Text = TotalAmount.ToString();
                LoadListInvoiceDetail();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa sách khỏi hóa đơn");
            }            
        }

        private event EventHandler insertInvoiceDetail;
        public event EventHandler InsertInvoiceDetail
        {
            add { insertInvoiceDetail += value; }
            remove { insertInvoiceDetail -= value; }
        }

        private void btnPayCheck_Click(object sender, EventArgs e)
        {
            if (InvoiceDAO.Instance.UpdateInvoiceCheck(InvoiceId, TotalAmount))
            {
                List<InvoiceDetail> list = InvoiceDetailDAO.Instance.GetInvoiceDetailsByInvoiceId(InvoiceId);
                bool success = true;
                foreach (InvoiceDetail i in list)
                {
                    if (!BookDAO.Instance.DecreaseStockByBookId(i.Book_id, i.Quantity))
                    {
                        success = false;
                    }
                }
                if (success)
                {
                    MessageBox.Show("Thanh toán thành công!");
                    this.Hide();
                    return;
                }
            }
            MessageBox.Show("Có lỗi khi thanh toán!");
        }
    }
}
