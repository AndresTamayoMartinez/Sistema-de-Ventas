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
    public class CN_Productos
    {
        private CD_Productos objectCD = new CD_Productos();

        public DataTable showProducts()
        {
            DataTable table = new DataTable();
            table = objectCD.show();
            return table;
        }

        public void insertProduct(string name, string description, string categori, string presentation, string stock, string price)
        {
            objectCD.insert(name, description, categori, presentation, Convert.ToDouble(stock), Convert.ToDouble(price));
        }

        public void updateProduct(string id_product, string name, string description, string categori, string presentation, string stock, string price)
        {
            objectCD.update(Convert.ToInt32(id_product), name, description, categori, presentation, Convert.ToDouble(stock), Convert.ToDouble(price));
        }

        public void deleteProducto(string id_product)
        {
            objectCD.delete(Convert.ToInt32(id_product));
        }

        public DataTable searchProduct(string name)
        {
            DataTable table = new DataTable();
            table = objectCD.search(name);
            return table;
        }

        public double searchStock(string id_product)
        {
            return objectCD.searchStock(Convert.ToInt32(id_product));
        }

        public void updateStock(string id_product, double stock)
        {
            objectCD.updateStock(Convert.ToInt32(id_product), stock);
        }

        public void updatePrice(string id_product, string price)
        {
            objectCD.updatePrice(Convert.ToInt32(id_product), Convert.ToDouble(price));
        }
    }
}
