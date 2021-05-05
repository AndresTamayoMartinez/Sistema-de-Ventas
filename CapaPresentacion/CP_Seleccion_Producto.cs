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
    public partial class CP_Seleccion_Producto : Form
    {
        public string Frame;

        public CP_Seleccion_Producto()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtProductName.Text != "")
                {
                    CN_Productos objectCN = new CN_Productos();
                    this.dgvShowProducts.DataSource = objectCN.searchProduct(txtProductName.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error:\n" + ex);
            }
        }

        private void dgvShowProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Frame == "Ingreso")
            {
                CP_Ingresos_Productos frm = Owner as CP_Ingresos_Productos;
                frm.txtID.Text = dgvShowProducts.CurrentRow.Cells[0].Value.ToString();
                frm.txtName.Text = dgvShowProducts.CurrentRow.Cells[1].Value.ToString();
                this.Close();
            }
            else if (Frame == "Venta")
            {
                CP_Ventas_Productos frm = Owner as CP_Ventas_Productos;
                frm.txtID.Text    = dgvShowProducts.CurrentRow.Cells[0].Value.ToString();
                frm.txtName.Text  = dgvShowProducts.CurrentRow.Cells[1].Value.ToString();
                frm.initialStock  = Convert.ToDouble(dgvShowProducts.CurrentRow.Cells[5].Value.ToString());
                frm.lblPrice.Text = dgvShowProducts.CurrentRow.Cells[6].Value.ToString();
                this.Close();
            }
        }
    }
}
