using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Ingreso
    {
        private CD_Ingreso objectCD = new CD_Ingreso();

        //Inicio de la sección Ingreso

        public DataTable showEntry()
        {
            DataTable table = new DataTable();
            table = objectCD.showEntry();
            return table;
        }

        public void insertEntry(string id_provider, string date, double total)
        {
            objectCD.insertEntry(Convert.ToInt32(id_provider), date, total);
        }

        public void insertEntry(string id_entry, string id_provider, string date, double total)
        {
            objectCD.updateEntry(Convert.ToInt32(id_entry),Convert.ToInt32(id_provider), date, total);
        }

        public void deleteEntry(string id_entry)
        {
            objectCD.deleteEntry(Convert.ToInt32(id_entry));
        }

        //Fin de la sección Ingreso

        //Inicio de la sección Detalle_Ingreso

        public DataTable showDetEntry(string id_entry)
        {
            DataTable table = new DataTable();
            table = objectCD.showDetEntry(Convert.ToInt32(id_entry));
            return table;
        }

        public void insertDetEntry(string id_entry, string id_product, string pucharse_price, string sale_price, string income_amount, double subtotal)
        {
            objectCD.insertDetEntry(Convert.ToInt32(id_entry), Convert.ToInt32(id_product), Convert.ToDouble(pucharse_price), Convert.ToDouble(sale_price), Convert.ToDouble(income_amount), subtotal);
        }

        public void updateDetEntry(string id_entry, string id_product, string pucharse_price, string sale_price, string income_amount, double subtotal)
        {
            objectCD.updateDetEntry(Convert.ToInt32(id_entry), Convert.ToInt32(id_product), Convert.ToDouble(pucharse_price), Convert.ToDouble(sale_price), Convert.ToDouble(income_amount), subtotal);
        }

        public void deleteDetEntry(string id_entry, string id_product)
        {
            objectCD.deleteDetEntry(Convert.ToInt32(id_entry), Convert.ToInt32(id_product));
        }

        public string searchID(string id_provider, string date)
        {
            return objectCD.searchID(Convert.ToInt32(id_provider), date);
        }

        public void updateTotal(string id_entry, double total)
        {
            objectCD.updateTotal(Convert.ToInt32(id_entry), total);
        }

        //Fin de la sección Detalle_Ingreso
    }
}
