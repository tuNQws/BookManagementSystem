using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagement.DTO
{
    class BookEntryDetail
    {
        private int book_id;
        private int book_entry_id;
        private int quantity;
        private int unit_price;

        public BookEntryDetail(int book_id, int book_entry_id, int quantity, int unit_price)
        {
            Book_id = book_id;
            Book_entry_id = book_entry_id;
            Quantity = quantity;
            Unit_price = unit_price;
        }

        public BookEntryDetail(DataRow row)
        {
            Book_id = (int)row["book_id"];
            Book_entry_id = (int)row["book_entry_id"];
            Quantity = (int)row["quantity"];
            Unit_price = (int)row["unit_price"];
        }

        public int Book_id { get => book_id; set => book_id = value; }
        public int Book_entry_id { get => book_entry_id; set => book_entry_id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int Unit_price { get => unit_price; set => unit_price = value; }
    }
}
