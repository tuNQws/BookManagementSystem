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
        public string GetSupplierNameWithBookEntryId(int book_entry_id)
        {
            string query = string.Format("select * from supplier as s, book_entry as b where s.id = b.supplier_id AND b.id = {0}", book_entry_id);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                return (string)item["sup_name"];
            }
            return "";
        }
        
        public List<Supplier> SearchSupplierByName(string name)
        {

            List<Supplier> list = new List<Supplier>();

            string query = string.Format("SELECT * FROM Supplier WHERE dbo.fuConvertToUnsign1(sup_name) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Supplier food = new Supplier(item);
                list.Add(food);
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
            string query = string.Format("UPDATE Supplier SET sup_name = N'{0}', sup_address = N'{1}', sup_email = N'{2}', sup_phone = N'{3}', sup_bank = N'{4}', sup_tax_code = N'{5}'  WHERE id = {6}",
                sup_name, sup_address, sup_email, sup_phone, sup_bank, sup_tax_code, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
