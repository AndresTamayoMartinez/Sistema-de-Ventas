using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Empleados
    {
        private CD_Conection cn = new CD_Conection();

        SqlDataReader read;
        DataTable table = new DataTable();
        SqlCommand command = new SqlCommand();

        public DataTable show()
        {
            SqlCommand comand = new SqlCommand();
            comand.Connection = cn.openConection();
            comand.CommandText = "sp_mostrar_empleado";
            comand.CommandType = CommandType.StoredProcedure;
            read = comand.ExecuteReader();
            table.Load(read);
            cn.closeConection();
            return table;
        }

        public void insert(string name, string lastname, string phone, string rank, string user, string password)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_insertar_empleado";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@nombre", name);
            command.Parameters.AddWithValue("@apellido", lastname);
            command.Parameters.AddWithValue("@telefono", phone);
            command.Parameters.AddWithValue("@puesto", rank);
            command.Parameters.AddWithValue("@usuario", user);
            command.Parameters.AddWithValue("@contraseña", password);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public void update(int id_employee, string name, string lastname, string phone, string rank, string user, string password)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_editar_empleado";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_empleado", id_employee);
            command.Parameters.AddWithValue("@nombre", name);
            command.Parameters.AddWithValue("@apellido", lastname);
            command.Parameters.AddWithValue("@telefono", phone);
            command.Parameters.AddWithValue("@puesto", rank);
            command.Parameters.AddWithValue("@usuario", user);
            command.Parameters.AddWithValue("@contraseña", password);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public void delete(int id_employee)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_eliminar_empleado";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_empleado", id_employee);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }

        public DataTable search(string name)
        {
            command.Connection = cn.openConection();
            command.CommandText = "sp_buscar_empleado";
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
