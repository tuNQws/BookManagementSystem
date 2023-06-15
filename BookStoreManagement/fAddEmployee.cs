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
    public partial class fAddEmployee : Form
    {
        public fAddEmployee()
        {
            InitializeComponent();
        }

        private void btnSearchBook_Click(object sender, EventArgs e)
        {
            string firstName = txbEmployeeFirstName.Text;
            string lastName = txbEmployeeLastName.Text;
            string username = txbEmployeeUsername.Text;
            string password = txbPassword.Text;
            string email = txbEmail.Text;

            if (AccountDAO.Instance.InsertAccount(username, password, email)
                && EmployeeDAO.Instance.InsertEmployee(firstName, lastName, username))
            {
                MessageBox.Show("Thêm nhân viên và tài khoản thành công");

                if (insertEmployee != null)
                    insertEmployee(this, new EventArgs());

                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm nhân viên");
            }
        }

        private event EventHandler insertEmployee;
        public event EventHandler InsertEmployee
        {
            add { insertEmployee += value; }
            remove { insertEmployee -= value; }
        }
    }
}
