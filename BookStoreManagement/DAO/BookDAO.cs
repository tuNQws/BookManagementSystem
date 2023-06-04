using BookStoreManagement.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagement.DAO
{
    class BookDAO
    {
        private static BookDAO instance;

        public static BookDAO Instance
        {
            get { if (instance == null) instance = new BookDAO(); return BookDAO.instance; }
            private set { BookDAO.instance = value; }
        }

        private BookDAO() { }

        public List<Book> GetListBooks()
        {
            List<Book> list = new List<Book>();

            string query = "select * from book";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Book book = new Book(item);
                list.Add(book);
            }

            return list;
        }

        public List<Book> SearchBookByName(string name)
        {

            List<Book> list = new List<Book>();

            string query = string.Format("SELECT * FROM Book WHERE dbo.fuConvertToUnsign1(title) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Book food = new Book(item);
                list.Add(food);
            }

            return list;
        }

        public bool InsertBook(string title, string author, string publisher, int publish_year, int stock, string category, int price)
        {
            string query = string.Format("INSERT Book ( title, author, publisher, publish_year, stock, category, price ) VALUES  ( N'{0}', N'{1}', N'{2}', {3}, {4}, N'{5}', {6})",
                title, author, publisher, publish_year, stock, category, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool CheckStockByBookId(int book_id, int stock)
        {
            string query = string.Format("select stock from book where id = {0}", book_id);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                return (int)item["stock"] >= stock;
            }

            return false;
        }

        public bool DecreaseStockByBookId(int book_id, int stock)
        {
            if (CheckStockByBookId(book_id,stock))
            {
                string query = string.Format("UPDATE Book SET stock = stock - {0} WHERE id = {1}",
            stock, book_id);
                int result = DataProvider.Instance.ExecuteNonQuery(query);

                return result > 0;
            }
            else
            {
                return false;
            }
        }

        public bool IncreaseStockByBookId(int book_id, int stock)
        {
            string query = string.Format("UPDATE Book SET stock = stock + {0}  WHERE id = {1}",
            stock, book_id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateBook(int id, string title, string author, string publisher, int publish_year, int stock, string category, int price)
        {
            string query = string.Format("UPDATE Book SET title = N'{0}', author = N'{1}', publisher = N'{2}', publish_year = {3}, stock = {4}, category = N'{5}', price = {6}  WHERE id = {7}", 
                title, author, publisher, publish_year, stock, category, price, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        //public bool DeleteBook(int idBook)
        //{
        //    //InvoiceDetailDAO.Instance.DeleteBillInfoByFoodID(idBook);

        //    string query = string.Format("Delete Book where id = {0}", idBook);
        //    int result = DataProvider.Instance.ExecuteNonQuery(query);

        //    return result > 0;
        //}
    }
}
