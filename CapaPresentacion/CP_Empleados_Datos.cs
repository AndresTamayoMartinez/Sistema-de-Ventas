using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class CP_Empleados_Datos : Form
    {
        CN_Empleados objectCN = new CN_Empleados();
        public bool edit = false;

        public CP_Empleados_Datos()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validEmpty() == true)
            {
                if (edit == false)
                {
                    try
                    {
                        objectCN.insertEmployee(txtName.Text, txtLastname.Text, txtPhone.Text, txtRank.Text, txtUser.Text, txtPassword.Text);
                        MessageBox.Show("Se han insertado los datos correctamente");
                        txtClear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error.\nError:\n" + ex);
                    }
                }
                else
                {
                    try
                    {
                        objectCN.updateEmployee(txtID.Text, txtName.Text, txtLastname.Text, txtPhone.Text, txtRank.Text, txtUser.Text, txtPassword.Text);
                        MessageBox.Show("Se han actualizado los datos correctamente");
                        txtClear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error.\nError:\n" + ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Faltan algunos campos de llenar");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                try
                {
                    objectCN.deleteEmployee(txtID.Text);
                    MessageBox.Show("Se han eliminado los datos correctamente");
                    txtClear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error.\nError:\n" + ex);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtClear()
        {
            this.txtID.Clear();
            this.txtName.Clear();
            this.txtLastname.Clear();
            this.txtPhone.Clear();
            this.txtRank.Clear();
            this.txtUser.Clear();
            this.txtPassword.Clear();
        }

        private bool validEmpty()
        {
            bool empty = false;
            if (txtName.Text != "" && txtLastname.Text != "" && txtPhone.Text != "" 
                && txtRank.Text != "" && txtUser.Text != "" && txtPassword.Text != "")
            {
                empty = true;
            }
            return empty;
        }
    }
}
