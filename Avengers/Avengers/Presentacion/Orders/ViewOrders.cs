using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Avengers.Dominio;
using Avengers.Dominio.Gestores;

namespace Avengers.Presentacion.Orders
{
    public partial class ViewOrders : Form
    {
        private User u;
        private String idioma;
        String condicion = "SELECT ORDERS.IDORDER,CUSTOMERS.NAME,CUSTOMERS.SURNAME,USUARIO.NAME,ORDERS.DATETIME,PAYMENTMETHODS.PAYMENTMETHOD, ORDERS.TOTAL, ORDERS.CONFIRMED, ORDERS.LABELED, ORDERS.SENT, ORDERS.INVOICED, ORDERS.PREPAID FROM ORDERS INNER JOIN CUSTOMERS ON REFCUSTOMER = IDCUSTOMER INNER JOIN USUARIO ON REFUSER = IDUSER INNER JOIN PAYMENTMETHODS ON REFPAYMENTMETHOD = IDPAYMENTMETHOD ";
        String whereCondition = " Where Orders.Deleted=";
        int iValue;
        String orderby = " ORDER BY ORDERS.DATETIME DESC";
        public ViewOrders(User u,String idioma)
        {
            this.idioma = idioma;
            this.u = u;
            InitializeComponent();
            bool checkValue = chkDeleted.Checked;
            iValue = (checkValue) ? 1 : 0;
            initTable(condicion + whereCondition + iValue + orderby );
            initComboPayment("Where Deleted = 0");          
            if (this.idioma == "ESPAÑOL")
            {
                idioma_es();
                this.Text = "Pedidos";
            }
            else if (this.idioma == "INGLES")
            {
                idioma_en();
                this.Text = "Orders";
            }
        }

        public void idioma_es()
        {
            lblCustomers.Text = Avengers.Recursos.Espanol.lblCustomer;
            lblUser.Text = Avengers.Recursos.Espanol.lblUser;
            lblDate.Text = Avengers.Recursos.Espanol.lblDate;
            lblPay.Text = Avengers.Recursos.Espanol.lblPay;
            ckAct.Text = Avengers.Recursos.Espanol.ckAct;
            chkDeleted.Text = Avengers.Recursos.Espanol.ckDel;
            lblPrepago.Text = Avengers.Recursos.Espanol.lblPrepago;
            btnClean.Text = Avengers.Recursos.Espanol.btnClean;
            btnNew.Text = Avengers.Recursos.Espanol.btnNewUser;
            btnDelete.Text = Avengers.Recursos.Espanol.btnDeleteUser;
            btnModify.Text = Avengers.Recursos.Espanol.btnModUser;
        }
        public void idioma_en()
        {
            lblCustomers.Text = Avengers.Recursos.Ingles.lblCustomer;
            lblUser.Text = Avengers.Recursos.Ingles.lblUser;
            lblDate.Text = Avengers.Recursos.Ingles.lblDate;
            lblPay.Text = Avengers.Recursos.Ingles.lblPay;
            ckAct.Text = Avengers.Recursos.Ingles.ckAct;
            chkDeleted.Text = Avengers.Recursos.Ingles.ckDel;
            lblPrepago.Text = Avengers.Recursos.Ingles.lblPrepago;
            btnClean.Text = Avengers.Recursos.Ingles.btnClean;
            btnNew.Text = Avengers.Recursos.Ingles.btnNewUser;
            btnDelete.Text = Avengers.Recursos.Ingles.btnDeleteUser;
            btnModify.Text = Avengers.Recursos.Ingles.btnModUser;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewOrder o = new NewOrder(u,this.idioma);
            o.ShowDialog();
            if (o.IsDisposed) {
                initTable(condicion + whereCondition + iValue + orderby);
                initComboPayment("Where Deleted = 0");
            }
        }

