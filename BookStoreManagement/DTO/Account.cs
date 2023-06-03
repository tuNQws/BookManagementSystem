using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagement.DTO
{
    class Account
    {
        private string username;
        private string password;
        private string email;
        private string status;
        private int isManager;

        public Account(string username, string password, string email, string status, int isManager)
        {
            Username = username;
            Password = password;
            Email = email;
            Status = status;
            IsManager = isManager;
        }

        public Account(DataRow row)
        {
            Username = (string)row["username"];
            Password = (string)row["password"];
            Email = (string)row["email"];
            Status = (string)row["status"];
            IsManager = (int)row["isManager"];
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public int IsManager { get => isManager; set => isManager = value; }
        public string Status { get => status; set => status = value; }
    }
}
