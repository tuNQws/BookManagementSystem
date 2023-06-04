using BookStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagement.DAO
{
    class BookEntryDetailDAO
    {
        private static BookEntryDetailDAO instance;

        public static BookEntryDetailDAO Instance
        {
            get { if (instance == null) instance = new BookEntryDetailDAO(); return BookEntryDetailDAO.instance; }
            private set { BookEntryDetailDAO.instance = value; }
        }

        private BookEntryDetailDAO() { }

        public List<BookEntryDetail> GetBookEntryDetailsByBookEntryId(int bookEntryId)
        {
            List<BookEntryDetail> list = new List<BookEntryDetail>();

            string query = string.Format("select be.book_id, b.title, be.quantity, be.unit_price from Book_Entry_Detail as be, Book as b where be.book_entry_id = {0} AND be.book_id = b.id", bookEntryId);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                BookEntryDetail bookEntry = new BookEntryDetail(item);
                list.Add(bookEntry);
            }

            return list;
        }

        public bool InsertBookEntryDetail(int book_id, int book_entry_id, int quantity, int unit_price)
        {
            string query = string.Format("INSERT Book_Entry_Detail ( book_id, book_entry_id, quantity, unit_price ) VALUES  ( {0}, {1}, {2}, {3} )",
                book_id, book_entry_id, quantity, unit_price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public BookEntryDetail GetBookEntryDetail(int book_entry_id, int bookId)
        {
            string query = string.Format("select be.book_id, b.title, be.quantity, be.unit_price from Book_Entry_Detail as be, Book as b where be.book_entry_id = {0} AND b.id = be.book_id AND be.book_id = {1}", book_entry_id, bookId);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                BookEntryDetail bookEntryDetail = new BookEntryDetail(item);
                return bookEntryDetail;
            }

            return null;
        }

        public void DeleteBookEntryDetail(int book_entry_id, int book_id)
        {
            DataProvider.Instance.ExecuteQuery(string.Format("delete Book_entry_detail WHERE book_entry_id = {0} AND book_id = {1}", book_entry_id, book_id));
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