        private void initTable(String cond)
        {
            
            dgvOrders.Columns.Clear();

            Order o = new Order();
            o.getGestor().readInDB2(cond);


            DataTable torders = o.getGestor().getOrders();
            dgvOrders.Columns.Clear();

            if (this.idioma == "ESPAÑOL")
            {
                dgvOrders.Columns.Add("IDORDER", "ID");
                dgvOrders.Columns.Add("REFCUSTOMER", "NOMBRE CLIENTE");
                dgvOrders.Columns.Add("REFCUSTOMER", "APELLIDO CLIENTE");
                dgvOrders.Columns.Add("REFUSER", "USUARIO");
                dgvOrders.Columns.Add("DATETIME", "FECHA");
                dgvOrders.Columns.Add("REFPAYMENTMETHOD", "FORMA DE PAGO");
                dgvOrders.Columns.Add("TOTAL", "TOTAL");
                dgvOrders.Columns.Add("PREPAID", "PAGADO");
                dgvOrders.Columns.Add("CONFIRMED", "CONFIRMADO");
                dgvOrders.Columns.Add("LABELED", "ETIQUETADO");
                dgvOrders.Columns.Add("SENT", "ENVIADO");
                dgvOrders.Columns.Add("INVOICED", "FACTURADO");
            }
            else
            {
                dgvOrders.Columns.Add("IDORDER", "ID");
                dgvOrders.Columns.Add("REFCUSTOMER", "NAME CUSTOMER");
                dgvOrders.Columns.Add("REFCUSTOMER", "SURNAME CUSTOMER");
                dgvOrders.Columns.Add("REFUSER", "USER");
                dgvOrders.Columns.Add("DATETIME", "DATE");
                dgvOrders.Columns.Add("REFPAYMENTMETHOD", "PAYMENTMETHOD");
                dgvOrders.Columns.Add("TOTAL", "TOTAL");
                dgvOrders.Columns.Add("PREPAID", "PREPAID");
                dgvOrders.Columns.Add("CONFIRMED", "CONFIRMED");
                dgvOrders.Columns.Add("LABELED", "LABELED");
                dgvOrders.Columns.Add("SENT", "SENT");
                dgvOrders.Columns.Add("INVOICED", "INVOICED");
            }

           
            foreach (DataRow row in torders.Rows)
            {
                dgvOrders.Rows.Add(row["IDORDER"], row["NAME"], row["SURNAME"],row.ItemArray[3], row["DATETIME"], row["PAYMENTMETHOD"], row["TOTAL"], row["PREPAID"],row["CONFIRMED"],row["LABELED"],row["SENT"],row["INVOICED"]);
                
            }

            dgvOrders.Columns[8].DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dgvOrders.Columns[9].DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dgvOrders.Columns[10].DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dgvOrders.Columns[11].DefaultCellStyle.SelectionBackColor = Color.Transparent;


            
            dgvOrders.Columns["IDORDER"].Visible = false;
            
            dgvOrders.ClearSelection();

            dataGridView1_CellFormatting();
            
        }

        private void dataGridView1_CellFormatting()
        {
            foreach (DataGridViewRow Myrow in dgvOrders.Rows)
            {   //Here 2 cell is target value and 1 cell is Volume 
                if (Convert.ToInt32(Myrow.Cells[8].Value) == 0)// Or your condition 
                {
                    Myrow.Cells[8].Style.BackColor = Color.Red;
                    Myrow.Cells[8].Value = "";
                }
                else
                {
                    Myrow.Cells[8].Style.BackColor = Color.Green;
                    Myrow.Cells[8].Value = "";
                }

                if (Convert.ToInt32(Myrow.Cells[9].Value) == 0)// Or your condition 
                {
                    Myrow.Cells[9].Style.BackColor = Color.Red;
                    Myrow.Cells[9].Value = "";
                }
                else
                {
                    Myrow.Cells[9].Style.BackColor = Color.Green;
                    Myrow.Cells[9].Value = "";
                }

                if (Convert.ToInt32(Myrow.Cells[10].Value) == 0)// Or your condition 
                {
                    Myrow.Cells[10].Style.BackColor = Color.Red;
                    Myrow.Cells[10].Value = "";
                }
                else
                {
                    Myrow.Cells[10].Style.BackColor = Color.Green;
                    Myrow.Cells[10].Value = "";
                }
                if (Convert.ToInt32(Myrow.Cells[11].Value) == 0)// Or your condition 
                {
                    Myrow.Cells[11].Style.BackColor = Color.Red;
                    Myrow.Cells[11].Value = "";
                }
                else
                {
                    Myrow.Cells[11].Style.BackColor = Color.Green;
                    Myrow.Cells[11].Value = "";
                }
            }
        }


