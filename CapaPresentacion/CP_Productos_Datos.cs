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
    public partial class CP_Productos_Datos : Form
    {

        CN_Productos objectCN = new CN_Productos();
        public bool edit = false;

        public CP_Productos_Datos()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(validEmpty() == true)
            {
                if (edit == false)
                {
                    try
                    {
                        objectCN.insertProduct(txtName.Text, txtDescription.Text, txtCategori.Text, txtPresentation.Text, txtStock.Text, txtPrice.Text);
                        MessageBox.Show("Se han registrado los datos correctamente");
                        txtClear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudieron insertar los datos.\nError:\n" + ex);
                    }
                }
                else
                {
                    try
                    {
                        objectCN.updateProduct(txtID.Text, txtName.Text, txtDescription.Text, txtCategori.Text, txtPresentation.Text, txtStock.Text, txtPrice.Text);
                        MessageBox.Show("Se han actualizado los datos correctamente");
                        txtClear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudieron insertar los datos.\nError:\n" + ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Faltan algunos campos de llenar");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                try
                {
                    objectCN.deleteProducto(txtID.Text);
                    MessageBox.Show("Se han eliminado los datos correctamente");
                    txtClear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudieron eliminar los datos.\nError:\n" + ex);
                }
            }
        }

        private void txtClear()
        {
            this.txtID.Clear();
            this.txtName.Clear();
            this.txtDescription.Clear();
            this.txtCategori.Clear();
            this.txtPresentation.Clear();
            this.txtStock.Clear();
            this.txtPrice.Clear();
        }

        private bool validEmpty()
        {
            bool empty = false;
            if(txtName.Text != "" && txtDescription.Text != "" && txtCategori.Text != "" 
                && txtPresentation.Text != "" && txtStock.Text != "" && txtPrice.Text != "")
            {
                empty = true;
            }
            return empty;
        }
    }
}
