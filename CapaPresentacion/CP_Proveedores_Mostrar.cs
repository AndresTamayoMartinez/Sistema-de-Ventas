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
    public partial class CP_Proveedores_Mostrar : Form
    {
        public CP_Proveedores_Mostrar()
        {
            InitializeComponent();
        }

        private void CP_Proveedores_Mostrar_Load(object sender, EventArgs e)
        {
            this.panelChild.Visible = false;
            showProviders();
        }

        private void showProviders()
        {
            try
            {
                CN_Proveedor objectCN = new CN_Proveedor();
                this.dgvShowProducts.DataSource = objectCN.showProvider();
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
                    CN_Proveedor objectCN = new CN_Proveedor();
                    this.dgvShowProducts.DataSource = objectCN.searchProvider(txtName.Text);
                }
                else
                {
                    showProviders();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error:\n" + ex);
            }
        }

        private void dgvShowProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CP_Proveedores_Datos fr = new CP_Proveedores_Datos();
            fr.txtID.Text = dgvShowProducts.CurrentRow.Cells[0].Value.ToString();
            fr.txtBusinessName.Text = dgvShowProducts.CurrentRow.Cells[1].Value.ToString();
            fr.txtName.Text = dgvShowProducts.CurrentRow.Cells[2].Value.ToString();
            fr.txtPhone.Text = dgvShowProducts.CurrentRow.Cells[3].Value.ToString();
            fr.txtEmail.Text = dgvShowProducts.CurrentRow.Cells[4].Value.ToString();
            fr.edit = true;
            fr.TopLevel = false;
            this.panelChild.Visible = true;
            this.panelChild.Controls.Add(fr);
            this.panelChild.Tag = fr;
            fr.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    
}