        private void initComboPayment(String cond)
        {
            Order o = new Order();
            o.getGestor().readInDB(" PAYMENTMETHOD", "PAYMENTMETHODS", cond);
            DataTable torder = o.getGestor().getOrders();
            comboPay.Items.Clear();

            foreach (DataRow row in torder.Rows)
            {
                comboPay.Items.Add(row["PAYMENTMETHOD"]);


            }
        }
        public void filtrar()
        {
            String sql = " ";

            if (!String.IsNullOrEmpty(txtCustomer.Text.Replace("'", "")))
            {
                sql+= " And refcustomer in(Select idcustomer from customers where upper(name) like '%"+txtCustomer.Text.ToUpper().Replace("'", "") + "%' or upper(surname) like '%"+txtCustomer.Text.ToUpper().Replace("'", "") + "%')";
            }
            if (!String.IsNullOrEmpty(txtUser.Text.Replace("'", "")))
            {
                sql += " And refuser in(Select iduser from usuario where Upper(name) like '%"+ txtUser.Text.ToUpper().Replace("'", "") + "%')";
            }
            if (dateOrder.Enabled==true && !String.IsNullOrEmpty(dateOrder.Text.Replace("'", ""))){
                sql += " And datetime =to_date('" + dateOrder.Text.Replace("'", "") + "','dd/MM/yyyy')";
            }
            if (comboPay.SelectedIndex != -1)
            {
                sql += "and refpaymentmethod In(Select idpaymentmethod from paymentmethods where paymentmethod= '" + comboPay.SelectedItem.ToString() + "')";
            }
            if (!String.IsNullOrEmpty(txtPrepaid.Text.Replace("'", "")))
            {
                sql += " and prepaid='" + txtPrepaid.Text.Replace("'", "").Replace(".",",") + "'";
            }

            bool checkValue = chkDeleted.Checked;
            int ivalue = (checkValue) ? 1 : 0;
            initTable(this.condicion + whereCondition + ivalue + sql + orderby);

        }

        private void txtCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar();
        }

