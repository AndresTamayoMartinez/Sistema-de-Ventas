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
    public class CN_Ventas
    {
        CD_Venta objectCD = new CD_Venta();

        //Inicio de la sección Ventas

        public DataTable showSales()
        {
            DataTable table = new DataTable();
            table = objectCD.showSales();
            return table;
        }

        public void insertSales(string id_client, string id_employe, string date, double subtotal, double abono, double total)
        {
            objectCD.insertSales(Convert.ToInt32(id_client), Convert.ToInt32(id_employe), date, subtotal, abono, total);
        }

        public void updateSales(string id_sale, string id_client, string id_employe, string date, double subtotal, double abono, double total)
        {
            objectCD.updateSales(Convert.ToInt32(id_sale), Convert.ToInt32(id_client), Convert.ToInt32(id_employe), date, subtotal, abono, total);
        }

        public void deleteSales(string id_sale)
        {
            objectCD.deleteSales(Convert.ToInt32(id_sale));
        }

        //Fin de la sección Ventas

        //Inicio de la sección detVentas

        public DataTable showDetSales(string id_sale)
        {
            DataTable table = new DataTable();
            table = objectCD.showDetSales(Convert.ToInt32(id_sale));
            return table;
        }

        public void insertDetSales(string id_sale, string id_product, string amount, string price, double subtotal)
        {
            objectCD.insertDetSales(Convert.ToInt32(id_sale), Convert.ToInt32(id_product), Convert.ToDouble(amount), Convert.ToDouble(price), subtotal);
        }

        public void updateDetSales(string id_sale, string id_product, string amount, string price, double subtotal)
        {
            objectCD.updateDetSales(Convert.ToInt32(id_sale), Convert.ToInt32(id_product), Convert.ToDouble(amount), Convert.ToDouble(price), subtotal);
        }

        public void deleteDetSales(string id_sale, string id_product)
        {
            objectCD.deleteDetSales(Convert.ToInt32(id_sale), Convert.ToInt32(id_product));
        }

        public string searchID(string id_client, string date)
        {
            return objectCD.searchID(Convert.ToInt32(id_client), date);
        }

        public void updateTotal(string id_sale, double subtotal, double abono, double total)
        {
            objectCD.updateTotal(Convert.ToInt32(id_sale), subtotal, abono, total);
        }

        //Fin de la sección detVentas
    }
}
