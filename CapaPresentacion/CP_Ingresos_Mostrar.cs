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
    public partial class CP_Ingresos_Mostrar : Form
    {
        public CP_Ingresos_Mostrar()
        {
            InitializeComponent();
        }

        private void CP_Ingresos_Mostrar_Load(object sender, EventArgs e)
        {
            this.panelChild.Visible = false;
            show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (txtName.Text != "")
                //{
                //    CN_Ingreso objectCN = new CN_Ingreso();
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
            CP_Ingresos_Productos fr = new CP_Ingresos_Productos();
            fr.lblNumber.Text = dgvShowProducts.CurrentRow.Cells[0].Value.ToString();
            fr.total = Convert.ToDouble(dgvShowProducts.CurrentRow.Cells[3].Value.ToString());
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
                CN_Ingreso objectCN = new CN_Ingreso();
                this.dgvShowProducts.DataSource = objectCN.showEntry();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error:\n" + ex);
            }
        }
    }
}