        private void txtUser_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar();
        }

        private void dateOrder_ValueChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void dateOrder_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private void ckAct_CheckedChanged(object sender, EventArgs e)
        {
            dateOrder.Enabled = ckAct.Checked;
        }

        private void comboPay_SelectedValueChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void chkDeleted_CheckedChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void txtPrepaid_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtCustomer.Text = null;
            txtUser.Text = null;
            txtPrepaid.Text = null;
            ckAct.Checked = false;
            comboPay.SelectedIndex = -1;
            chkDeleted.Checked = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            String id= dgvOrders.Rows[dgvOrders.CurrentRow.Index].Cells[0].Value.ToString();
            String sql = "Update orders set Deleted=1 where idorder=" + id;

            if (this.idioma == "ESPAÑOL")
            {
                if(MessageBox.Show("¿Quieres eliminar a este pedido?", "Eliminar Pedido", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    GestorOrders.deleteOrder(sql);
                    initTable(condicion + whereCondition + 0 + orderby);
                }
            }
            else
            {
                if(MessageBox.Show("Do you want Delete this Order?", "Delete Order", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    GestorOrders.deleteOrder(sql);
                    initTable(condicion + whereCondition + 0 + orderby);
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            ModOrder mo;
            try
            {
                String idOrder = dgvOrders.Rows[dgvOrders.CurrentRow.Index].Cells[0].Value.ToString();
                DtoOrder dto = new DtoOrder(
                    dgvOrders.Rows[dgvOrders.CurrentRow.Index].Cells[0].Value.ToString(),
                    dgvOrders.Rows[dgvOrders.CurrentRow.Index].Cells[1].Value.ToString(),
                    dgvOrders.Rows[dgvOrders.CurrentRow.Index].Cells[2].Value.ToString(),
                    dgvOrders.Rows[dgvOrders.CurrentRow.Index].Cells[3].Value.ToString(),
                    dgvOrders.Rows[dgvOrders.CurrentRow.Index].Cells[4].Value.ToString(),
                    dgvOrders.Rows[dgvOrders.CurrentRow.Index].Cells[5].Value.ToString(),
                    dgvOrders.Rows[dgvOrders.CurrentRow.Index].Cells[6].Value.ToString(),
                    dgvOrders.Rows[dgvOrders.CurrentRow.Index].Cells[7].Value.ToString()
                    );
                mo = new ModOrder(u, idioma, dto);
                mo.ShowDialog();
                if (mo.IsDisposed)
                {
                    initTable(condicion + whereCondition + iValue + orderby);
                    initComboPayment("Where Deleted = 0");
                }
            }
            catch (Exception ex)
            {
                if(this.idioma == "INGLES") { Console.WriteLine("Error, you Must Select a Order"); }
                else { Console.WriteLine("Error, debes seleccionar un pedido"); }
                
            }

           
            
        }

        private void Orders_Shown(object sender, EventArgs e)
        {
            dgvOrders.ClearSelection();
        }

        private void dgvViewOrders_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
            
        {
            Order o = new Dominio.Order();
            Incomes inc = new Incomes();
            PPayments pa = new PPayments();
            DataGridView dgvOrders = sender as DataGridView;
            int id = int.Parse(dgvOrders.Rows[e.RowIndex].Cells[0].Value.ToString());
            String aux = o.getGestor().getUnString("select total from orders where idorder = " + id);
            int total = Int32.Parse(aux);
            aux = o.getGestor().getUnString("select prepaid from orders where idorder = " + id);
            int prepaid = Int32.Parse(aux);
            aux = o.getGestor().getUnString("select REFPAYMENTMETHOD from orders where idorder = " + id);
            int tipoPay = Int32.Parse(aux);

            if (dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Red)
            {
                int index = dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex;
                
                switch (index)
                {
                    case 8:
                        // AQUI SE CONTROLA QUE EL ROL SEA EL DE ADMIN PARA PODER HACER EFECTO AL DOBLE CLICK
                        //if ()
                        //{
                        dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                        dgvOrders.ClearSelection();
                        o.getGestor().setData("Update orders set confirmed = 1 where idorder = '" + id + "'");
                        if(total == prepaid)
                        {
                        String sql = ("INSERT INTO INCOMES (ID, DATE_INCOMES, REFUSER, REFENTRADA, REFTIPO, TEXT, AMOUNT, REFACTION) VALUES('0', SYSDATE, '" + this.u.getId() + "', '2', '1', '"+"Pagado el total del pedido con n: "+id+"', '"+total+"', '0')");
                        inc.getGestor().insertIncome(sql);
                        }
                        else
                        {
                            if(tipoPay == 3)
                            {
                                String sql = "Insert into ppayment values (0,SYSDATE," + this.u.getId() + ",'1','" + "Pendiente mas pagos del pedido con n: " + id + "','" + (total - prepaid) + "',0)";
                                GestorPPayment.insertPPayment(sql);
                            }
                            else
                            {
                                String sql = "Insert into ppayment values (0,SYSDATE," + this.u.getId() + ",'2','" + "Pendiente mas pagos del pedido con n: " + id + "','" + (total - prepaid) + "',0)";
                                GestorPPayment.insertPPayment(sql);
                            }                           
                        }
                            
                        //}
                        //else
                        //    {
                        //    if (this.idioma == "INGLES") { MessageBox.Show("Error, this user hasn't got permits"); }
                        //    else { MessageBox.Show("Error, el usuario no tiene permisos"); }
                        //}

                        break;
                    case 9:
                        //Falta añadir un && al if con lo del rol
                        if (dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Style.BackColor == Color.Green)
                        {
                            dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                            dgvOrders.ClearSelection();
                            o.getGestor().setData("Update orders set labeled = 1 where idorder = '" + id + "'");
                        }
                        else
                        {
                            if (dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Style.BackColor == Color.Red)
                            {
                                if (this.idioma == "INGLES") { MessageBox.Show("Error, this Order is not confirmed"); }
                                else { MessageBox.Show("Error, el pedido no esta confirmado"); }                                
                            }
                            else
                            {
                                if (this.idioma == "INGLES") { MessageBox.Show("Error, this user hasn't got permits"); }
                                else { MessageBox.Show("Error, el usuario no tiene permisos"); }
                            }
                        }    
                        break;
                    case 10:
                        //Falta añadir un && al if con lo del rol
                        if (dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Style.BackColor == Color.Green)
                        {
                            dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                            dgvOrders.ClearSelection();
                            o.getGestor().setData("Update orders set sent = 1 where idorder = '" + id + "'");
                        }
                        else
                        {
                            if (dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Style.BackColor == Color.Red)
                            {
                                if (this.idioma == "INGLES") { MessageBox.Show("Error, this Order is not labeled"); }
                                else { MessageBox.Show("Error, el pedido no esta etiquetado"); }
                            }
                            else
                            {
                                if (this.idioma == "INGLES") { MessageBox.Show("Error, this user hasn't got permits"); }
                                else { MessageBox.Show("Error, el usuario no tiene permisos"); }
                            }
                        }
                        break;
                    case 11:
                        //Dejo comentado los if hasta que no este al menos lo de rol o lo de 100% pagado
                        //Falta saber si pedido esta 100% pagado y añadir un && al if con lo del rol
                        //if ()
                        //{
                            dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Green;
                            dgvOrders.ClearSelection();
                            o.getGestor().setData("Update orders set invoiced = 1 where idorder = '" + id + "'");
                        //}
                        //else
                        //{
                        //    if ()
                        //    {
                        //        if (this.idioma == "INGLES") { MessageBox.Show("Error, this Order is 100% pay"); }
                        //        else { MessageBox.Show("Error, el pedido no esta 100% pagado"); }
                        //    }
                        //    else
                        //    {
                        //        if (this.idioma == "INGLES") { MessageBox.Show("Error, this user hasn't got permits"); }
                        //        else { MessageBox.Show("Error, el usuario no tiene permisos"); }
                        //    }
                        //}
                        break;

                }
                


            }
            else if (dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Green)
            {
                int index = dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex;

                switch (index)
                {
                    case 8:
                        //Falta añadir un && al if con lo del rol
                        if (dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Style.BackColor == Color.Red)
                        {
                            dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                            dgvOrders.ClearSelection();
                            o.getGestor().setData("Update orders set confirmed = 0 where idorder = '" + id + "'");                            
                        }
                        else
                        {
                            if (dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Style.BackColor == Color.Green)
                            {
                                if (this.idioma == "INGLES") { MessageBox.Show("Error, this Order is labeled"); }
                                else { MessageBox.Show("Error, el pedido esta etiquetado"); }
                            }
                            else
                            {
                                if (this.idioma == "INGLES") { MessageBox.Show("Error, this user hasn't got permits"); }
                                else { MessageBox.Show("Error, el usuario no tiene permisos"); }
                            }
                        }
                        break;
                    case 9:
                        //Falta añadir un && al if con lo del rol
                        if (dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Style.BackColor == Color.Red)
                        {
                            dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                            dgvOrders.ClearSelection();
                            o.getGestor().setData("Update orders set labeled = 0 where idorder = '" + id + "'");
                        }
                        else
                        {
                            if (dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Style.BackColor == Color.Green)
                            {
                                if (this.idioma == "INGLES") { MessageBox.Show("Error, this Order is sent"); }
                                else { MessageBox.Show("Error, el pedido esta enviado"); }
                            }
                            else
                            {
                                if (this.idioma == "INGLES") { MessageBox.Show("Error, this user hasn't got permits"); }
                                else { MessageBox.Show("Error, el usuario no tiene permisos"); }
                            }
                        }
                        break;
                    case 10:
                        // AQUI SE CONTROLA QUE EL ROL SEA EL DE ADMIN PARA PODER HACER EFECTO AL DOBLE CLICK
                        //if ()
                        //{
                            dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                            dgvOrders.ClearSelection();
                            o.getGestor().setData("Update orders set sent = 0 where idorder = '" + id + "'");
                        //}
                        //else
                        //    {
                        //    if (this.idioma == "INGLES") { MessageBox.Show("Error, this user hasn't got permits"); }
                        //    else { MessageBox.Show("Error, el usuario no tiene permisos"); }
                        //}
                        break;
                    case 11:
                            dgvOrders.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
                            dgvOrders.ClearSelection();
                            o.getGestor().setData("Update orders set invoiced = 0 where idorder = '" + id + "'");
                        break;
                }
            }
        }
    }
}
