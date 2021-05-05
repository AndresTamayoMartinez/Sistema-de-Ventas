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
    public partial class CP_Productos : Form
    {
        private Form activeForm = null;

        public CP_Productos()
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
            openChildForm(new CP_Productos_Mostrar());

        }

        private void btnData_Click(object sender, EventArgs e)
        {
            panelChild.Visible = true;
            openChildForm(new CP_Productos_Datos());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CP_Productos_Load(object sender, EventArgs e)
        {
            panelChild.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
