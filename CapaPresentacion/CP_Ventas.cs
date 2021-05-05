using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class CP_Ventas : Form
    {
        Form activeForm = null;

        public CP_Ventas()
        {
            InitializeComponent();
        }

        private void CP_Ventas_Load(object sender, EventArgs e)
        {
            this.panelChild.Visible = false;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            CP_Ventas_Mostrar frm = new CP_Ventas_Mostrar();
            panelChild.Visible = true;
            openChildForm(frm);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            CP_Ventas_Nuevo frm = new CP_Ventas_Nuevo();
            panelChild.Visible = true;
            openChildForm(frm);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChild.Controls.Add(childForm);
            panelChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}
