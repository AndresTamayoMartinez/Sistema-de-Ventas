using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Proveedor
    {
        private CD_Conection cn = new CD_Conection();

        SqlDataReader read;
        DataTable table = new DataTable();
        SqlCommand command = new SqlCommand();

        public DataTable show()
        {
            SqlCommand comand = new SqlCommand();
            comand.Connection = cn.openConection();
            comand.CommandText = "sp_mostrar_proveedor";
            comand.CommandType = CommandType.StoredProcedure;
            read = comand.ExecuteReader();
            table.Load(read);
            cn.closeConection();
            return table;
        }

        public void insert(string businessName, string name, string phone, string email)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_insertar_proveedor";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@razon_social", businessName);
            command.Parameters.AddWithValue("@nombre", name);
            command.Parameters.AddWithValue("@telefono", phone);
            command.Parameters.AddWithValue("@correo", email);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public void update(int id_provider, string businessName, string name, string phone, string email)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_editar_proveedor";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_proveedor", id_provider);
            command.Parameters.AddWithValue("@razon_social", businessName);
            command.Parameters.AddWithValue("@nombre", name);
            command.Parameters.AddWithValue("@telefono", phone);
            command.Parameters.AddWithValue("@correo", email);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public void delete(int id_client)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_eliminar_proveedor";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_proveedor", id_client);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public DataTable search(string name)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_buscar_proveedor";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@nombre", name);
            read = command.ExecuteReader();
            table.Load(read);
            cn.closeConection();
            command.Parameters.Clear();
            return table;
        }
    }
}
