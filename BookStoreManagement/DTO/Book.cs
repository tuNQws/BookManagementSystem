using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagement.DTO
{
    class Book
    {


        private int iD;

        private string title;

        private string author;

        private string publisher;

        private int publish_year;

        private int stock;

        private string category;

        private int price;

        public Book(int iD, string title, string author, string publisher, int publish_year, int stock, string category, int price)
        {
            ID = iD;
            Title = title;
            Author = author;
            Publisher = publisher;
            Publish_year = publish_year;
            Stock = stock;
            Category = category;
            Price = price;          
        }

        public Book(DataRow row)
        {
            ID = (int)row["id"];
            Title = (string)row["title"];
            Author = (string)row["author"];
            Publisher = (string)row["publisher"];
            Publish_year = (int)row["publish_year"];
            Stock = (int)row["stock"];
            Category = (string)row["category"];
            Price = (int)row["price"];
        }

        public int ID { get => iD; set => iD = value; }
        public string Title { get => title; set => title = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public int Publish_year { get => publish_year; set => publish_year = value; }
        public int Stock { get => stock; set => stock = value; }
        public string Category { get => category; set => category = value; }
        public int Price { get => price; set => price = value; }
        public string Author { get => author; set => author = value; }
    }
}
