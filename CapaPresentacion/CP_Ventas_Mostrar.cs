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
    public partial class CP_Ventas_Mostrar : Form
    {
        public CP_Ventas_Mostrar()
        {
            InitializeComponent();
        }

        private void CP_Ventas_Mostrar_Load(object sender, EventArgs e)
        {
            this.panelChild.Visible = false;
            show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (txtName.Text != "")
                //{
                //    CN_Ventas objectCN = new CN_Ventas();
                //    this.dgvShowProducts.DataSource = objectCN.searchID(txtName.Text);
                //}
                //else
                //{
                //    showProducts();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error:\n" + ex);
            }
        }

        private void dgvShowProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CP_Ventas_Productos fr = new CP_Ventas_Productos();
            fr.lblNumber.Text = dgvShowProducts.CurrentRow.Cells[0].Value.ToString();
            fr.txtCuenta.Text = dgvShowProducts.CurrentRow.Cells[5].Value.ToString();
            fr.date = dgvShowProducts.CurrentRow.Cells[3].Value.ToString();
            fr.total = Convert.ToDouble(dgvShowProducts.CurrentRow.Cells[4].Value.ToString());
            fr.old = true;
            fr.TopLevel = false;
            this.panelChild.Visible = true;
            this.panelChild.Controls.Add(fr);
            this.panelChild.Tag = fr;
            fr.Show();
        }

        public void show()
        {
            try
            {
                CN_Ventas objectCN = new CN_Ventas();
                this.dgvShowProducts.DataSource = objectCN.showSales();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error:\n" + ex);
            }
        }
    }
}
