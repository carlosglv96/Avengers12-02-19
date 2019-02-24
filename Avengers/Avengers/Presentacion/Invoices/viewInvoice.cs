using Avengers.Dominio;
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

            if (dtpDate.Enabled=true)
            {
                query += " And date_invoice = to_date('" + dtpDate.Text + "','dd/MM/yyyy') ";
            }
            if (!String.IsNullOrEmpty(txtCustomer.Text.Replace("'", "")))
            {
                query += " And refcustomer= (select idcustomer from customers where upper(name) like '%" + txtCustomer.Text.Replace("'", "").ToUpper() + "%'"
                    + " or upper(surname)='%" + txtCustomer.Text.Replace("'", "").ToUpper() + "%'";
            }
            if (nudAmount.Value != 0)
            {
                query += " and Amount like '%" + nudAmount.Value + "%'";
            }
            
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

        private void nudAmount_ValueChanged(object sender, EventArgs e)
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
                Dominio.DtoInvoice invoice = new DtoInvoice(
                    dgvInvoice.Rows[dgvInvoice.CurrentRow.Index].Cells[0].Value.ToString(),
                    dgvInvoice.Rows[dgvInvoice.CurrentRow.Index].Cells[1].Value.ToString(),
                    dgvInvoice.Rows[dgvInvoice.CurrentRow.Index].Cells[2].Value.ToString(),
                    dgvInvoice.Rows[dgvInvoice.CurrentRow.Index].Cells[4].Value.ToString(),
                    dgvInvoice.Rows[dgvInvoice.CurrentRow.Index].Cells[5].Value.ToString());

                
                ModInvoice mi = new ModInvoice(invoice, this.idioma,this.u);
                mi.Show();
                if (mi.IsDisposed)
                {
                    InitDGV("");
                }
            }
            catch (Exception ex)
            {
               if (this.idioma == "ESPAÑOL")
                {
                    MessageBox.Show("Debes seleccionar una Factura");
                }
                else
                {
                    MessageBox.Show("You must Select a Invoice");
                }

            }
        }
    }
}
