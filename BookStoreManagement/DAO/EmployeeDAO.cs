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

        public bool InsertEmployee(string emp_name, string account_id)
        {
            string query = string.Format("INSERT Supplier ( emp_name, account_id ) VALUES  ( N'{0}', N'{1}' )",
                emp_name, account_id);
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

        public bool UpdateEmployee(int id, string emp_name)
        {
            string query = string.Format("UPDATE Supplier SET emp_name = N'{0}' WHERE id = {1}",
                emp_name, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
