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
    public partial class CP_Reporte_Nota : Form
    {
        public int id_sale;

        public CP_Reporte_Nota()
        {
            InitializeComponent();
        }

        private void CP_Reporte_Nota_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DS_Nota.sp_nota' Puede moverla o quitarla según sea necesario.
            this.sp_notaTableAdapter.Fill(this.DS_Nota.sp_nota, id_sale);

            // TODO: esta línea de código carga datos en la tabla 'DS_Nota.sp_nota_productos' Puede moverla o quitarla según sea necesario.
            this.sp_nota_productosTableAdapter.Fill(this.DS_Nota.sp_nota_productos, id_sale);

            this.reportViewer1.RefreshReport();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
