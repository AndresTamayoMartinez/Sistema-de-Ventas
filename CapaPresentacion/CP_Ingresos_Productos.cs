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
    public partial class CP_Ingresos_Productos : Form
    {
        CN_Ingreso objectCN = new CN_Ingreso();
        CN_Productos objectCNP = new CN_Productos();
        public bool edit = false, old = false;
        public string id_provider, date;
        public double total;
        double sub, stock, amount;

        public CP_Ingresos_Productos()
        {
            InitializeComponent();
        }

        private void CP_Ingresos_Productos_Load(object sender, EventArgs e)
        {
            if (old == true)
            {
                show();
                lblTotal.Text = "Total: " + total;
            }
            else
            {
                lblNumber.Text = objectCN.searchID(id_provider, date);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validEmpty() == true)
            {
                if (edit == false)
                {
                    try
                    {
                        double subtotal = Convert.ToDouble(this.txtAmount.Text) * Convert.ToDouble(this.txtPucharsePrice.Text);
                        objectCN.insertDetEntry(lblNumber.Text, txtID.Text, txtPucharsePrice.Text, txtSalePrice.Text, txtAmount.Text, subtotal);
                        stock = objectCNP.searchStock(txtID.Text) + Convert.ToDouble(txtAmount.Text);
                        objectCNP.updateStock(txtID.Text, stock);
                        objectCNP.updatePrice(txtID.Text, txtSalePrice.Text);
                        total += subtotal;
                        lblTotal.Text = "Total: " + total;
                        edit = false;
                        txtClear();
                        show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error:\n" + ex);
                    }
                }
                else
                {
                    try
                    {
                        sub = Convert.ToDouble(lblSubtotal.Text);
                        double subtotal = Convert.ToDouble(this.txtAmount.Text) * Convert.ToDouble(this.txtPucharsePrice.Text);
                        objectCN.updateDetEntry(lblNumber.Text, txtID.Text, txtPucharsePrice.Text, txtSalePrice.Text, txtAmount.Text, subtotal);
                        stock = Convert.ToDouble(txtAmount.Text) - amount;
                        stock += objectCNP.searchStock(txtID.Text);
                        objectCNP.updateStock(txtID.Text, stock);
                        objectCNP.updatePrice(txtID.Text, txtSalePrice.Text);
                        total -= sub;
                        total += subtotal;
                        lblTotal.Text = "Total: " + total;
                        edit = false;
                        txtClear();
                        show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ha ocurrido un error:\n" + ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Faltan algunos campos de llenar");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                sub = Convert.ToDouble(lblSubtotal.Text);
                total -= sub;
                lblTotal.Text = "Total: " + total;
                objectCN.deleteDetEntry(lblNumber.Text, txtID.Text);
                stock = objectCNP.searchStock(txtID.Text) - Convert.ToDouble(txtAmount.Text);
                objectCNP.updateStock(txtID.Text, stock);
                edit = false;
                txtClear();
                show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error:\n" + ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                objectCN.updateTotal(lblNumber.Text, total);
                MessageBox.Show("Se han registrado los datos correctamente");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error:\n" + ex);
            }
        }

        private void show()
        {
            try
            {
                CN_Ingreso objectC = new CN_Ingreso();
                this.dgvShowProducts.DataSource = objectC.showDetEntry(lblNumber.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error:\n" + ex);
            }
        }

        private void dgvShowProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            edit = true;
            this.txtID.Text            = dgvShowProducts.CurrentRow.Cells[0].Value.ToString();
            this.txtName.Text          = dgvShowProducts.CurrentRow.Cells[1].Value.ToString();
            this.txtPucharsePrice.Text = dgvShowProducts.CurrentRow.Cells[2].Value.ToString();
            this.txtSalePrice.Text     = dgvShowProducts.CurrentRow.Cells[3].Value.ToString();
            this.txtAmount.Text        = dgvShowProducts.CurrentRow.Cells[4].Value.ToString();
            lblSubtotal.Text           = dgvShowProducts.CurrentRow.Cells[5].Value.ToString();
            amount   = Convert.ToDouble(dgvShowProducts.CurrentRow.Cells[4].Value.ToString());
        }

        private void btnProductSearch_Click(object sender, EventArgs e)
        {
            CP_Seleccion_Producto frm = new CP_Seleccion_Producto();
            AddOwnedForm(frm);
            frm.Frame = "Ingreso";
            frm.Show();
        }

        private void txtClear()
        {
            this.txtID.Clear();
            this.txtName.Clear();
            this.txtPucharsePrice.Clear();
            this.txtSalePrice.Clear();
            this.txtAmount.Clear();
        }

        private bool validEmpty()
        {
            bool empty = false;
            if (txtID.Text != "" && txtName.Text != "" && txtPucharsePrice.Text != "" && txtSalePrice.Text != "" 
                && txtAmount.Text != "")
            {
                empty = true;
            }
            return empty;
        }
    }
}
