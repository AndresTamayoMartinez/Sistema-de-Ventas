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
    public partial class CP_Clientes_Mostrar : Form
    {
        public CP_Clientes_Mostrar()
        {
            InitializeComponent();
        }

        private void CP_Clientes_Mostrar_Load(object sender, EventArgs e)
        {
            showProducts();
            this.panelChild.Visible = false;
        }

        private void showProducts()
        {
            try
            {
                CN_Cliente objectCN = new CN_Cliente();
                this.dgvShowProducts.DataSource = objectCN.showClient();
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
                    CN_Cliente objectCN = new CN_Cliente();
                    this.dgvShowProducts.DataSource = objectCN.searchClient(txtName.Text);
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

        private void dgvShowProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CP_Clientes_Datos fr = new CP_Clientes_Datos();
            fr.txtID.Text        = dgvShowProducts.CurrentRow.Cells[0].Value.ToString();
            fr.txtName.Text      = dgvShowProducts.CurrentRow.Cells[1].Value.ToString();
            fr.txtLastname.Text  = dgvShowProducts.CurrentRow.Cells[2].Value.ToString();
            fr.txtStreet.Text    = dgvShowProducts.CurrentRow.Cells[3].Value.ToString();
            fr.txtSuburb.Text    = dgvShowProducts.CurrentRow.Cells[4].Value.ToString();
            fr.txtCity.Text      = dgvShowProducts.CurrentRow.Cells[5].Value.ToString();
            fr.txtPhone.Text     = dgvShowProducts.CurrentRow.Cells[6].Value.ToString();
            fr.txtEmail.Text     = dgvShowProducts.CurrentRow.Cells[7].Value.ToString();
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
