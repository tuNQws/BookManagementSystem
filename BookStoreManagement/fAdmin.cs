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
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
            LoadData();
        }

        #region methods

        void LoadData()
        {
            LoadListEmployee();
            AddEmployeeBinding();

            LoadListAccount();
        }

        void LoadListEmployee()
        {
            dtgvEmployee.DataSource = EmployeeDAO.Instance.GetListEmployees();
        }

        void AddEmployeeBinding()
        {
            txbIdEmployee.DataBindings.Add(new Binding("Text", dtgvEmployee.DataSource, "id", true, DataSourceUpdateMode.Never));
            txbEmployeeFirstName.DataBindings.Add(new Binding("Text", dtgvEmployee.DataSource, "emp_first_name", true, DataSourceUpdateMode.Never));
            txbEmployeeLastName.DataBindings.Add(new Binding("Text", dtgvEmployee.DataSource, "emp_last_name", true, DataSourceUpdateMode.Never));
            txbEmployeeUsername.DataBindings.Add(new Binding("Text", dtgvEmployee.DataSource, "account_id", true, DataSourceUpdateMode.Never));
        }

        List<Employee> SearchEmployeeByName(string name)
        {
            List<Employee> list = EmployeeDAO.Instance.SearchEmployeeByName(name);

            return list;
        }

        void LoadListAccount()
        {
            dtgvAccount.DataSource = AccountDAO.Instance.GetListAccount();
        }

        List<Account> SearchAccountByUsername(string name)
        {
            List<Account> list = AccountDAO.Instance.SearchAccountByUsername(name);

            return list;
        }

        #endregion

        #region events

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            fAddEmployee f = new fAddEmployee();
            this.Hide();
            f.ShowDialog();
            this.Show();
            LoadListEmployee();
            LoadListAccount();
        }

        private void btnGetAllEmployee_Click(object sender, EventArgs e)
        {
            LoadListEmployee();
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            string username = txbEmployeeUsername.Text;
            if (EmployeeDAO.Instance.DeleteEmployeeByUsername(username)
                && AccountDAO.Instance.DeleteAccount(username))
            {
                MessageBox.Show("Xóa nhân viên và tài khoản thành công");
                LoadListEmployee();
                LoadListAccount();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa nhân viên");
            }
        }

        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            dtgvEmployee.DataSource = SearchEmployeeByName(txbSearchEmployee.Text);
        }

        #endregion

        

        private void btnSearchAccount_Click(object sender, EventArgs e)
        {
            dtgvAccount.DataSource = SearchAccountByUsername(txbSearchAccount.Text);
        }

        private void btnBanAccount_Click(object sender, EventArgs e)
        {

        }
    }
}
