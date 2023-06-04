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
        public List<Account> SearchAccountByUsername(string name)
        {

            List<Account> list = new List<Account>();

            string query = string.Format("SELECT * FROM Account WHERE dbo.fuConvertToUnsign1(username) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Account food = new Account(item);
                list.Add(food);
            }

            return list;
        }
        

        public bool InsertAccount(string name, string password, string email)
        {
            string query = string.Format("INSERT Account (username, password, email) VALUES  ( N'{0}', N'{1}', N'{2}')", name, password, email);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteAccount(string name)
        {
            string query = string.Format("Delete Account where username = N'{0}'", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //public bool ResetPassword(string name)
        //{
        //    string query = string.Format("update account set password = N'1962026656160185351301320480154111117132155' where UserName = N'{0}'", name);
        //    int result = DataProvider.Instance.ExecuteNonQuery(query);

        //    return result > 0;
        //}
    }
}
