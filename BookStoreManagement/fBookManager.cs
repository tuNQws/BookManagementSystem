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

        BindingSource invoiceList = new BindingSource();

        BindingSource bookEntryList = new BindingSource();

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
            dtgvInvoice.DataSource = invoiceList;
            dtgvBookEntry.DataSource = bookEntryList;

            LoadDateTimePickerInvoice();
            LoadListInvoiceByDate(dtpkFromDate.Value, dtpkToDate.Value);
            AddInvoiceBinding();

            LoadDateTimePickerBookEntry();
            LoadListBookEntryByDate(dtpkFromDateBookEntry.Value, dtpkToDateBookEntry.Value);
            AddBookEntryBinding();

            LoadListBook();
            AddBookBinding();

            LoadListSupplier();
            AddSupplierBinding();
            LoadListComboBoxSupplier();
        }

        void LoadListComboBoxSupplier()
        {
            List<Supplier> list = SupplierDAO.Instance.GetListSuppliers();
            cbSupplier.DataSource = list;
            cbSupplier.DisplayMember = "Sup_name";
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
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, today.Day);
            dtpkToDate.Value = dtpkFromDate.Value;
        }

        void LoadListInvoiceByDate(DateTime fromDate, DateTime toDate)
        {
            invoiceList.DataSource = InvoiceDAO.Instance.GetInvoiceListByDate(fromDate, toDate);
        }

        void AddInvoiceBinding()
        {
            txbIdInvoice.DataBindings.Add(new Binding("Text", dtgvInvoice.DataSource, "id", true, DataSourceUpdateMode.Never));
        }

        void LoadInvoiceDetailsByInvoiceId(int invoiceId)
        {
            dtgvInvoiceDetail.DataSource = InvoiceDetailDAO.Instance.GetInvoiceDetailsByInvoiceId(invoiceId);
        }


        #endregion

        void LoadDateTimePickerBookEntry()
        {
            DateTime today = DateTime.Now;  
            dtpkFromDateBookEntry.Value = new DateTime(today.Year, today.Month, today.Day);
            dtpkToDateBookEntry.Value = dtpkFromDateBookEntry.Value;
        }

        void LoadListBookEntryByDate(DateTime fromDate, DateTime toDate)
        {
            bookEntryList.DataSource = BookEntryDAO.Instance.GetBookEntryListByDate(fromDate, toDate);
        }

        void AddBookEntryBinding()
        {
            txbIdBookEntry.DataBindings.Add(new Binding("Text", dtgvBookEntry.DataSource, "id", true, DataSourceUpdateMode.Never));
        }

        void LoadBookEntryDetailsByBookEntryId(int bookEntryId)
        {
            dtgvBookEntryDetail.DataSource = BookEntryDetailDAO.Instance.GetBookEntryDetailsByBookEntryId(bookEntryId);
        }
        
        #region supplier

        void LoadListSupplier()
        {
            dtgvSupplier.DataSource = SupplierDAO.Instance.GetListSuppliers();
        }

        void AddSupplierBinding()
        {
            txbIdSupplier.DataBindings.Add(new Binding("Text", dtgvSupplier.DataSource, "id", true, DataSourceUpdateMode.Never));
            txbSupplierName.DataBindings.Add(new Binding("Text", dtgvSupplier.DataSource, "sup_name", true, DataSourceUpdateMode.Never));
            txbSupplierAddress.DataBindings.Add(new Binding("Text", dtgvSupplier.DataSource, "sup_address", true, DataSourceUpdateMode.Never));
            txbSupplierEmail.DataBindings.Add(new Binding("Text", dtgvSupplier.DataSource, "sup_email", true, DataSourceUpdateMode.Never));
            txbSupplierNumber.DataBindings.Add(new Binding("Text", dtgvSupplier.DataSource, "sup_phone", true, DataSourceUpdateMode.Never));
            txbBank.DataBindings.Add(new Binding("Text", dtgvSupplier.DataSource, "sup_bank", true, DataSourceUpdateMode.Never));
            txbTax.DataBindings.Add(new Binding("Text", dtgvSupplier.DataSource, "sup_tax_code", true, DataSourceUpdateMode.Never));
        }

        List<Supplier> SearchSupplierByName(string name)
        {
            List<Supplier> list = SupplierDAO.Instance.SearchSupplierByName(name);

            return list;
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

        private event EventHandler insertSupplier;
        public event EventHandler InsertSupplier
        {
            add { insertSupplier += value; }
            remove { insertSupplier -= value; }
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
            int emp_id = EmployeeDAO.Instance.GetEmployeeIdWithUsername(loginAccount.Username);
            int invoiceId = InvoiceDAO.Instance.InsertAndGetUncheckedInvoiceId(DateTime.Now, 0, "unchecked", emp_id);
            fCashier f = new fCashier(invoiceId, emp_id);
            f.Show();
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            string name = txbSupplierName.Text;
            string address = txbSupplierAddress.Text;
            string email = txbSupplierEmail.Text;
            string phone = txbSupplierNumber.Text;
            string bank = txbBank.Text;
            string tax_code = txbTax.Text;

            if (SupplierDAO.Instance.InsertSupplier(name, address, email, phone, bank, tax_code))
            {
                MessageBox.Show("Thêm nhà cung cấp thành công");
                LoadListSupplier();
                LoadListComboBoxSupplier();
                if (insertSupplier != null)
                    insertSupplier(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm nhà cung cấp");
            }
        }

        private void btnAllSupplier_Click(object sender, EventArgs e)
        {
            LoadListSupplier();
        }

        private void btnUpdateSupplier_Click(object sender, EventArgs e)
        {
            string name = txbSupplierName.Text;
            string address = txbSupplierAddress.Text;
            string email = txbSupplierEmail.Text;
            string phone = txbSupplierNumber.Text;
            string bank = txbBank.Text;
            string tax_code = txbTax.Text;
            int id = Convert.ToInt32(txbIdSupplier.Text);

            if (SupplierDAO.Instance.UpdateSupplier(id, name, address, email, phone, bank, tax_code))
            {
                MessageBox.Show("Sửa thông tin nhà cung cấp thành công");
                LoadListBook();
                if (updateBook != null)
                    updateBook(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa thông tin nhà cung cấp");
            }
        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchSupplier_Click(object sender, EventArgs e)
        {
            dtgvSupplier.DataSource = SearchSupplierByName(txbSearchSupplier.Text);
        }

        private void chứcNăngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
        }

        private void btnEntryBook_Click(object sender, EventArgs e)
        {
            if (cbSupplier.SelectedItem != null)
            {
                int emp_id = EmployeeDAO.Instance.GetEmployeeIdWithUsername(loginAccount.Username);
                int supplierId = (cbSupplier.SelectedItem as Supplier).ID;
                int bookEntryId = BookEntryDAO.Instance.InsertAndGetUncheckedBookEntryId(DateTime.Now, 0, "unchecked", emp_id, supplierId);
                fBookEntry f = new fBookEntry(bookEntryId, emp_id, supplierId);
                f.Show();
            }
            else
            {
                MessageBox.Show("Phải chọn nhà cung cấp trước");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int invoiceId = Convert.ToInt32(txbIdInvoice.Text);
            LoadInvoiceDetailsByInvoiceId(invoiceId);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int bookEntryId = Convert.ToInt32(txbIdBookEntry.Text);
            LoadBookEntryDetailsByBookEntryId(bookEntryId);
        }
    }
}
