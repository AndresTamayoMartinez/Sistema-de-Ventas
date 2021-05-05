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
    public partial class CP_Seleccion_Empleado : Form
    {
        public string Frame;
        public CP_Seleccion_Empleado()
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
                    CN_Empleados objectCN = new CN_Empleados();
                    this.dgvShowProducts.DataSource = objectCN.searchEmployee(txtEmployeeName.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error:\n" + ex);
            }
        }

        private void dgvShowProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(Frame == "Ingreso")
            {
                //CP_Ingresos_Nuevo frm = Owner as CP_Ingresos_Nuevo;
                //frm.txtEmployeeID.Text = dgvShowProducts.CurrentRow.Cells[0].Value.ToString();
                //frm.txtEmployeeName.Text = dgvShowProducts.CurrentRow.Cells[1].Value.ToString();
                //this.Close();
            }
            if (Frame == "Venta")
            {
                CP_Ventas_Nuevo frm = Owner as CP_Ventas_Nuevo;
                frm.txtEmployeeID.Text = dgvShowProducts.CurrentRow.Cells[0].Value.ToString();
                frm.txtEmployeeName.Text = dgvShowProducts.CurrentRow.Cells[1].Value.ToString();
                this.Close();
            }
        }
    }
}
