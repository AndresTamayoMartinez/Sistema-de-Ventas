using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Ingreso
    {
        private CD_Conection cn = new CD_Conection();

        SqlDataReader read;
        DataTable table = new DataTable();
        SqlCommand command = new SqlCommand();
        public string codigo;

        //Inicio de la sección Ingreso

        public DataTable showEntry()
        {
            SqlCommand comand = new SqlCommand();
            comand.Connection = cn.openConection();
            comand.CommandText = "sp_mostrar_ingreso";
            comand.CommandType = CommandType.StoredProcedure;
            read = comand.ExecuteReader();
            table.Load(read);
            cn.closeConection();
            return table;
        }

        public void insertEntry(int id_provider, string date, double total)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_insertar_ingreso";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_proveedor", id_provider);
            command.Parameters.AddWithValue("@fecha", date);
            command.Parameters.AddWithValue("@total", total);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public void updateEntry(int id_entry, int id_provider, string date, double total)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_editar_ingreso";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_ingreso", id_entry);
            command.Parameters.AddWithValue("@id_proveedor", id_provider);
            command.Parameters.AddWithValue("@fecha", date);
            command.Parameters.AddWithValue("@total", total);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public void deleteEntry(int id_entry)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_eliminar_ingreso";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_ingreso", id_entry);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        //Fin de la sección Ingreso

        //Inicio de la sección Detalle_Ingreso

        public DataTable showDetEntry(int id_entry)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_mostrar_detIngreso";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_ingreso", id_entry);
            read = command.ExecuteReader();
            table.Load(read);
            cn.closeConection();
            command.Parameters.Clear();
            return table;
        }

        public void insertDetEntry(int id_entry, int id_product, double pucharse_price, double sale_price, double income_amount, double subtotal)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_insertar_detIngreso";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_ingreso", id_entry);
            command.Parameters.AddWithValue("@id_producto", id_product);
            command.Parameters.AddWithValue("@precio_compra", pucharse_price);
            command.Parameters.AddWithValue("@precio_venta", sale_price);
            command.Parameters.AddWithValue("@cantidad_ingreso", income_amount);
            command.Parameters.AddWithValue("@subtotal", subtotal);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public void updateDetEntry(int id_entry, int id_product, double pucharse_price, double sale_price, double income_amount, double subtotal)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_editar_detIngreso";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_ingreso", id_entry);
            command.Parameters.AddWithValue("@id_producto", id_product);
            command.Parameters.AddWithValue("@precio_compra", pucharse_price);
            command.Parameters.AddWithValue("@precio_venta", sale_price);
            command.Parameters.AddWithValue("@cantidad_ingreso", income_amount);
            command.Parameters.AddWithValue("@subtotal", subtotal);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public void deleteDetEntry(int id_entry, int id_product)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_eliminar_detIngreso";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_ingreso", id_entry);
            command.Parameters.AddWithValue("@id_producto", id_product);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public string searchID(int id_provider, string date)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_codigo_ingreso";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_proveedor", id_provider);
            command.Parameters.AddWithValue("@fecha", date);
            read = command.ExecuteReader();
            if (read.Read())
            {
                codigo = Convert.ToString(read[0]);
            }
            cn.closeConection();
            command.Parameters.Clear();
            return codigo;
        }

        public void updateTotal(int id_entry, double total)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_actualizar_totalIngreso";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_ingreso", id_entry);
            command.Parameters.AddWithValue("@total", total);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        //Fin de la sección Detalle_Ingreso
    }
}
