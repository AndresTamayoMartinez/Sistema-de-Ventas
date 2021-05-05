using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Empleados
    {
        private CD_Empleados objectCD = new CD_Empleados();

        public DataTable showEmployee()
        {
            DataTable table = new DataTable();
            table = objectCD.show();
            return table;
        }

        public void insertEmployee(string name, string lastname, string phone, string rank, string user, string password)
        {
            objectCD.insert(name, lastname, phone, rank, user, password);
        }

        public void updateEmployee(string id_employee, string name, string lastname, string phone, string rank, string user, string password)
        {
            objectCD.update(Convert.ToInt32(id_employee), name, lastname, phone, rank, user, password);
        }

        public void deleteEmployee(string id_employee)
        {
            objectCD.delete(Convert.ToInt32(id_employee));
        }

        public DataTable searchEmployee(string name)
        {
            DataTable table = new DataTable();
            table = objectCD.search(name);
            return table;
        }
    }
}
