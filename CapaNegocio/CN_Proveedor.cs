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
    public class CN_Proveedor
    {
        private CD_Proveedor objectCD = new CD_Proveedor();

        public DataTable showProvider()
        {
            DataTable table = new DataTable();
            table = objectCD.show();
            return table;
        }

        public void insertProvider(string businessName, string name, string phone, string email)
        {
            objectCD.insert(businessName, name, phone, email);
        }

        public void updateProvider(string id_provider, string businessName, string name, string phone, string email)
        {
            objectCD.update(Convert.ToInt32(id_provider), businessName, name, phone, email);
        }

        public void deleteProvider(string id_provider)
        {
            objectCD.delete(Convert.ToInt32(id_provider));
        }

        public DataTable searchProvider(string name)
        {
            DataTable table = new DataTable();
            table = objectCD.search(name);
            return table;
        }
    }
}
