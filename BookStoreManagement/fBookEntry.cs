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
    public partial class fBookEntry : Form
    {
        BindingSource bookList = new BindingSource();

        BindingSource bookEntryDetailList = new BindingSource();

        private int bookEntryId;

        private int empId;

        private int totalAmount;

        private int supplierId;

        public int EmpId { get => empId; set => empId = value; }
        public int TotalAmount { get => totalAmount; set => totalAmount = value; }
        public int BookEntryId { get => bookEntryId; set => bookEntryId = value; }
        public int SupplierId { get => supplierId; set => supplierId = value; }

        public fBookEntry()
        {
            InitializeComponent();

            LoadData();
        }

        public fBookEntry(int bookEntryId, int empId, int supplierId)
        {
            InitializeComponent();

            BookEntryId = bookEntryId;

            EmpId = empId;

            SupplierId = supplierId;

            LoadData();
        }

        void LoadData()
        {
            TotalAmount = 0;
            dtgvBook.DataSource = bookList;
            dtgvBookEntryDetail.DataSource = bookEntryDetailList;
            txbIdBookEntry.Text = bookEntryId.ToString();
            txbEmployeeName.Text = EmployeeDAO.Instance.GetEmployeeNameWithBookEntryId(BookEntryId);
            dtpkInvoiceDate.Value = DateTime.Now;
            txbTotalAmount.Text = TotalAmount.ToString();
            txbSupplier.Text = SupplierDAO.Instance.GetSupplierNameWithBookEntryId(BookEntryId);

            LoadListBook();
            AddBookBinding();

            LoadListBookEntryDetail();
            AddBookEntryDetailBinding();
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

        void AddBookEntryDetailBinding()
        {
            txbBookIdDelete.DataBindings.Add(new Binding("Text", dtgvBookEntryDetail.DataSource, "book_id", true, DataSourceUpdateMode.Never));
            txbQuantity.DataBindings.Add(new Binding("Text", dtgvBookEntryDetail.DataSource, "quantity", true, DataSourceUpdateMode.Never));
        }

        void LoadListBookEntryDetail()
        {
            bookEntryDetailList.DataSource = BookEntryDetailDAO.Instance.GetBookEntryDetailsByBookEntryId(BookEntryId);
        }

        private void btnSearchBook_Click(object sender, EventArgs e)
        {
            bookList.DataSource = SearchBookByName(txbSearchBook.Text);
        }

        private void btnAddToBookEntry_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbIdBook.Text);
            int price = Convert.ToInt32(txbPrice.Text);
            int quantity = (int)nudNumber.Value;

            if (BookEntryDetailDAO.Instance.InsertBookEntryDetail(id, BookEntryId, quantity, price))
            {
                LoadListBookEntryDetail();
                TotalAmount += price * quantity;
                txbTotalAmount.Text = TotalAmount.ToString();
                if (insertBookEntryDetail != null)
                    insertBookEntryDetail(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm sách vào đơn nhập");
            }
        }

        private void btnDeleteFromBookEntry_Click(object sender, EventArgs e)
        {
            if (txbBookIdDelete.Text != "")
            {
                int book_id = Convert.ToInt32(txbBookIdDelete.Text);
                int book_entry_id = Convert.ToInt32(txbIdBookEntry.Text);
                int quantity = Convert.ToInt32(txbQuantity.Text);
                BookEntryDetail book_entry_detail = BookEntryDetailDAO.Instance.GetBookEntryDetail(book_entry_id, book_id);
                TotalAmount -= book_entry_detail.Unit_price * book_entry_detail.Quantity;
                BookEntryDetailDAO.Instance.DeleteBookEntryDetail(book_entry_id, book_id);
                txbTotalAmount.Text = TotalAmount.ToString();
                LoadListBookEntryDetail();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa sách khỏi đơn nhập");
            }
        }

        private event EventHandler insertBookEntryDetail;
        public event EventHandler InsertBookEntryDetail
        {
            add { insertBookEntryDetail += value; }
            remove { insertBookEntryDetail -= value; }
        }

        private void btnPayCheck_Click_1(object sender, EventArgs e)
        {
            if (BookEntryDAO.Instance.UpdateBookEntryCheck(BookEntryId, TotalAmount))
            {
                List<BookEntryDetail> list = BookEntryDetailDAO.Instance.GetBookEntryDetailsByBookEntryId(BookEntryId);
                bool success = true;
                foreach (BookEntryDetail i in list)
                {
                    if (!BookDAO.Instance.IncreaseStockByBookId(i.Book_id, i.Quantity))
                    {
                        success = false;
                    }
                }
                if (success)
                {
                    MessageBox.Show("Nhập sách thành công!");
                    this.Hide();
                    return;
                }
            }
            MessageBox.Show("Có lỗi khi xác nhận nhập!");
        }
    }
}
