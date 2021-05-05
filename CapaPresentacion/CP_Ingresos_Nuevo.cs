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
    public partial class CP_Ingresos_Nuevo : Form
    {
        private Form activeForm = null;

        public CP_Ingresos_Nuevo()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validEmpty() == true)
            {
                try
                {
                    dtpDate.Refresh();
                    dtpDate.Format = DateTimePickerFormat.Custom;
                    dtpDate.CustomFormat = "dd/MM/yy HH:mm:ss tt";
                    dtpDate.Value = DateTime.Now;
                    CN_Ingreso objectCN = new CN_Ingreso();
                    objectCN.insertEntry(txtProviderID.Text, dtpDate.Value.ToString(), 0);
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
                MessageBox.Show("Faltan algunos campos de llenar");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProvider_Click(object sender, EventArgs e)
        {
            CP_Seleccion_Proveedor frm = new CP_Seleccion_Proveedor();
            AddOwnedForm(frm);
            frm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CP_Ingresos_Nuevo_Load(object sender, EventArgs e)
        {
            this.panelChild.Visible = false;
            dtpDate.Value = DateTime.Now;
        }

        private void openChildForm()
        {
            CP_Ingresos_Productos frm = new CP_Ingresos_Productos();
            frm.id_provider = txtProviderID.Text;
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

        private void txtClear()
        {
            this.txtProviderID.Clear();
            this.txtProviderName.Clear();
        }

        private bool validEmpty()
        {
            bool empty = false;
            if(txtProviderID.Text != "" && txtProviderName.Text != "")
            {
                empty = false;
            }
            return empty;
        }
    }
}
