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
using System.Xml.Linq;

namespace BookStoreManagement
{
    partial class fBookManager : Form
    {
        BindingSource bookList = new BindingSource();

        BindingSource foodList = new BindingSource();

        private Account loginAccount;
        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; }
        }
        public fBookManager()
        {
            InitializeComponent();
            LoadData();
        }

        public fBookManager(Account acc)
        {
            InitializeComponent();

            this.LoginAccount = acc;

            LoadData();
        }

        #region methods

        void LoadData()
        {
            dtgvBook.DataSource = bookList;

            LoadDateTimePickerInvoice();
            LoadListInvoiceByDate(dtpkFromDate.Value, dtpkToDate.Value);

            LoadListBook();
            AddBookBinding();
        }

        #region book
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
            txbAuthorBook.DataBindings.Add(new Binding("Text", dtgvBook.DataSource, "author", true, DataSourceUpdateMode.Never));
            txbPublisher.DataBindings.Add(new Binding("Text", dtgvBook.DataSource, "publisher", true, DataSourceUpdateMode.Never));
            nudYear.DataBindings.Add(new Binding("Value", dtgvBook.DataSource, "publish_year", true, DataSourceUpdateMode.Never));
            nudStock.DataBindings.Add(new Binding("Value", dtgvBook.DataSource, "stock", true, DataSourceUpdateMode.Never));
            txbCategory.DataBindings.Add(new Binding("Text", dtgvBook.DataSource, "category", true, DataSourceUpdateMode.Never));
            nudPriceBook.DataBindings.Add(new Binding("Value", dtgvBook.DataSource, "price", true, DataSourceUpdateMode.Never));
        }
        #endregion

        #region invoice

        void LoadDateTimePickerInvoice()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }

        void LoadListInvoiceByDate(DateTime fromDate, DateTime toDate)
        {
            dtgvInvoice.DataSource = InvoiceDAO.Instance.GetInvoiceListByDate(fromDate, toDate);
        }


        #endregion

        #endregion

        #region events

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            string title = txbTitle.Text;
            string author = txbAuthorBook.Text;
            string publisher = txbPublisher.Text;
            int publish_year = (int) nudYear.Value;
            int stock = (int) nudStock.Value;
            string category = txbCategory.Text;
            int price = (int)nudPriceBook.Value;

            if (BookDAO.Instance.InsertBook(title, author, publisher, publish_year, stock, category, price))
            {
                MessageBox.Show("Thêm sách thành công");
                LoadListBook();
                if (insertBook != null)
                    insertBook(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm sách");
            }
            
        }

        private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            string title = txbTitle.Text;
            string author = txbAuthorBook.Text;
            string publisher = txbPublisher.Text;
            int publish_year = (int)nudYear.Value;
            int stock = (int)nudStock.Value;
            string category = txbCategory.Text;
            int price = (int)nudPriceBook.Value;
            int id = Convert.ToInt32(txbIdBook.Text);

            if (BookDAO.Instance.UpdateBook(id, title, author, publisher, publish_year, stock, category, price))
            {
                MessageBox.Show("Sửa thông tin sách thành công");
                LoadListBook();
                if (updateBook != null)
                    updateBook(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thông tin sách");
            }
        }

        private event EventHandler insertBook;
        public event EventHandler InsertBook
        {
            add { insertBook += value; }
            remove { insertBook -= value; }
        }

        private event EventHandler updateBook;
        public event EventHandler UpdateBook
        {
            add { updateBook += value; }
            remove { updateBook -= value; }
        }


        #endregion

        private void btnSearchBook_Click(object sender, EventArgs e)
        {
            bookList.DataSource = SearchBookByName(txbSearchBook.Text);
        }

        private void btnGetAllBook_Click(object sender, EventArgs e)
        {
            LoadListBook();
        }

        private void btnViewInvoice_Click(object sender, EventArgs e)
        {
            LoadListInvoiceByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }

        private void btnPayCheck_Click(object sender, EventArgs e)
        {
            int invoiceId = InvoiceDAO.Instance.InsertAndGetUncheckedInvoiceId(DateTime.Now, 0, "unchecked", EmployeeDAO.Instance.GetEmployeeIdWithUsername(loginAccount.Username));
            fCashier f = new fCashier(invoiceId);
            f.Show();
        }
    }
}
