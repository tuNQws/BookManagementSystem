using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagement.DTO
{
    class Employee
    {
        private int iD;
        private string emp_first_name;
        private string emp_last_name;
        private string account_id;

        //public Employee(int iD, string emp_name, string account_id)
        //{
        //    ID = iD;
        //    Emp_first_name = emp_name;
        //    Account_id = account_id;
        //}

        public Employee(DataRow row)
        {
            ID = (int)row["id"];
            Emp_first_name = (string)row["emp_first_name"];
            Emp_last_name = (string)row["emp_last_name"];
            Account_id = (string)row["account_id"];
        }

        public int ID { get => iD; set => iD = value; }
        public string Account_id { get => account_id; set => account_id = value; }
        public string Emp_first_name { get => emp_first_name; set => emp_first_name = value; }
        public string Emp_last_name { get => emp_last_name; set => emp_last_name = value; }
    }
}
