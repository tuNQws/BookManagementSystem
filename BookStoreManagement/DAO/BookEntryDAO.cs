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

        public bool InsertBookEntry(DateTime date_entry, int amount_entry, int emp_id, int supplier_id)
        {
            string query = string.Format("INSERT Book_Entry ( date_entry, amount_entry, emp_id, supplier_id ) VALUES  ( N'{0}', {1}, {2}, {3})",
                date_entry, amount_entry, emp_id, supplier_id);
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
