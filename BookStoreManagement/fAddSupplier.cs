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
    public partial class fAddSupplier : Form
    {
        public fAddSupplier()
        {
            InitializeComponent();
        }

        private void fAddSupplier_Load(object sender, EventArgs e)
        {

        }

        private void btnSearchSupplier_Click(object sender, EventArgs e)
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
                
                if (insertSupplier != null)
                    insertSupplier(this, new EventArgs());

                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm nhà cung cấp");
            }
        }

        private event EventHandler insertSupplier;
        public event EventHandler InsertSupplier
        {
            add { insertSupplier += value; }
            remove { insertSupplier -= value; }
        }
    }
}
