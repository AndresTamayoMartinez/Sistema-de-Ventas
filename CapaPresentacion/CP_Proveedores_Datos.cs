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
    public partial class CP_Proveedores_Datos : Form
    {
        CN_Proveedor objectCN = new CN_Proveedor();
        public bool edit = false;

        public CP_Proveedores_Datos()
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
                        objectCN.insertProvider(txtBusinessName.Text, txtName.Text, txtPhone.Text, txtEmail.Text);
                        MessageBox.Show("Se han insertados los datos correctamente");
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
                        objectCN.updateProvider(txtID.Text, txtBusinessName.Text, txtName.Text, txtPhone.Text, txtEmail.Text);
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
            if(txtID.Text != "")
            {
                try
                {
                    objectCN.deleteProvider(txtID.Text);
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
            this.txtBusinessName.Clear();
            this.txtName.Clear();
            this.txtPhone.Clear();
            this.txtEmail.Clear();
        }

        private bool validEmpty()
        {
            bool empty = false;
            if(txtBusinessName.Text != "" && txtName.Text != "" && txtPhone.Text != "" && txtEmail.Text != "")
            {
                empty = true;
            }
            return empty;
        }
    }
}
