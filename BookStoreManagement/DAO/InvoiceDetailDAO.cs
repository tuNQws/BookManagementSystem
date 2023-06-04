using BookStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagement.DAO
{
    class InvoiceDetailDAO
    {
        private static InvoiceDetailDAO instance;

        public static InvoiceDetailDAO Instance
        {
            get { if (instance == null) instance = new InvoiceDetailDAO(); return InvoiceDetailDAO.instance; }
            private set { InvoiceDetailDAO.instance = value; }
        }

        private InvoiceDetailDAO() { }

        public List<InvoiceDetail> GetInvoiceDetailsByInvoiceId(int InvoiceId)
        {
            List<InvoiceDetail> list = new List<InvoiceDetail>();

            string query = string.Format("select i.book_id, b.title, i.quantity, i.unit_price from Invoice_Detail as i, Book as b where invoice_id = {0} AND b.id = i.book_id", InvoiceId);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                InvoiceDetail invoiceDetail = new InvoiceDetail(item);
                list.Add(invoiceDetail);
            }

            return list;
        }

        public bool InsertInvoiceDetail(int invoice_id, int book_id, int quantity, int unit_price)
        {
            string query = string.Format("INSERT Invoice_Detail ( invoice_id, book_id, quantity, unit_price ) VALUES  ( {0}, {1}, {2}, {3} )",
                invoice_id, book_id, quantity, unit_price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public InvoiceDetail GetInvoiceDetail(int invoiceId, int bookId)
        {
            string query = string.Format("select i.book_id, b.title, i.quantity, i.unit_price from Invoice_Detail as i, Book as b where i.invoice_id = {0} AND b.id = i.book_id AND i.book_id = {1}", invoiceId, bookId);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                InvoiceDetail invoiceDetail = new InvoiceDetail(item);
                return invoiceDetail;
            }

            return null;
        }

        public void DeleteInvoiceDetail(int invoice_id, int book_id)
        {
            DataProvider.Instance.ExecuteQuery(string.Format("delete Invoice_Detail WHERE invoice_id = {0} AND book_id = {1}", invoice_id, book_id));
        }

        //public bool UpdateBookEntryDetail(int id, DateTime date_entry, int amount_entry, int emp_id, int supplier_id)
        //{
        //    string query = string.Format("UPDATE Book_Entry SET date_entry = N'{0}', amount_entry = {1}, emp_id = {2}, supplier_id = {3}  WHERE id = {4}",
        //        date_entry, amount_entry, emp_id, supplier_id, id);
        //    int result = DataProvider.Instance.ExecuteNonQuery(query);

        //    return result > 0;
        //}
    }
}
