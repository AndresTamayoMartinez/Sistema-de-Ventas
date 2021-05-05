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
    public partial class CP_Clientes_Datos : Form
    {
        CN_Cliente objectCN = new CN_Cliente();
        public bool edit = false;

        public CP_Clientes_Datos()
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
                        objectCN.insertClient(txtName.Text, txtLastname.Text, txtStreet.Text, txtSuburb.Text, txtCity.Text, txtPhone.Text, txtEmail.Text);
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
                        objectCN.updateClient(txtID.Text, txtName.Text, txtLastname.Text, txtStreet.Text, txtSuburb.Text, txtCity.Text, txtPhone.Text, txtEmail.Text);
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
                MessageBox.Show("Algunos campos no han sido llenados");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(txtID.Text != "")
            {
                try
                {
                    objectCN.deleteClient(txtID.Text);
                    MessageBox.Show("Se han eliminado los datos correctamente.");
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
            this.txtStreet.Clear();
            this.txtSuburb.Clear();
            this.txtCity.Clear();
            this.txtPhone.Clear();
            this.txtEmail.Clear();
        }

        private bool validEmpty()
        {
            bool empty = false;
            if(txtName.Text != "" && txtLastname.Text != "" && txtStreet.Text != "" && txtSuburb.Text != "" 
                && txtCity.Text != "" && txtPhone.Text != "" && txtEmail.Text != "" )
            {
                empty = true;
            }
            return empty;
        }
    }
}
