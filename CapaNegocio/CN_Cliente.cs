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
    public class CN_Cliente
    {
        private CD_Clientes objectCD = new CD_Clientes();

        public DataTable showClient()
        {
            DataTable table = new DataTable();
            table = objectCD.show();
            return table;
        }

        public void insertClient(string name, string lastname, string street, string suburb, string city, string phone, string email)
        {
            objectCD.insert(name, lastname, street, suburb, city, phone, email);
        }

        public void updateClient(string id_client, string name, string lastname, string street, string suburb, string city, string phone, string email)
        {
            objectCD.update(Convert.ToInt32(id_client), name, lastname, street, suburb, city, phone, email);
        }

        public void deleteClient(string id_client)
        {
            objectCD.delete(Convert.ToInt32(id_client));
        }

        public DataTable searchClient(string name)
        {
            DataTable table = new DataTable();
            table = objectCD.search(name);
            return table;
        }
    }
}
