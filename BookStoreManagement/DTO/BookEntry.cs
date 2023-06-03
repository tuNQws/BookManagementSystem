using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BookStoreManagement.DTO
{
    class BookEntry
    {
        private int iD;
        private DateTime date_entry;
        private int amount_entry;
        private int emp_id;
        private int supplier_id;

        public BookEntry(int iD, DateTime date_entry, int amount_entry, int emp_id, int supplier_id)
        {
            ID = iD;
            Date_entry = date_entry;
            Amount_entry = amount_entry;
            Emp_id = emp_id;
            Supplier_id = supplier_id;
        }

        public BookEntry(DataRow row)
        {
            ID = (int)row["id"];
            Date_entry = (DateTime)row["date_entry"];
            Amount_entry = (int)row["amount_entry"];
            Emp_id = (int)row["emp_id"];
            Supplier_id = (int)row["supplier_id"];
        }

        public int ID { get => iD; set => iD = value; }
        public DateTime Date_entry { get => date_entry; set => date_entry = value; }
        public int Amount_entry { get => amount_entry; set => amount_entry = value; }
        public int Emp_id { get => emp_id; set => emp_id = value; }
        public int Supplier_id { get => supplier_id; set => supplier_id = value; }
        
    }
}
