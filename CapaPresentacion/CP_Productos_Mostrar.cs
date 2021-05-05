using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class CP_Productos_Mostrar : Form
    {
        public CP_Productos_Mostrar()
        {
            InitializeComponent();
        }

        private void CD_Productos_Mostrar_Load(object sender, EventArgs e)
        {
            showProducts();
            this.panelChild.Visible = false;
        }

        private void showProducts()
        {
            try
            {
                CN_Productos objectCN = new CN_Productos();
                this.dgvShowProducts.DataSource = objectCN.showProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error:\n" + ex);
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text != "")
                {
                    CN_Productos objectCN = new CN_Productos();
                    this.dgvShowProducts.DataSource = objectCN.searchProduct(txtName.Text);
                }
                else
                {   
                    showProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error:\n" + ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvShowProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.label2.Visible = false;
            CP_Productos_Datos fr   = new CP_Productos_Datos();
            fr.txtID.Text           = dgvShowProducts.CurrentRow.Cells[0].Value.ToString();
            fr.txtName.Text         = dgvShowProducts.CurrentRow.Cells[1].Value.ToString();
            fr.txtDescription.Text  = dgvShowProducts.CurrentRow.Cells[2].Value.ToString();
            fr.txtCategori.Text     = dgvShowProducts.CurrentRow.Cells[3].Value.ToString();
            fr.txtPresentation.Text = dgvShowProducts.CurrentRow.Cells[4].Value.ToString();
            fr.txtStock.Text        = dgvShowProducts.CurrentRow.Cells[5].Value.ToString();
            fr.txtPrice.Text        = dgvShowProducts.CurrentRow.Cells[6].Value.ToString();
            fr.edit = true;
            fr.TopLevel = false;
            this.panelChild.Visible = true;
            this.panelChild.Controls.Add(fr);
            this.panelChild.Tag = fr;
            fr.Show();
        }
    }
}
