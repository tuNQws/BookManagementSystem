using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagement.DTO
{
    class InvoiceDetail
    {
        private int invoice_id;
        private int book_id;
        private string book_title;
        private int quantity;
        private int unit_price;

        public InvoiceDetail(int invoice_id, int book_id, int quantity, int unit_price)
        {
            Invoice_id = invoice_id;
            Book_id = book_id;
            Quantity = quantity;
            Unit_price = unit_price;
        }

        public InvoiceDetail(DataRow row)
        {
            Book_title = (string)row["title"];
            Quantity = (int)row["quantity"];
            Unit_price = (int)row["unit_price"];
        }

        public int Invoice_id { get => invoice_id; set => invoice_id = value; }
        public int Book_id { get => book_id; set => book_id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int Unit_price { get => unit_price; set => unit_price = value; }
        public string Book_title { get => book_title; set => book_title = value; }
    }
}
