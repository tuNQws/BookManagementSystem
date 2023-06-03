using BookStoreManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreManagement.DAO
{
    class SupplierDAO
    {
        private static SupplierDAO instance;

        public static SupplierDAO Instance
        {
            get { if (instance == null) instance = new SupplierDAO(); return SupplierDAO.instance; }
            private set { SupplierDAO.instance = value; }
        }

        private SupplierDAO() { }

        public List<Supplier> GetListSuppliers()
        {
            List<Supplier> list = new List<Supplier>();

            string query = "select * from supplier";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Supplier supplier = new Supplier(item);
                list.Add(supplier);
            }

            return list;
        }

        public bool InsertSupplier(string sup_name, string sup_address, string sup_email, string sup_phone, string sup_bank, string sup_tax_code)
        {
            string query = string.Format("INSERT Supplier ( sup_name, sup_address, sup_email, sup_phone, sup_bank, sup_tax_code ) VALUES  ( N'{0}', N'{1}', N'{2}',  N'{3}',  N'{4}', N'{5}')",
                sup_name, sup_address, sup_email, sup_phone, sup_bank, sup_tax_code);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool UpdateSupplier(int id, string sup_name, string sup_address, string sup_email, string sup_phone, string sup_bank, string sup_tax_code)
        {
            string query = string.Format("UPDATE Supplier SET sup_name = N'{0}', sup_address = {1}, sup_email = {2}, sup_phone = {3}, sup_bank = {4}  WHERE id = {5}",
                sup_name, sup_address, sup_email, sup_phone, sup_bank, sup_tax_code, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
