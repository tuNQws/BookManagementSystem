using BookStoreManagement.DAO;
using BookStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public int InvoiceId { get => invoiceId; set => invoiceId = value; }

        public fCashier()
        {
            InitializeComponent();

            LoadData();
        }

        public fCashier(int invoiceId)
        {
            InitializeComponent();

            InvoiceId = invoiceId;

            LoadData();
        }

        void LoadData()
        {
            dtgvBook.DataSource = bookList;
            dtgvInvoiceDetail.DataSource = invoiceDetailList;
            txbIdInvoice.Text = InvoiceId.ToString();

            LoadListBook();
            AddBookBinding();

            LoadListInvoiceDetail();
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

            if (InvoiceDetailDAO.Instance.InsertInvoiceDetail(InvoiceId, id, quantity, price))
            {
                LoadListInvoiceDetail();
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

        }

        private event EventHandler insertInvoiceDetail;
        public event EventHandler InsertInvoiceDetail
        {
            add { insertInvoiceDetail += value; }
            remove { insertInvoiceDetail -= value; }
        }
    }
}
