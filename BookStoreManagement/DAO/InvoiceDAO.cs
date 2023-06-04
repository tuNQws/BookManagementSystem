using BookStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookStoreManagement.DAO
{
    class InvoiceDAO
    {
        private static InvoiceDAO instance;

        public static InvoiceDAO Instance
        {
            get { if (instance == null) instance = new InvoiceDAO(); return InvoiceDAO.instance; }
            private set { InvoiceDAO.instance = value; }
        }

        private InvoiceDAO() { }

        public List<Invoice> GetListInvoices()
        {
            List<Invoice> list = new List<Invoice>();

            string query = "select * from Invoice";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Invoice invoice = new Invoice(item);
                list.Add(invoice);
            }

            return list;
        }

        public List<Invoice> GetInvoicesByEmpId(int empId)
        {
            List<Invoice> list = new List<Invoice>();

            string query = "select * from Invoice where emp_id = " + empId;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Invoice invoice = new Invoice(item);
                list.Add(invoice);
            }

            return list;
        }

        public bool InsertInvoice(DateTime date_invoice, int amount_invoice, string status, int emp_id)
        {
            string query = string.Format("INSERT Invoice ( date_invoice, amount_invoice, status, emp_id ) VALUES  ( N'{0}', {1}, N'{2}', {3})",
                date_invoice, amount_invoice, status, emp_id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public int InsertAndGetUncheckedInvoiceId(DateTime date_invoice, int amount_invoice, string status, int emp_id)
        {
            if (InsertInvoice(date_invoice, amount_invoice, status, emp_id))
            {
                DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Invoice WHERE status = N'unchecked' ORDER BY id desc");

                if (data.Rows.Count > 0)
                {
                    Invoice bill = new Invoice(data.Rows[0]);
                    return bill.ID;
                }
                return -1;
            }
            return -1;
        }

        public bool UpdateInvoiceCheck(int invoiceId, int totalPrice)
        {
            string query = string.Format("UPDATE Invoice SET status = N'checked', amount_invoice = {0} WHERE id = {1}", totalPrice, invoiceId);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public DataTable GetInvoiceListByDate(DateTime fromDate, DateTime toDate)
        {
            string query = string.Format("SELECT * FROM invoice WHERE date_invoice >= N'{0}' AND date_invoice <= N'{1}'", fromDate, toDate);
            return DataProvider.Instance.ExecuteQuery(query);
        }

        //public bool UpdateInvoice(int id, DateTime date_entry, int amount_entry, int emp_id, int supplier_id)
        //{
        //    string query = string.Format("UPDATE Book_Entry SET date_entry = N'{0}', amount_entry = {1}, emp_id = {2}, supplier_id = {3}  WHERE id = {4}",
        //        date_entry, amount_entry, emp_id, supplier_id, id);
        //    int result = DataProvider.Instance.ExecuteNonQuery(query);

        //    return result > 0;
        //}
    }
}
