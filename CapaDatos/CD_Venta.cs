using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Venta
    {
        private CD_Conection cn = new CD_Conection();

        SqlDataReader read;
        DataTable table = new DataTable();
        SqlCommand command = new SqlCommand();
        string codigo;

        //Inicio de la sección Venta

        public DataTable showSales()
        {
            SqlCommand comand = new SqlCommand();
            comand.Connection = cn.openConection();
            comand.CommandText = "sp_mostrar_venta";
            comand.CommandType = CommandType.StoredProcedure;
            read = comand.ExecuteReader();
            table.Load(read);
            cn.closeConection();
            return table;
        }

        public void insertSales(int id_client, int id_employee, string date, double subtotal, double abono, double total)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_insertar_venta";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_cliente", id_client);
            command.Parameters.AddWithValue("@id_empleado", id_employee);
            command.Parameters.AddWithValue("@fecha", date);
            command.Parameters.AddWithValue("@subtotal", subtotal);
            command.Parameters.AddWithValue("@abono", abono);
            command.Parameters.AddWithValue("@total", total);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public void updateSales(int id_sale, int id_client, int id_employee, string date, double subtotal, double abono, double total)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_editar_venta";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_venta", id_sale);
            command.Parameters.AddWithValue("@id_cliente", id_client);
            command.Parameters.AddWithValue("@id_empleado", id_employee);
            command.Parameters.AddWithValue("@fecha", date);
            command.Parameters.AddWithValue("@subtotal", subtotal);
            command.Parameters.AddWithValue("@abono", abono);
            command.Parameters.AddWithValue("@total", total);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public void deleteSales(int id_sale)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_eliminar_venta";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_venta", id_sale);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public DataTable searchSales(int id_sale)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_buscar_venta";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_venta", id_sale);
            read = command.ExecuteReader();
            table.Load(read);
            cn.closeConection();
            command.Parameters.Clear();
            return table;
        }

        //Fin de la sección venta

        //Inicio de la seccion detalleVenta

        public DataTable showDetSales(int id_sale)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_mostrar_detVenta";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_venta", id_sale);
            read = command.ExecuteReader();
            table.Load(read);
            cn.closeConection();
            command.Parameters.Clear();
            return table;
        }

        public void insertDetSales(int id_sale, int id_product, double amount, double price, double subtotal)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_insertar_detVenta";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_venta", id_sale);
            command.Parameters.AddWithValue("@id_producto", id_product);
            command.Parameters.AddWithValue("@cantidad", amount);
            command.Parameters.AddWithValue("@precio_venta", price);
            command.Parameters.AddWithValue("@subtotal", subtotal);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public void updateDetSales(int id_sale, int id_product, double amount, double price, double subtotal)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_editar_detVenta";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_venta", id_sale);
            command.Parameters.AddWithValue("@id_producto", id_product);
            command.Parameters.AddWithValue("@cantidad", amount);
            command.Parameters.AddWithValue("@precio_venta", price);
            command.Parameters.AddWithValue("@subtotal", subtotal);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public void deleteDetSales(int id_sale, int id_product)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_eliminar_detVenta";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_venta", id_sale);
            command.Parameters.AddWithValue("@id_producto", id_product);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public string searchID(int id_client, string date)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_codigo_venta";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_cliente", id_client);
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

        public void updateTotal(int id_sale, double subtotal, double abono, double total)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_actualizar_totalVenta";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_venta", id_sale);
            command.Parameters.AddWithValue("@subtotal", subtotal);
            command.Parameters.AddWithValue("@abono", abono);
            command.Parameters.AddWithValue("@total", total);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        //Fin de la seccion detalleVenta
    }
}