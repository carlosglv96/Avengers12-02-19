﻿using Avengers.Dominio;
using Avengers.Dominio.Gestores;
using Avengers.Presentacion.Orders.PrintInvoOrder;
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
            txBoxPassConta.Enabled = false;
            if (GestorUsers.searchPermit("CONTABLE", u))
            {
                txBoxPassConta.Enabled = true;
            }
            if (this.idioma == "ESPAÑOL")
            {
                idioma_es();
            }
            else
            {
                idioma_en();
            }

        }

        private void idioma_es()
        {
            lblCustomer.Text = Recursos.Espanol.lblCustomer;
            lblCustomerSurname.Text = Recursos.Espanol.lblCustomerSurname;
            lblDate.Text = Recursos.Espanol.lblDate;
            lblAmount.Text = Recursos.Espanol.lblAmount;
            btnClean.Text = Recursos.Espanol.btnClean;
            btnDelete.Text = Recursos.Espanol.btnDelete;
            btnNew.Text = Recursos.Espanol.btnNew;
            btnMod.Text = Recursos.Espanol.btnMod;
            btnShow.Text = Recursos.Espanol.btnShow;
            btnPrint.Text = Recursos.Espanol.btnPrint;
            lblPassConta.Text = "Contraseña:";
        }

        private void idioma_en()
        {
            lblCustomer.Text = Recursos.Ingles.lblCustomer;
            lblCustomerSurname.Text = Recursos.Ingles.lblCustomerSurname;
            lblDate.Text = Recursos.Ingles.lblDate;
            lblAmount.Text = Recursos.Ingles.lblAmount;
            btnClean.Text = Recursos.Ingles.btnClean;
            btnDelete.Text = Recursos.Ingles.btnDelete;
            btnNew.Text = Recursos.Ingles.btnNew;
            btnMod.Text = Recursos.Ingles.btnMod;
            btnShow.Text = Recursos.Ingles.btnShow;
            btnPrint.Text = Recursos.Ingles.btnPrint;
            lblPassConta.Text = "Password:";
        }

        public void InitDGV(string cond)
        {
            String sql = "select idinvoice, date_invoice, refcustomer,(c.name|| ' '|| c.surname) Customer, "
                         + "net_amount, amount, conta from invoices inner join customers c on c.idcustomer=refcustomer ";
            String order = " order by idinvoice desc";
            dgvInvoice.Columns.Clear();
            Dominio.Invoices i = new Dominio.Invoices();
            //Console.WriteLine(sql+cond+order);
            i.getGestor().readInDB(sql + cond +order);

            DataTable tInvoice = i.getGestor().getInvoices();

            if (this.idioma == "INGLES")
            {
                dgvInvoice.Columns.Add("idinvoice", "ID");
                dgvInvoice.Columns.Add("date_invoice", "DATE INVOICE");
                dgvInvoice.Columns.Add("refcustomer", "IDCUSTOMER");
                dgvInvoice.Columns.Add("customer", "CUSTOMER");
                dgvInvoice.Columns.Add("net_amount", "NET AMOUNT");
                dgvInvoice.Columns.Add("amount", "AMOUNT");
                dgvInvoice.Columns.Add("conta", "CONTA");
            }
            else {
                dgvInvoice.Columns.Add("idinvoice", "ID");
                dgvInvoice.Columns.Add("date_invoice", "FECHA FACTURA");
                dgvInvoice.Columns.Add("refcustomer", "IDCLIENTE");
                dgvInvoice.Columns.Add("customer", "CLIENTE");
                dgvInvoice.Columns.Add("net_amount", "CANTIDAD NETA");
                dgvInvoice.Columns.Add("amount", "CANTIDAD");
                dgvInvoice.Columns.Add("conta", "CONTA");
            }
            foreach (DataRow row in tInvoice.Rows)
            {
                dgvInvoice.Rows.Add(row["IDINVOICE"], row["DATE_INVOICE"], row["REFCUSTOMER"], row["CUSTOMER"], row["NET_AMOUNT"], row["AMOUNT"], row["CONTA"]);
            }
            //dgvInvoice.Columns["IDINVOICE"].Visible = false;
            dgvInvoice.Columns["REFCUSTOMER"].Visible = false;
            dgvInvoice.Columns["CONTA"].Visible = false;

           

            dgvInvoice.ClearSelection();
            CellFormat();

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
            //try
            //{
                bool n = dgvInvoice.CurrentRow.Selected;
                if (n)
                {
                    if (dgvInvoice.Rows[dgvInvoice.CurrentRow.Index].Cells[0].Style.BackColor == Color.Green)
                    {
                        MessageBox.Show((this.idioma == "ESPAÑOL") ? "Esta factura se encuentra contabilizada" : "This invoice is posted");
                        dgvInvoice.ClearSelection();
                    }
                    else
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
                            MessageBox.Show((this.idioma == "ESPAÑOL") ? "Solo se puede Modificar la ultima factura" : "You only can modify the last Invoice");
                            dgvInvoice.ClearSelection();
                        }
                    }
                }
                else
                {
                    MessageBox.Show((this.idioma == "ESPAÑOL") ? "Debes seleccionar una Factura" : "You must Select a Invoice");
                    dgvInvoice.ClearSelection();
                }
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show((this.idioma == "ESPAÑOL")?"Debes seleccionar una Factura": "You must Select a Invoice");
            //    dgvInvoice.ClearSelection();

            //}
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
                bool n = dgvInvoice.CurrentRow.Selected;
                if (n)
                {
                    if (dgvInvoice.Rows[dgvInvoice.CurrentRow.Index].Cells[0].Style.BackColor == Color.Green)
                    {
                        MessageBox.Show((this.idioma == "ESPAÑOL") ? "Esta factura se encuentra contabilizada" : "This invoice is posted");
                        dgvInvoice.ClearSelection();
                    }
                    else
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
                            MessageBox.Show((this.idioma == "ESPAÑOL") ? "Solo se puede Eliminar la ultima factura" : "You only can delete the last Invoice");
                            dgvInvoice.ClearSelection();
                        }
                    }
                }else
                {
                    MessageBox.Show((this.idioma == "ESPAÑOL") ? "Debes seleccionar una Factura" : "You must Select a Invoice");
                    dgvInvoice.ClearSelection();
                }
                
            }
            catch (Exception ex)
            {

                    MessageBox.Show((this.idioma == "ESPAÑOL")?"Debes seleccionar una Factura": "You must Select a Invoice");
                dgvInvoice.ClearSelection();
            }
        }
        private bool isLastInvoice(String idInvoice)
        {
            String last = GestorInvoices.getUnString("Select Max(idinvoice) from invoices");
            return last.Equals(idInvoice);
        }
        private void DeleteInvoice(String id)
        {

            //Actualiza orders, la columna de la factura la pone a 0
            Order o = new Dominio.Order();
            String aux = o.getGestor().getUnString("select count(*) from orders_invoices where refinvoice = " + id);
            int n = Int32.Parse(aux);
            if (n > 0)
            {
                aux = o.getGestor().getUnString("select reforder from orders_invoices where refinvoice = " + id);
                int idOrder = Int32.Parse(aux);
                o.getGestor().setData("Update orders set invoiced = 0 where idorder = '" + idOrder + "'");
            }

            //borrado en Order Invoices
            GestorInvoices.deleteInvoice("Delete from Orders_Invoices where refinvoice = '" + id + "' ");
            //borrador en Invoices_products
            GestorInvoices.deleteInvoice("Delete from Invoices_Products where refinvoice='" + id + "' ");
            //borrado en Lines
            GestorInvoices.deleteInvoice("Delete from Lines where refinvoice='" + id + "' ");
            //Borrado en invoices
            GestorInvoices.deleteInvoice("Delete from Invoices where idinvoice= '" + id + "' ");

            


        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Order o = new Dominio.Order();
                int idInvo = Int32.Parse(dgvInvoice.Rows[dgvInvoice.CurrentRow.Index].Cells[0].Value.ToString());
                int refCusto = Int32.Parse(dgvInvoice.Rows[dgvInvoice.CurrentRow.Index].Cells[2].Value.ToString());
                int idOrder;
                int tipoPay = 21;
                String aux = o.getGestor().getUnString("select count(*) from orders_invoices where refinvoice = "+idInvo);
                int n = Int32.Parse(aux);
                if (n > 0)
                {
                    aux = o.getGestor().getUnString("select reforder from orders_invoices where refinvoice = " + idInvo);
                    idOrder = Int32.Parse(aux);
                    aux = o.getGestor().getUnString("select REFPAYMENTMETHOD from orders where idorder = " + idOrder);
                    tipoPay = Int32.Parse(aux);
                }


                generarFactura(refCusto, idInvo, tipoPay);
            }
            catch
            {
                if (this.idioma == "INGLES") { Console.WriteLine("Error, you Must Select a Invoice"); }
                else { Console.WriteLine("Error, debes seleccionar una factura"); }
            }
            
        }

        public void generarFactura(int refCusto, int idInvoice, int refTipo)
        {
            PrintInvo i = new PrintInvo(refCusto, idInvoice, refTipo);
            i.Show();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                DtoInvoice inv=new DtoInvoice(
                    dgvInvoice.Rows[dgvInvoice.CurrentRow.Index].Cells[0].Value.ToString(),
                    dgvInvoice.Rows[dgvInvoice.CurrentRow.Index].Cells[1].Value.ToString(),
                    dgvInvoice.Rows[dgvInvoice.CurrentRow.Index].Cells[2].Value.ToString(),
                    dgvInvoice.Rows[dgvInvoice.CurrentRow.Index].Cells[4].Value.ToString(),
                    dgvInvoice.Rows[dgvInvoice.CurrentRow.Index].Cells[5].Value.ToString());

                showContent sc = new showContent(inv, this.idioma, this.u);
                sc.ShowDialog();
                
                

            }
            catch
            {
                if (this.idioma == "INGLES") { Console.WriteLine("Error, you Must Select a Invoice"); }
                else { Console.WriteLine("Error, debes seleccionar una factura"); }
            }
        }

        private void show(object sender, EventArgs e)
        {
            dgvInvoice.ClearSelection();
        }
        private void CellFormat()
        {
            foreach (DataGridViewRow Myrow in dgvInvoice.Rows)
            {   //Here 2 cell is target value and 1 cell is Volume 
                if (Convert.ToInt32(Myrow.Cells[6].Value) == 1)// Or your condition 
                {
                    Myrow.Cells[0].Style.BackColor = Color.Green;
                }
                else
                {
                    Myrow.Cells[0].Style.BackColor = Color.White;
                }
            }
        }

        private void dobleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.White)
            {
                Order o = new Dominio.Order();
                int id = int.Parse(dgvInvoice.Rows[e.RowIndex].Cells[0].Value.ToString());
                int index = dgvInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex;
                if(index == 0)
                {
                    if (GestorUsers.searchPermit("CONTABLE", u))
                    {
                        String aux = txBoxPassConta.Text;
                        if (aux == "contable")
                        {
                            dgvInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                            dgvInvoice.ClearSelection();
                            o.getGestor().setData("Update invoices set conta = 1 where idinvoice = '" + id + "'");
                        }
                        else
                        {
                            if (this.idioma == "INGLES") { MessageBox.Show("Error, password incorrect"); }
                            else { MessageBox.Show("Error, contraseña incorrecta"); }
                            dgvInvoice.ClearSelection();
                        }
                    }
                    else
                    {
                        if (this.idioma == "INGLES") { MessageBox.Show("Error, this user hasn't got permits"); }
                        else { MessageBox.Show("Error, el usuario no tiene permisos"); }
                        dgvInvoice.ClearSelection();
                    }
                }              
            }
            else
            {
                dgvInvoice.ClearSelection();
            }             
        }
    }
}
