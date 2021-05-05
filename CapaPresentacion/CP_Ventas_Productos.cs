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
    public partial class CP_Ventas_Productos : Form
    {
        CN_Ventas objectCN = new CN_Ventas();
        CN_Productos objectCNP = new CN_Productos();
        public double initialStock, total=0;
        public bool old = false, edit = false;
        public string id_client, date;
        double subtotal, stock, amount, abono;

        public CP_Ventas_Productos()
        {
            InitializeComponent();
        }

        private void CP_Ventas_Productos_Load(object sender, EventArgs e)
        {
            if(old == true)
            {
                show();
                lblTotal.Text = "Total: " + total;
            }
            else
            {
                lblNumber.Text = objectCN.searchID(id_client, date);
            }
        }

        private void btnProductSearch_Click(object sender, EventArgs e)
        {
            CP_Seleccion_Producto frm = new CP_Seleccion_Producto();
            AddOwnedForm(frm);
            frm.Frame = "Venta";
            frm.Show();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(validEmpty() == true)
            {
                if (edit == false)
                {
                    try
                    {
                        subtotal = Convert.ToDouble(txtAmount.Text) * Convert.ToDouble(txtPrice.Text);
                        stock = initialStock - Convert.ToDouble(txtAmount.Text);
                        total += subtotal;
                        objectCN.insertDetSales(lblNumber.Text, txtID.Text, txtAmount.Text, txtPrice.Text, subtotal);
                        objectCNP.updateStock(txtID.Text, stock);
                        lblTotal.Text = "Total: " + total;
                        edit = false;
                        txtClrear();
                        show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error.\nError:" + ex);
                    }
                }
                else
                {
                    try
                    {
                        subtotal = Convert.ToDouble(txtAmount.Text) * Convert.ToDouble(txtPrice.Text);
                        initialStock = amount - Convert.ToDouble(txtAmount.Text);
                        stock = objectCNP.searchStock(txtID.Text) + initialStock;
                        objectCN.updateDetSales(lblNumber.Text, txtID.Text, txtAmount.Text, txtPrice.Text, subtotal);
                        subtotal -= Convert.ToDouble(lblSubtotal.Text);
                        total = total + subtotal;
                        objectCNP.updateStock(txtID.Text, stock);
                        lblTotal.Text = "Total: " + total;
                        edit = false;
                        txtClrear();
                        show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error.\nError:" + ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Faltan algunos campos de llenar");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            CP_Reporte_Nota report = new CP_Reporte_Nota();
            report.id_sale = Convert.ToInt32(lblNumber.Text);
            report.Show();
        }

        private void txtDelete_Click(object sender, EventArgs e)
        {
            try
            {
                total = total - Convert.ToDouble(lblSubtotal.Text);
                stock = objectCNP.searchStock(txtID.Text) + amount;
                objectCN.deleteDetSales(lblNumber.Text, txtID.Text);
                objectCNP.updateStock(txtID.Text, stock);
                lblTotal.Text = "Total: " + total;
                edit = false;
                txtClrear();
                show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error.\nError:" + ex);
            }
        }

        private void dgvShowProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text       = dgvShowProducts.CurrentRow.Cells[0].Value.ToString();
            txtName.Text     = dgvShowProducts.CurrentRow.Cells[1].Value.ToString();
            txtAmount.Text   = dgvShowProducts.CurrentRow.Cells[2].Value.ToString();
            amount = Convert.ToDouble(dgvShowProducts.CurrentRow.Cells[2].Value.ToString());
            txtPrice.Text    = dgvShowProducts.CurrentRow.Cells[3].Value.ToString();
            lblSubtotal.Text = dgvShowProducts.CurrentRow.Cells[4].Value.ToString();
            edit = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                subtotal = total;
                abono = Convert.ToDouble(txtCuenta.Text);
                total = subtotal - abono;
                objectCN.updateTotal(lblNumber.Text,subtotal, abono, total);
                MessageBox.Show("Se han guardado los datos correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error.\nError:" + ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void show()
        {
            try
            {
                CN_Ventas objectC = new CN_Ventas();
                this.dgvShowProducts.DataSource = objectC.showDetSales(lblNumber.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error.\nError:" + ex);
            }
        }

        private void txtClrear()
        {
            this.txtID.Clear();
            this.txtName.Clear();
            this.txtAmount.Clear();
            this.txtPrice.Clear();
        }

        private bool validEmpty()
        {
            bool empty = false;
            if(txtID.Text != "" && txtName.Text != "" && txtAmount.Text != "" && txtPrice.Text != "" && txtCuenta.Text != "")
            {
                empty = true;
            }
            return empty;
        }
    }
}
