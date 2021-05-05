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
    public partial class CP_Seleccion_Cliente : Form
    {
        public string Frame;
        public CP_Seleccion_Cliente()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtEmployeeName.Text != "")
                {
                    CN_Cliente objectCN = new CN_Cliente();
                    this.dgvShowProducts.DataSource = objectCN.searchClient(txtEmployeeName.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error:\n" + ex);
            }
        }

        private void dgvShowProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Frame == "Venta")
            {
                CP_Ventas_Nuevo frm = Owner as CP_Ventas_Nuevo;
                frm.txtClientID.Text = dgvShowProducts.CurrentRow.Cells[0].Value.ToString();
                frm.txtClientName.Text = dgvShowProducts.CurrentRow.Cells[1].Value.ToString();
                this.Close();
            }
        }
    }
}
