using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Conection
    {
        //Coneccion a la base de datos local
        private SqlConnection conection = new SqlConnection("Server=localhost; DataBase=DB_Tienda; Integrated Security=true");
        //Coneccion a la base de datos de la tienda
        //private SqlConnection conection = new SqlConnection("Server=192.168.1.69; DataBase=DB_Tienda; User ID=solrrack; Password=martinez56.");

        public SqlConnection openConection()
        {
            if (conection.State == ConnectionState.Closed)
            {
                conection.Open();
            }
            return conection;
        }

        public SqlConnection closeConection()
        {
            if (conection.State == ConnectionState.Open)
            {
                conection.Close();
            }
            return conection;
        }
    }
}
