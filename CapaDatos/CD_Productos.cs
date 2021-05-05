using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Productos
    {
        private CD_Conection cn = new CD_Conection();

        SqlDataReader read;
        DataTable table    = new DataTable();
        SqlCommand command = new SqlCommand();
        double stock;

        public DataTable show()
        {
            SqlCommand comand  = new SqlCommand();
            comand.Connection  = cn.openConection();
            comand.CommandText = "sp_mostrar_productos";
            comand.CommandType = CommandType.StoredProcedure;
            read = comand.ExecuteReader();
            table.Load(read);
            cn.closeConection();
            return table;
        }

        public void insert(string name, string description, string categori, string presentation, double stock, double price)
        {
            command.Connection  = cn.openConection();
            command.CommandText = "sp_insertar_productos";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@nombre", name);
            command.Parameters.AddWithValue("@descripcion", description);
            command.Parameters.AddWithValue("@categoria", categori);
            command.Parameters.AddWithValue("@presentacion", presentation);
            command.Parameters.AddWithValue("@stock", stock);
            command.Parameters.AddWithValue("@precio", price);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public void update(int id_products,string name, string description, string categori, string presentation, double stock, double price)
        {
            command.Connection  = cn.openConection();
            command.CommandText = "sp_editar_productos";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_producto", id_products);
            command.Parameters.AddWithValue("@nombre", name);
            command.Parameters.AddWithValue("@descripcion", description);
            command.Parameters.AddWithValue("@categoria", categori);
            command.Parameters.AddWithValue("@presentacion", presentation);
            command.Parameters.AddWithValue("@stock", stock);
            command.Parameters.AddWithValue("@precio", price);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public void delete(int id_products)
        {
            command.Connection  = cn.openConection();
            command.CommandText = "sp_eliminar_productos";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_producto", id_products);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public DataTable search(string name)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_buscar_producto";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@nombre", name);
            read = command.ExecuteReader();
            table.Load(read);
            cn.closeConection();
            command.Parameters.Clear();
            return table;
        }

        public double searchStock(int id_product)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_stock";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_producto", id_product);
            read = command.ExecuteReader();
            if (read.Read())
            {
                stock = Convert.ToDouble(read[0]);
            }
            cn.closeConection();
            command.Parameters.Clear();
            return stock;
        }

        public void updateStock(int id_products, double stock)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_actualizar_stock";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_producto", id_products);
            command.Parameters.AddWithValue("@stock", stock);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public void updatePrice(int id_products, double price)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_actualizar_precio";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_producto", id_products);
            command.Parameters.AddWithValue("@precio", price);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }
    }
}
