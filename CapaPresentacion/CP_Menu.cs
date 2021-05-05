using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class CP_Menu : Form
    {
        public CP_Menu()
        {
            InitializeComponent();
        }

        private void openChildForm(object childForm)
        {
            if (this.panelChild.Controls.Count > 0)
            {
                this.panelChild.Controls.RemoveAt(0);
            }
            Form fr = childForm as Form;
            fr.TopLevel = false;
            this.panelChild.Controls.Add(fr);
            this.panelChild.Tag = fr;
            fr.Show();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            openChildForm(new CP_Productos());
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            openChildForm(new CP_Clientes());
        }

        private void btnProviders_Click(object sender, EventArgs e)
        {
            openChildForm(new CP_Proveedores());
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            openChildForm(new CP_Ventas());
        }

        private void btnEarnings_Click(object sender, EventArgs e)
        {
            openChildForm(new CP_Ingresos());
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            openChildForm(new CP_Empleados());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelBar_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
