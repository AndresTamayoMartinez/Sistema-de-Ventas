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
    public partial class CP_Seleccion_Proveedor : Form
    {
        public CP_Seleccion_Proveedor()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProviderName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtProviderName.Text != "")
                {
                    CN_Proveedor objectCN = new CN_Proveedor();
                    this.dgvShowProducts.DataSource = objectCN.searchProvider(txtProviderName.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error:\n" + ex);
            }
        }

        private void dgvShowProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CP_Ingresos_Nuevo frm    = Owner as CP_Ingresos_Nuevo;
            frm.txtProviderID.Text   = dgvShowProducts.CurrentRow.Cells[0].Value.ToString();
            frm.txtProviderName.Text = dgvShowProducts.CurrentRow.Cells[1].Value.ToString();
            this.Close();
        }
    }
}
