using Avengers.Dominio;
using Avengers.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avengers.Presentacion.Invoices
{
    public partial class viewInvoice : Form
    {
        private String idioma;
        private User u;
        public viewInvoice(String idioma,User u)
        {
            this.idioma = idioma;
            this.u = u;
            //dtpDate.Enabled = chkDate.Checked;
            InitializeComponent();
            InitDGV("");
  

        }

        public void InitDGV(string cond)
        {
            String sql = "select idinvoice, date_invoice, refcustomer,(c.name|| ' '|| c.surname) Customer, "
                        +"net_amount, amount from invoices inner join customers c on c.idcustomer=refcustomer ";
            String order = " order by idinvoice desc";
            dgvInvoice.Columns.Clear();
            Dominio.Invoices i = new Dominio.Invoices();
            //Console.WriteLine(sql+cond+order);
            i.getGestor().readInDB(sql + cond +order);

            DataTable tInvoice = i.getGestor().getInvoices();

            dgvInvoice.Columns.Add("idinvoice", "ID");
            dgvInvoice.Columns.Add("date_invoice", "DATE INVOICE");
            dgvInvoice.Columns.Add("refcustomer", "IDCUSTOMER");
            dgvInvoice.Columns.Add("customer", "CUSTOMER");
            dgvInvoice.Columns.Add("net_amount", "NET AMOUNT");
            dgvInvoice.Columns.Add("amount", "AMOUNT");

            foreach (DataRow row in tInvoice.Rows)
            {
                dgvInvoice.Rows.Add(row["IDINVOICE"], row["DATE_INVOICE"], row["REFCUSTOMER"], row["CUSTOMER"], row["NET_AMOUNT"], row["AMOUNT"]);
            }
            dgvInvoice.Columns["IDINVOICE"].Visible = false;
            dgvInvoice.Columns["REFCUSTOMER"].Visible = false;

            dgvInvoice.ClearSelection();

        }
        private void filtrar()
        {
            String query = " where 1=1 ";

            if (dtpDate.Enabled)
            {
                query += " And date_invoice = to_date('" + dtpDate.Text.Replace("'", "") + "','dd/MM/yyyy')";
                
            }
            if (!String.IsNullOrEmpty(txtCustomerName.Text.Replace("'", "")))
            {
                query += " And refcustomer in (select idcustomer from customers where upper(name) like '%" + txtCustomerName.Text.Replace("'", "").ToUpper() + "%')";

            }
            if (!String.IsNullOrEmpty(txtCustomerSurname.Text.Replace("'", "")))
            {
                query += " And refcustomer in (select idcustomer from customers where upper(surname) like '%" + txtCustomerSurname.Text.Replace("'", "").ToUpper() + "%')";
            }
            if(!String.IsNullOrEmpty(txtAmount.Text.Replace("'", "")))
            {
                query += " and Amount like '" + txtAmount.Text.ToString().Replace("'","").Replace(".",",") + "%'";
                
            }
            Console.WriteLine(query);
            InitDGV(query);
        }
        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpDate.Enabled = chkDate.Checked;
            filtrar();
          
        }

        private void txtCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar();
        }
        private void txtCustomerName_Click(object sender, EventArgs e)
        {
            this.txtCustomerSurname.Clear();
            filtrar();
        }

        private void txtCustomerSurname_Click(object sender, EventArgs e)
        {
            this.txtCustomerName.Clear();
            filtrar();
        }

        private void txtCustomerSurname_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar();
        }

        private void nudAmount_ValueChanged(object sender, EventArgs e)
        {
            filtrar();
        }
        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar();
        }
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewInvoices ni = new NewInvoices(this.idioma,this.u);
            ni.ShowDialog();
            if (ni.IsDisposed)
            {
                InitDGV("");
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            try
            {
                String id = dgvInvoice.Rows[dgvInvoice.CurrentRow.Index].Cells[0].Value.ToString();
                if (isLastInvoice(id))
                {
                    Dominio.DtoInvoice invoice = new DtoInvoice(
                    dgvInvoice.Rows[dgvInvoice.CurrentRow.Index].Cells[0].Value.ToString(),
                    dgvInvoice.Rows[dgvInvoice.CurrentRow.Index].Cells[1].Value.ToString(),
                    dgvInvoice.Rows[dgvInvoice.CurrentRow.Index].Cells[2].Value.ToString(),
                    dgvInvoice.Rows[dgvInvoice.CurrentRow.Index].Cells[4].Value.ToString(),
                    dgvInvoice.Rows[dgvInvoice.CurrentRow.Index].Cells[5].Value.ToString());


                    ModInvoice mi = new ModInvoice(invoice, this.idioma, this.u);
                    mi.ShowDialog();
                    if (mi.IsDisposed)
                    {
                        InitDGV("");
                    }

                }
                else
                {

                        MessageBox.Show((this.idioma == "ESPAÑOL")?"Solo se puede Modificar la ultima factura": "You only can modify the last Invoice");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show((this.idioma == "ESPAÑOL")?"Debes seleccionar una Factura": "You must Select a Invoice");


            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            this.txtAmount.Clear();
            this.txtCustomerName.Clear();
            this.txtCustomerSurname.Clear();
            this.dtpDate.Value = DateTime.Today;
            this.chkDate.Checked = false;
            filtrar();
        }

        private void Invoices_Shown (object sender, EventArgs e)
        {
            dgvInvoice.ClearSelection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                String id = dgvInvoice.Rows[dgvInvoice.CurrentRow.Index].Cells[0].Value.ToString();
                if (isLastInvoice(id))
                {
                    if (this.idioma == "ESPAÑOL")
                    {
                        if (MessageBox.Show("¿Quieres eliminar a esta Factura?", "Eliminar Factura", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            DeleteInvoice(id);
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Do you want Delete this Invoice?", "Delete Invoice", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            DeleteInvoice(id);
                        }
                    }
                    InitDGV("");
                }
                else
                {
                        MessageBox.Show((this.idioma == "ESPAÑOL")?"Solo se puede Eliminar la ultima factura": "You only can delete the last Invoice");
                }

        }
            catch (Exception ex)
            {

                    MessageBox.Show((this.idioma == "ESPAÑOL")?"Debes seleccionar una Factura": "You must Select a Invoice");


            }
        }
        private bool isLastInvoice(String idInvoice)
        {
            String last = GestorInvoices.getUnString("Select Max(idinvoice) from invoices");
            return last.Equals(idInvoice);
        }
        private void DeleteInvoice(String id)
        {
            //borrado en Order Invoices
            GestorInvoices.deleteInvoice("Delete from Orders_Invoices where refinvoice = '" + id + "' ");
            //borrador en Invoices_products
            GestorInvoices.deleteInvoice("Delete from Invoices_Products where refinvoice='" + id + "' ");
            //borrado en Lines
            GestorInvoices.deleteInvoice("Delete from Lines where refinvoice='" + id + "' ");
            //Borrado en invoices
            GestorInvoices.deleteInvoice("Delete from Invoices where idinvoice= '" + id + "' ");
        }
    }
}
