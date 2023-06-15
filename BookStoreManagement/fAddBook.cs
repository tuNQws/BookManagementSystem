using BookStoreManagement.DAO;
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
    public partial class fAddBook : Form
    {
        public fAddBook()
        {
            InitializeComponent();
        }

        private void btnSearchBook_Click(object sender, EventArgs e)
        {
            string title = txbTitle.Text;
            string author = txbAuthorBook.Text;
            string publisher = txbPublisher.Text;
            int publish_year = (int)nudYear.Value;
            int stock = (int)nudStock.Value;
            string category = txbCategory.Text;
            int price = (int)nudPriceBook.Value;

            if (BookDAO.Instance.InsertBook(title, author, publisher, publish_year, stock, category, price))
            {
                MessageBox.Show("Thêm sách thành công");
                //LoadListBook();
                if (insertBook != null)
                    insertBook(this, new EventArgs());
                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm sách");
            }
        }

        private event EventHandler insertBook;
        public event EventHandler InsertBook
        {
            add { insertBook += value; }
            remove { insertBook -= value; }
        }
    }
}
