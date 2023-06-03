using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagement.DTO
{
    class Supplier
    {
        private int iD;
        private string sup_name;
        private string sup_address;
        private string sup_email;
        private string sup_phone;
        private string sup_bank;
        private string sup_tax_code;

        public Supplier(int iD, string sup_name, string sup_address, string sup_email, string sup_phone, string sup_bank, string sup_tax_code)
        {
            ID = iD;
            Sup_name = sup_name;
            Sup_address = sup_address;
            Sup_email = sup_email;
            Sup_phone = sup_phone;
            Sup_bank = sup_bank;
            Sup_tax_code = sup_tax_code;
        }

        public Supplier(DataRow row)
        {
            ID = (int)row["id"];
            Sup_name = (string)row["sup_name"];
            Sup_address = (string)row["sup_address"];
            Sup_email = (string)row["sup_email"];
            Sup_phone = (string)row["sup_phone"];
            Sup_bank = (string)row["sup_bank"];
            Sup_tax_code = (string)row["sup_tax_code"];
        }

        public int ID { get => iD; set => iD = value; }
        public string Sup_name { get => sup_name; set => sup_name = value; }
        public string Sup_address { get => sup_address; set => sup_address = value; }
        public string Sup_email { get => sup_email; set => sup_email = value; }
        public string Sup_phone { get => sup_phone; set => sup_phone = value; }
        public string Sup_bank { get => sup_bank; set => sup_bank = value; }
        public string Sup_tax_code { get => sup_tax_code; set => sup_tax_code = value; }
    }
}
