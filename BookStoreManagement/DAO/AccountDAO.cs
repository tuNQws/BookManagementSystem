using BookStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagement.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {
            string query = string.Format("SELECT * FROM Account WHERE username = N'{0}' AND password = N'{1}'", userName, passWord);

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }


        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT * FROM Account");
        }

        public Account GetAccountByUsername(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from account where userName = N'" + userName + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }

        public bool InsertAccount(string name, string password, string email, string status, int isManager)
        {
            string query = string.Format("INSERT Account VALUES  ( N'{0}', N'{1}', {2}, N'{3}', {4})", name, password, email, status, isManager);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //public bool DeleteAccount(string name)
        //{
        //    string query = string.Format("Delete Account where UserName = N'{0}'", name);
        //    int result = DataProvider.Instance.ExecuteNonQuery(query);

        //    return result > 0;
        //}

        //public bool ResetPassword(string name)
        //{
        //    string query = string.Format("update account set password = N'1962026656160185351301320480154111117132155' where UserName = N'{0}'", name);
        //    int result = DataProvider.Instance.ExecuteNonQuery(query);

        //    return result > 0;
        //}
    }
}
