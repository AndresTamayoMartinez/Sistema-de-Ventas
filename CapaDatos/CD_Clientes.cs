using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Clientes
    {
        private CD_Conection cn = new CD_Conection();

        SqlDataReader read;
        DataTable table = new DataTable();
        SqlCommand command = new SqlCommand();

        public DataTable show()
        {
            SqlCommand comand = new SqlCommand();
            comand.Connection = cn.openConection();
            comand.CommandText = "sp_mostrar_cliente";
            comand.CommandType = CommandType.StoredProcedure;
            read = comand.ExecuteReader();
            table.Load(read);
            cn.closeConection();
            return table;
        }

        public void insert(string name, string lastname, string street, string suburb, string city, string phone, string email)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_insertar_cliente";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@nombre", name);
            command.Parameters.AddWithValue("@apellido", lastname);
            command.Parameters.AddWithValue("@calle", street);
            command.Parameters.AddWithValue("@colonia", suburb);
            command.Parameters.AddWithValue("@ciudad", city);
            command.Parameters.AddWithValue("@telefono", phone);
            command.Parameters.AddWithValue("@correo", email);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public void update(int id_client, string name, string lastname, string street, string suburb, string city, string phone, string email)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_editar_cliente";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_cliente", id_client);
            command.Parameters.AddWithValue("@nombre", name);
            command.Parameters.AddWithValue("@apellido", lastname);
            command.Parameters.AddWithValue("@calle", street);
            command.Parameters.AddWithValue("@colonia", suburb);
            command.Parameters.AddWithValue("@ciudad", city);
            command.Parameters.AddWithValue("@telefono", phone);
            command.Parameters.AddWithValue("@correo", email);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public void delete(int id_client)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_eliminar_cliente";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_cliente", id_client);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public DataTable search(string name)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_buscar_cliente";
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
