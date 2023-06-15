using BookStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagement.DAO
{
    class BookEntryDAO
    {
        private static BookEntryDAO instance;

        public static BookEntryDAO Instance
        {
            get { if (instance == null) instance = new BookEntryDAO(); return BookEntryDAO.instance; }
            private set { BookEntryDAO.instance = value; }
        }

        private BookEntryDAO() { }

        public List<BookEntry> GetListBookEntrys()
        {
            List<BookEntry> list = new List<BookEntry>();

            string query = "select * from Book_Entry";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                BookEntry bookEntry = new BookEntry(item);
                list.Add(bookEntry);
            }

            return list;
        }
    

        public bool InsertBookEntry(DateTime date_entry, int amount_entry, string status, int emp_id, int supplier_id)
        {
            string query = string.Format("INSERT Book_Entry ( date_entry, amount_entry, status, emp_id, supplier_id ) VALUES  ( N'{0}', {1}, N'{2}', {3}, {4})",
                date_entry, amount_entry, status, emp_id, supplier_id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public int InsertAndGetUncheckedBookEntryId(DateTime date_entry, int amount_entry, string status, int emp_id, int supplier_id)
        {
            if (InsertBookEntry(date_entry, amount_entry, status, emp_id, supplier_id))
            {
                DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Book_entry WHERE status = N'unchecked' ORDER BY id desc");

                if (data.Rows.Count > 0)
                {
                    BookEntry bookEntry = new BookEntry(data.Rows[0]);
                    return bookEntry.ID;
                }
                return -1;
            }
            return -1;
        }

        public DataTable GetBookEntryListByDate(DateTime fromDate, DateTime toDate)
        {
            string query = string.Format("SELECT * FROM book_entry WHERE date_entry >= N'{0}' AND date_entry <= N'{1}' AND status = N'checked'", fromDate, toDate);
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool UpdateBookEntryCheck(int bookEntryId, int totalPrice)
        {
            string query = string.Format("UPDATE Book_entry SET status = N'checked', amount_entry = {0} WHERE id = {1}", totalPrice, bookEntryId);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        

        public bool UpdateBookEntry(int id, DateTime date_entry, int amount_entry, int emp_id, int supplier_id)
        {
            string query = string.Format("UPDATE Book_Entry SET date_entry = N'{0}', amount_entry = {1}, emp_id = {2}, supplier_id = {3}  WHERE id = {4}",
                date_entry, amount_entry, emp_id, supplier_id, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
