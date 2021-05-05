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
    public partial class CP_Clientes : Form
    {
        private Form activeForm = null;

        public CP_Clientes()
        {
            InitializeComponent();
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

        private void btnShow_Click(object sender, EventArgs e)
        {
            panelChild.Visible = true;
            openChildForm(new CP_Clientes_Mostrar());
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            panelChild.Visible = true;
            openChildForm(new CP_Clientes_Datos());
        }

        private void CP_Clientes_Load(object sender, EventArgs e)
        {
            this.panelChild.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
