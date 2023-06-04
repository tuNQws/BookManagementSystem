using BookStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagement.DAO
{
    class EmployeeDAO
    {
        private static EmployeeDAO instance;

        public static EmployeeDAO Instance
        {
            get { if (instance == null) instance = new EmployeeDAO(); return EmployeeDAO.instance; }
            private set { EmployeeDAO.instance = value; }
        }

        private EmployeeDAO() { }

        public List<Employee> GetListEmployees()
        {
            List<Employee> list = new List<Employee>();

            string query = "select * from employee";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Employee employee = new Employee(item);
                list.Add(employee);
            }

            return list;
        }

        public List<Employee> SearchEmployeeByName(string name)
        {

            List<Employee> list = new List<Employee>();

            string query = string.Format("SELECT * FROM Employee WHERE dbo.fuConvertToUnsign1(emp_last_name) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Employee food = new Employee(item);
                list.Add(food);
            }

            return list;
        }

        public bool InsertEmployee(string emp_first_name, string emp_last_name, string account_id)
        {
            string query = string.Format("INSERT Employee (emp_first_name, emp_last_name, account_id) VALUES  ( N'{0}', N'{1}', N'{2}')",
                emp_first_name, emp_last_name, account_id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public int GetEmployeeIdWithUsername(string username)
        {
            string query = string.Format("select * from employee where account_id = N'{0}'", username);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Employee employee = new Employee(item);
                return employee.ID;
            }
            return -1;
        }

        public string GetEmployeeNameWithInvoiceId(int invoice_id)
        {
            string query = string.Format("select * from employee as e, invoice as i where e.id = i.emp_id AND i.id = {0}", invoice_id);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                return (string)item["emp_first_name"] + " " + (string)item["emp_last_name"];
            }
            return "";
        }

        public string GetEmployeeNameWithBookEntryId(int book_entry_id)
        {
            string query = string.Format("select * from employee as e, book_entry as b where e.id = b.emp_id AND b.id = {0}", book_entry_id);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                return (string)item["emp_first_name"] + " " + (string)item["emp_last_name"];
            }
            return "";
        } 

        //public bool UpdateEmployee(int id, string emp_name)
        //{
        //    string query = string.Format("UPDATE Supplier SET emp_name = N'{0}' WHERE id = {1}",
        //        emp_name, id);
        //    int result = DataProvider.Instance.ExecuteNonQuery(query);

        //    return result > 0;
        //}

        public bool DeleteEmployeeByUsername(string name)
        {
            string query = string.Format("Delete Employee where account_id = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
