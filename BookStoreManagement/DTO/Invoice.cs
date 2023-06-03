using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagement.DTO
{
    class Invoice
    {
        private int iD;
        private DateTime date_invoice;
        private int amount_invoice;
        private string status;
        private int emp_id;

        public Invoice(int iD, DateTime date_invoice, int amount_invoice, string status, int emp_id)
        {
            ID = iD;
            Date_invoice = date_invoice;
            Amount_invoice = amount_invoice;
            Status = status;
            Emp_id = emp_id;
        }

        public Invoice(DataRow row)
        {
            ID = (int)row["id"];
            Date_invoice = (DateTime)row["date_invoice"];
            Amount_invoice = (int)row["amount_invoice"];
            Status = (string)row["status"];
            Emp_id = (int)row["emp_id"];
        }

        public int ID { get => iD; set => iD = value; }
        public DateTime Date_invoice { get => date_invoice; set => date_invoice = value; }
        public int Amount_invoice { get => amount_invoice; set => amount_invoice = value; }
        public int Emp_id { get => emp_id; set => emp_id = value; }
        public string Status { get => status; set => status = value; }
    }
}
