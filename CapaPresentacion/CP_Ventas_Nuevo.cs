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
    public partial class CP_Ventas_Nuevo : Form
    {
        private Form activeForm = null;

        public CP_Ventas_Nuevo()
        {
            InitializeComponent();
        }

        private void CP_Ventas_Nuevo_Load(object sender, EventArgs e)
        {
            this.panelChild.Visible = false;
            dtpDate.Value = DateTime.Now;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            CP_Seleccion_Cliente frm = new CP_Seleccion_Cliente();
            AddOwnedForm(frm);
            frm.Frame = "Venta";
            frm.Show();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            CP_Seleccion_Empleado frm = new CP_Seleccion_Empleado();
            AddOwnedForm(frm);
            frm.Frame = "Venta";
            frm.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(validEmpty() == true)
            {
                try
                {
                    dtpDate.Refresh();
                    dtpDate.Format = DateTimePickerFormat.Custom;
                    dtpDate.CustomFormat = "dd/MM/yy HH:mm:ss tt";
                    dtpDate.Value = DateTime.Now;
                    CN_Ventas objectCN = new CN_Ventas();
                    objectCN.insertSales(txtClientID.Text, txtEmployeeID.Text, dtpDate.Value.ToString(), 0, 0, 0);
                    this.panelChild.Visible = true;
                    openChildForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error.\nError:\n" + ex);
                }
            }
            else
            {
                MessageBox.Show("Algunos campos no han sido llenados");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openChildForm()
        {
            CP_Ventas_Productos frm = new CP_Ventas_Productos();
            frm.id_client = txtClientID.Text;
            frm.date = dtpDate.Value.ToString();
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = frm;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelChild.Controls.Add(frm);
            panelChild.Tag = frm;
            frm.BringToFront();
            frm.Show();
        }

        private bool validEmpty()
        {
            bool valid = false;
            if(txtClientID.Text != "" && txtClientName.Text != "" && txtEmployeeID.Text != "" && txtEmployeeName.Text != "")
            {
                valid = true;
            }
            return valid;
        }
    }
}
