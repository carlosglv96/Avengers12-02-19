using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Avengers.Presentacion.Products;
using Avengers.Presentacion.Orders;
using Avengers.Dominio;
using Avengers.Dominio.Gestores;
using Avengers.Presentacion.Cashbook;
using Avengers.Presentacion.Cashbook.PPayment;
using Avengers.Presentacion.Cashbook.Validation;
using Avengers.Presentacion.Cashbook.Debts;
using Avengers.Presentacion.Invoices;

namespace Avengers.Presentacion
{
    public partial class Menu : Form
    {
        private ViewUsers u1;
        private ViewCustomer c1;
        private ViewOrders o1;
        private ViewProduct p1;
        public ViewIncomes i1;
        public ViewIncomes i2;
        public viewInvoice in1;

        // Serian los forms de incomes y demas...
        //private ViewIncomes i1;
        //private ViewExpenses e1;
        private viewPPayment pa1;
        private ViewDebts d1;
        private ViewValidation v1;

        private User u;
        private string idioma;

        public Menu(User u,String idioma)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.u = u;
            lblUser.Text = "                 " +u.getNombre();
            u.setPermits();
            //permits();
            this.idioma = idioma;
            if (this.idioma == "ESPAÑOL")
            {
                idioma_es();
            }
            else if (this.idioma == "INGLES")
            {
                idioma_en();
            }
            initMenu();

        }


        //public void permits()
        //{
        //    if (!GestorUsers.searchPermit("VIEWUSERS", u))
        //    {
        //        users.DisabledColor = Color.Transparent;
        //        users.Enabled = false;
        //        MessageBox.Show(("hola"));

        //    }
        //    if (!GestorUsers.searchPermit("VIEWCUSTOMERS", u))
        //    {
        //        customers.DisabledColor = Color.Transparent;
        //        customers.Enabled = false;
        //    }
        //    if (!GestorUsers.searchPermit("VIEWPRODUCTS", u))
        //    {
        //        products.DisabledColor = Color.Transparent;
        //        products.Enabled = false;
        //    }
        //    if (!GestorUsers.searchPermit("VIEWORDERS", u))
        //    {
        //        btnOrders.DisabledColor = Color.Transparent;
        //        btnOrders.Enabled = false;
        //    }
        //    if (!GestorUsers.searchPermit("VIEWINCOMES", u))
        //    {
        //        inco.DisabledColor = Color.Transparent;
        //        inco.Enabled = false;
        //    }
        //    if (!GestorUsers.searchPermit("VIEWEXPENSES", u))
        //    {
        //        expen.DisabledColor = Color.Transparent;
        //        expen.Enabled = false;
        //    }
        //    if (!GestorUsers.searchPermit("VIEWPPAYMENTS", u))
        //    {
        //        paym.DisabledColor = Color.Transparent;
        //        paym.Enabled = false;
        //    }
        //    if (!GestorUsers.searchPermit("VIEWDEBTS", u))
        //    {
        //        debts.DisabledColor = Color.Transparent;
        //        debts.Enabled = false;
        //    }
        //    if (!GestorUsers.searchPermit("VIEWVALIDATION", u))
        //    {
        //        valid.DisabledColor = Color.Transparent;
        //        valid.Enabled = false;
        //    }
        //    if (!GestorUsers.searchPermit("VIEWINVOICED", u))
        //    {
        //        btnInvoices.DisabledColor = Color.Transparent;
        //        btnInvoices.Enabled = false;
        //    }
        //}

        public void initMenu()
        {
            double incomes = 0;
            double cashIn = 0;
            double checkIn = 0;
            double receiptIn = 0;
            double cashEx = 0;
            double checkEx = 0;
            double receiptEx = 0;
            double totalCash = 0;
            double totalCheck = 0;
            double totalReceipt = 0;
            double expenses = 0;
            double total = 0;
            String strincomes;
            String strexpenses;
            String strtotalCashIn;
            String strtotalCashEx;
            String strtotalCheckIn;
            String strtotalCheckEx;
            String strtotalReceiptIn;
            String strtotalReceiptEx;
            Incomes inc = new Incomes();
            strincomes = inc.getGestor().getUnString("Select sum(amount) from INCOMES where REFACTION = 0");
            strexpenses = inc.getGestor().getUnString("Select sum(amount) from INCOMES where REFACTION = 1");
            strtotalCashIn = inc.getGestor().getUnString("Select sum(amount) from INCOMES where REFACTION = 0 AND REFTIPO = (Select ID from TYPES where UPPER(TEXT) = UPPER('CASH'))");
            strtotalCashEx = inc.getGestor().getUnString("Select sum(amount) from INCOMES where REFACTION = 1 AND REFTIPO = (Select ID from TYPES where UPPER(TEXT) = UPPER('CASH'))");
            strtotalCheckIn = inc.getGestor().getUnString("Select sum(amount) from INCOMES where REFACTION = 0 AND REFTIPO = (Select ID from TYPES where UPPER(TEXT) = UPPER('CHECK'))");
            strtotalCheckEx = inc.getGestor().getUnString("Select sum(amount) from INCOMES where REFACTION = 1 AND REFTIPO = (Select ID from TYPES where UPPER(TEXT) = UPPER('CHECK'))");
            strtotalReceiptIn = inc.getGestor().getUnString("Select sum(amount) from INCOMES where REFACTION = 0 AND REFTIPO = (Select ID from TYPES where UPPER(TEXT) = UPPER('RECEIPT'))");
            strtotalReceiptEx = inc.getGestor().getUnString("Select sum(amount) from INCOMES where REFACTION = 1 AND REFTIPO = (Select ID from TYPES where UPPER(TEXT) = UPPER('RECEIPT'))");

            if (!String.IsNullOrEmpty(strincomes)) { incomes = double.Parse(strincomes); }
            else { incomes = 0; }
            if (!String.IsNullOrEmpty(strexpenses)) { expenses = double.Parse(strexpenses); }
            else { expenses = 0; }
            if (!String.IsNullOrEmpty(strtotalCashIn)) { cashIn = double.Parse(strtotalCashIn); }
            else { cashIn = 0; }
            if (!String.IsNullOrEmpty(strtotalCheckIn)) { checkIn = double.Parse(strtotalCheckIn); }
            else { checkIn = 0; }
            if (!String.IsNullOrEmpty(strtotalReceiptIn)) { receiptIn = double.Parse(strtotalReceiptIn);  }
            else { receiptIn = 0; }
            if (!String.IsNullOrEmpty(strtotalCashEx)) { cashEx = double.Parse(strtotalCashEx); }
            else { cashEx = 0; }
            if (!String.IsNullOrEmpty(strtotalCheckEx)) { checkEx = double.Parse(strtotalCheckEx); }
            else { checkEx = 0; }
            if (!String.IsNullOrEmpty(strtotalReceiptEx)) { receiptEx = double.Parse(strtotalReceiptEx); }
            else { receiptEx = 0; }
            totalCash = cashIn - cashEx;
            totalCash = Math.Round(totalCash, 2);
            totalCheck = checkIn - checkEx;
            totalCheck = Math.Round(totalCheck, 2);
            totalReceipt = receiptIn - receiptEx;
            totalReceipt = Math.Round(totalReceipt, 2);
            total = incomes - expenses;
            this.texbtotal.Text = Convert.ToString(total);
            this.txbcash.Text = Convert.ToString(totalCash);
            this.txbcheck.Text = Convert.ToString(totalCheck);
            this.txbreceip.Text = Convert.ToString(totalReceipt);
        }


        private void mostrarBtnSys()
        {
            users.Visible = true;
            users.Enabled = true;
            customers.Visible = true;
            customers.Enabled = true;
            products.Visible = true;
            products.Enabled = true;

            inco.Visible = false;
            inco.Enabled = false;
            expen.Visible = false;
            expen.Enabled = false;
            paym.Visible = false;
            paym.Enabled = false;
            debts.Visible = false;
            debts.Enabled = false;
            valid.Visible = false;
            valid.Enabled = false;

            cash_panel.Visible = false;

            btnOrders.Location = new Point(0, 180);
            btnCash.Location = new Point(0, 205);
            btnInvoices.Location = new Point(0, 230);
        }

        private void ocultarBtnSys()
        {
            users.Visible = false;
            users.Enabled = false;
            customers.Visible = false;
            customers.Enabled = false;
            products.Visible = false;
            products.Enabled = false;

            inco.Visible = false;
            inco.Enabled = false;
            expen.Visible = false;
            expen.Enabled = false;
            paym.Visible = false;
            paym.Enabled = false;
            debts.Visible = false;
            debts.Enabled = false;
            valid.Visible = false;
            valid.Enabled = false;

            cash_panel.Visible = false;

            btnOrders.Location = new Point(0, 80);
            btnCash.Location = new Point(0, 105);
            btnInvoices.Location = new Point(0, 130);
        }
        private void mostrarBtnCas()
        {
            users.Visible = false;
            users.Enabled = false;
            customers.Visible = false;
            customers.Enabled = false;
            products.Visible = false;
            products.Enabled = false;

            inco.Visible = true;
            inco.Enabled = true;
            expen.Visible = true;
            expen.Enabled = true;
            paym.Visible = true;
            paym.Enabled = true;
            debts.Visible = true;
            debts.Enabled = true;
            valid.Visible = true;
            valid.Enabled = true;

            cash_panel.Visible = true;

            btnOrders.Location = new Point(0, 80);
            btnCash.Location = new Point(0, 105);
            btnInvoices.Location = new Point(0, 260);
        }


        private void users_Click(object sender, EventArgs e)
        {
            if(GestorUsers.searchPermit("VIEWUSERS", u))
            {
                if (!tabControl.TabPages.ContainsKey("u1"))
                {
                    u1 = new ViewUsers(this.idioma);
                    cash_panel.Visible = false;
                    tabControl.Visible = true;
                    u1.MdiParent = this;
                    u1.WindowState = FormWindowState.Normal;
                    u1.FormBorderStyle = FormBorderStyle.None;
                    u1.TopLevel = false;
                    u1.Dock = DockStyle.Fill;
                    u1.Show();

                    TabPage tpu = new TabPage(users.Text);
                    tpu.Tag = u1;
                    tpu.Name = "u1";
                    tpu.Parent = tabControl;
                    tabControl.SelectedTab = tpu;
                    u1.Tag = tpu;
                }
                else
                {
                    int n = tabControl.TabPages.IndexOfKey("u1");
                    tabControl.SelectTab(n);
                }
            }
            else
            {
                if (this.idioma == "INGLES") { MessageBox.Show("Error, this user hasn't got permits"); }
                else { MessageBox.Show("Error, el usuario no tiene permisos"); }
            }


        }
           
        private void tabControl_SelectedIndexChanged(object sender,
                                           EventArgs e)
        {
            if ((tabControl.SelectedTab != null) &&
                (tabControl.SelectedTab.Tag != null))
                (tabControl.SelectedTab.Tag as Form).Select();
        }

        private void btnSys_Click(object sender, EventArgs e)
        {
            mostrarBtnSys();
            //permits();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void idioma_es()
        {
            btnCloseTab.Text = Recursos.Espanol.btnCloseTab;
            btnSys.Text = Recursos.Espanol.btnSys;
            btnOrders.Text = Recursos.Espanol.btnOrders;
            users.Text = Recursos.Espanol.users;
            customers.Text = Recursos.Espanol.customers;
            products.Text = Recursos.Espanol.products;
            btnExit.Text = Recursos.Espanol.btnExit;
            btnCash.Text = Recursos.Espanol.cashbook;
            btnInvoices.Text = Recursos.Espanol.btnInvoice;
            inco.Text = Recursos.Espanol.incomes;
            expen.Text = Recursos.Espanol.expenses;
            paym.Text = Recursos.Espanol.pendingPayment;
            debts.Text = Recursos.Espanol.debts;
            valid.Text = Recursos.Espanol.Validation;
            lblcash.Text = Recursos.Espanol.inCash;
            lblcheck.Text = Recursos.Espanol.cheq;
            lblreceips.Text = Recursos.Espanol.receips;
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            if (GestorUsers.searchPermit("VIEWORDERS", u))
            {
                if (!tabControl.TabPages.ContainsKey("o1"))
                {
                    o1 = new ViewOrders(this.u,this.idioma);
                    cash_panel.Visible = false;
                    ocultarBtnSys();
                    tabControl.Visible = true;
                    o1.MdiParent = this;
                    o1.WindowState = FormWindowState.Normal;
                    o1.FormBorderStyle = FormBorderStyle.None;
                    o1.TopLevel = false;
                    o1.Dock = DockStyle.Fill;
                    o1.Show();

                    TabPage tp = new TabPage(btnOrders.Text);
                    tp.Tag = o1;
                    tp.Name = "o1";
                    tp.Parent = tabControl;
                    tabControl.SelectedTab = tp;
                    o1.Tag = tp;
                }
                else
                {
                    ocultarBtnSys();
                    int n = tabControl.TabPages.IndexOfKey("o1");
                    tabControl.SelectTab(n);
                }

            }
            else
            {
                if (this.idioma == "INGLES") { MessageBox.Show("Error, this user hasn't got permits"); }
                else { MessageBox.Show("Error, el usuario no tiene permisos"); }
            }
        
        }

        public void idioma_en()
        {
            btnCloseTab.Text = Recursos.Ingles.btnCloseTab;
            btnSys.Text = Recursos.Ingles.btnSys;
            btnOrders.Text = Recursos.Ingles.btnOrders;
            users.Text = Recursos.Ingles.users;
            customers.Text = Recursos.Ingles.customers;
            products.Text = Recursos.Ingles.products;
            btnExit.Text = Recursos.Ingles.btnExit;
            btnCash.Text = Recursos.Ingles.cashbook;
            btnInvoices.Text = Recursos.Ingles.btnInvoice;
            inco.Text = Recursos.Ingles.incomes;
            expen.Text = Recursos.Ingles.expenses;
            paym.Text = Recursos.Ingles.pendingPayment;
            debts.Text = Recursos.Ingles.debts;
            valid.Text = Recursos.Ingles.Validation;
            lblcash.Text = Recursos.Ingles.inCash;
            lblcheck.Text = Recursos.Ingles.cheq;
            lblreceips.Text = Recursos.Ingles.receips;
        }

        private void customers_Click(object sender, EventArgs e)
        {
            if (GestorUsers.searchPermit("VIEWCUSTOMERS", u))
            {
                if (!tabControl.TabPages.ContainsKey("c1"))
                {
                    c1 = new ViewCustomer(this.idioma);
                    cash_panel.Visible = false;
                    tabControl.Visible = true;
                    c1.MdiParent = this;
                    c1.WindowState = FormWindowState.Normal;
                    c1.FormBorderStyle = FormBorderStyle.None;
                    c1.TopLevel = false;
                    c1.Dock = DockStyle.Fill;
                    c1.Show();

                    TabPage tp = new TabPage(customers.Text);
                    tp.Tag = c1;
                    tp.Name = "c1";
                    tp.Parent = tabControl;
                    tabControl.SelectedTab = tp;
                    c1.Tag = tp;
                }
                else
                {
                    int n = tabControl.TabPages.IndexOfKey("c1");
                    tabControl.SelectTab(n);
                }
            }
            else
            {
                if (this.idioma == "INGLES") { MessageBox.Show("Error, this user hasn't got permits"); }
                else { MessageBox.Show("Error, el usuario no tiene permisos"); }
            }
                
            
        }

        private void btnCloseTab_Click(object sender, EventArgs e)
        {
            if (tabControl.TabCount > 0)
            {
                if (tabControl.SelectedTab.Name.Equals("u1"))
                {
                    u1.Dispose();
                }
                if (tabControl.SelectedTab.Name.Equals("o1"))
                {
                    o1.Dispose();
                }
                if (tabControl.SelectedTab.Name.Equals("c1"))
                {
                    c1.Dispose();
                }
                if (tabControl.SelectedTab.Name.Equals("p1"))
                {
                    p1.Dispose();
                }
                if (tabControl.SelectedTab.Name.Equals("i2"))
                {
                    i2.Dispose();
                }
                if (tabControl.SelectedTab.Name.Equals("i1"))
                {
                    i1.Dispose();
                }
                if (tabControl.SelectedTab.Name.Equals("v1"))
                {
                    v1.Dispose();
                }
                if (tabControl.SelectedTab.Name.Equals("pa1"))
                {
                    pa1.Dispose();
                }
                if (tabControl.SelectedTab.Name.Equals("d1"))
                {
                    d1.Dispose();
                }
                if (tabControl.SelectedTab.Name.Equals("in1"))
                {
                    in1.Dispose();
                }

                tabControl.TabPages.Remove(tabControl.SelectedTab);
                
                if (tabControl.TabCount == 0)
                {
                    tabControl.Visible = false;
                }
                else
                {
                    int resta = tabControl.TabCount - 1;
                    tabControl.SelectTab(resta);
                }                   
            }
            else
            {
                tabControl.Visible = false;
            }

        }

        private void products_Click(object sender, EventArgs e)
        {
            if (GestorUsers.searchPermit("VIEWPRODUCTS", u))
            {
                if (!tabControl.TabPages.ContainsKey("p1"))
                {
                    p1 = new ViewProduct(this.idioma);
                    cash_panel.Visible = false;
                    tabControl.Visible = true;
                    p1.MdiParent = this;
                    p1.WindowState = FormWindowState.Normal;
                    p1.FormBorderStyle = FormBorderStyle.None;
                    p1.TopLevel = false;
                    p1.Dock = DockStyle.Fill;
                    p1.Show();

                    TabPage tp = new TabPage(products.Text);
                    tp.Tag = p1;
                    tp.Name = "p1";
                    tp.Parent = tabControl;
                    tabControl.SelectedTab = tp;
                    p1.Tag = tp;
                }
                else
                {
                    int n = tabControl.TabPages.IndexOfKey("p1");
                    tabControl.SelectTab(n);
                }
            }
            else
            {
                if (this.idioma == "INGLES") { MessageBox.Show("Error, this user hasn't got permits"); }
                else { MessageBox.Show("Error, el usuario no tiene permisos"); }
            }
            
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            initMenu();
            mostrarBtnCas();
			//permits();
            
        }

        private void expen_Click(object sender, EventArgs e)
        {
            if (GestorUsers.searchPermit("VIEWEXPENSES", u))
            {
                initMenu();
                if (!tabControl.TabPages.ContainsKey("i2"))
                {
                    i2 = new ViewIncomes(this.idioma, this.u, 1, this);
                    i2.dgvIncomes.ClearSelection();
                    cash_panel.Visible = true;

                    tabControl.Visible = true;
                    i2.MdiParent = this;
                    i2.WindowState = FormWindowState.Normal;
                    i2.FormBorderStyle = FormBorderStyle.None;
                    i2.TopLevel = false;
                    i2.Dock = DockStyle.Fill;
                    i2.Show();
                    TabPage tp;
                    if (this.idioma == "ESPAÑOL")
                    { tp = new TabPage("Salidas"); }
                    else
                    { tp = new TabPage("Expenses"); }

                    tp.Tag = i2;
                    tp.Name = "i2";
                    tp.Parent = tabControl;
                    tabControl.SelectedTab = tp;
                    i2.Tag = tp;
                }
                else
                {
                    int n = tabControl.TabPages.IndexOfKey("i2");
                    tabControl.SelectTab(n);
                }
            }
            else
            {
                if (this.idioma == "INGLES") { MessageBox.Show("Error, this user hasn't got permits"); }
                else { MessageBox.Show("Error, el usuario no tiene permisos"); }
            }
            
        }

        private void inco_Click(object sender, EventArgs e)
        {
            if (GestorUsers.searchPermit("VIEWINCOMES", u))
            {
                initMenu();
                if (!tabControl.TabPages.ContainsKey("i1"))
                {
                    i1 = new ViewIncomes(this.idioma, this.u, 0, this);
                    cash_panel.Visible = true;

                    tabControl.Visible = true;
                    i1.MdiParent = this;
                    i1.WindowState = FormWindowState.Normal;
                    i1.FormBorderStyle = FormBorderStyle.None;
                    i1.TopLevel = false;
                    i1.Dock = DockStyle.Fill;
                    i1.Show();

                    TabPage tp = new TabPage(inco.Text);
                    tp.Tag = i1;
                    tp.Name = "i1";
                    tp.Parent = tabControl;
                    tabControl.SelectedTab = tp;
                    i1.Tag = tp;
                }
                else
                {
                    int n = tabControl.TabPages.IndexOfKey("i1");
                    tabControl.SelectTab(n);
                }
            }
            else
            {
                if (this.idioma == "INGLES") { MessageBox.Show("Error, this user hasn't got permits"); }
                else { MessageBox.Show("Error, el usuario no tiene permisos"); }
            }
            
        }

        private void paym_Click(object sender, EventArgs e)
        {
            if (GestorUsers.searchPermit("VIEWPPAYMENTS", u))
            {
                initMenu();
                if (!tabControl.TabPages.ContainsKey("pa1"))
                {
                    pa1 = new viewPPayment(this.idioma, this.u);
                    cash_panel.Visible = true;
                    tabControl.Visible = true;
                    pa1.MdiParent = this;
                    pa1.WindowState = FormWindowState.Normal;
                    pa1.FormBorderStyle = FormBorderStyle.None;
                    pa1.TopLevel = false;
                    pa1.Dock = DockStyle.Fill;
                    pa1.Show();

                    TabPage tp = new TabPage(paym.Text);
                    tp.Tag = pa1;
                    tp.Name = "pa1";
                    tp.Parent = tabControl;
                    tabControl.SelectedTab = tp;
                    pa1.Tag = tp;
                }
                else
                {
                    int n = tabControl.TabPages.IndexOfKey("pa1");
                    tabControl.SelectTab(n);
                }
            }
            else
            {
                if (this.idioma == "INGLES") { MessageBox.Show("Error, this user hasn't got permits"); }
                else { MessageBox.Show("Error, el usuario no tiene permisos"); }
            }
            
        }

        private void Valid_click(object sender, EventArgs e)
        {
            if (GestorUsers.searchPermit("VIEWVALIDATION", u))
            {
                initMenu();
                if (!tabControl.TabPages.ContainsKey("v1"))
                {

                    v1 = new ViewValidation(this.idioma, this.u, this);
                    cash_panel.Visible = true;
                    tabControl.Visible = true;
                    v1.MdiParent = this;
                    v1.WindowState = FormWindowState.Normal;
                    v1.FormBorderStyle = FormBorderStyle.None;
                    v1.TopLevel = false;
                    v1.Dock = DockStyle.Fill;
                    v1.Show();

                    TabPage tp = new TabPage(valid.Text);
                    tp.Tag = v1;
                    tp.Name = "v1";
                    tp.Parent = tabControl;
                    tabControl.SelectedTab = tp;
                    v1.Tag = tp;
                }
                else
                {
                    int n = tabControl.TabPages.IndexOfKey("v1");
                    tabControl.SelectTab(n);
                }
            }
            else
            {
                if (this.idioma == "INGLES") { MessageBox.Show("Error, this user hasn't got permits"); }
                else { MessageBox.Show("Error, el usuario no tiene permisos"); }
            }
            
        }

        public static implicit operator System.Windows.Forms.Menu(Menu v)
        {
            throw new NotImplementedException();
        }


        //private void debts_Click(object sender, EventArgs e)
        //{
        //    if (!tabControl.TabPages.ContainsKey("d1"))
        //    {
        //        d1 = new ViewDebts(this.idioma, this.u, this);
        //        tabControl.Visible = true;
        //        d1.MdiParent = this;
        //        d1.WindowState = FormWindowState.Normal;
        //        d1.FormBorderStyle = FormBorderStyle.None;
        //        d1.TopLevel = false;
        //        d1.Dock = DockStyle.Fill;
        //        d1.Show();
        //        TabPage tp = new TabPage(debts.Text);
        //        tp.Tag = d1;
        //        tp.Name = "d1";
        //        tp.Parent = tabControl;
        //        tabControl.SelectedTab = tp;
        //        d1.Tag = tp;
        //    }
        //    else
        //    {
        //        int n = tabControl.TabPages.IndexOfKey("d1");
        //        tabControl.SelectTab(n);
        //    }
        //}

        public double getTotalCash()
        {
            return Convert.ToDouble(texbtotal.Text);
        }

        public double getTotalBox()
        {
            return Convert.ToDouble(txbcash.Text);
        }

        public double getTotalCheck()
        {
            return Convert.ToDouble(txbcheck.Text);
        }

        public double getTotalReceipt()
        {
            return Convert.ToDouble(txbreceip.Text);
        }

       

        private void debts_Click_1(object sender, EventArgs e)
        {
            if (GestorUsers.searchPermit("VIEWDEBS", u))
            {
                if (!tabControl.TabPages.ContainsKey("d1"))
                {
                    d1 = new ViewDebts(this.idioma, this.u, this);
                    cash_panel.Visible = true;
                    tabControl.Visible = true;
                    d1.MdiParent = this;
                    d1.WindowState = FormWindowState.Normal;
                    d1.FormBorderStyle = FormBorderStyle.None;
                    d1.TopLevel = false;
                    d1.Dock = DockStyle.Fill;
                    d1.Show();
                    TabPage tp = new TabPage(debts.Text);
                    tp.Tag = d1;
                    tp.Name = "d1";
                    tp.Parent = tabControl;
                    tabControl.SelectedTab = tp;
                    d1.Tag = tp;
                }
                else
                {
                    int n = tabControl.TabPages.IndexOfKey("d1");
                    tabControl.SelectTab(n);
                }
            }
            else
            {
                if (this.idioma == "INGLES") { MessageBox.Show("Error, this user hasn't got permits"); }
                else { MessageBox.Show("Error, el usuario no tiene permisos"); }
            }
            
        }

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            if (GestorUsers.searchPermit("VIEWINVOICED", u))
            {
                if (!tabControl.TabPages.ContainsKey("in1"))
                {
                    in1 = new viewInvoice(this.idioma, this.u);
                    cash_panel.Visible = false;
                    tabControl.Visible = true;
                    in1.MdiParent = this;
                    in1.WindowState = FormWindowState.Normal;
                    in1.FormBorderStyle = FormBorderStyle.None;
                    in1.TopLevel = false;
                    in1.Dock = DockStyle.Fill;
                    in1.Show();
                    TabPage tp = new TabPage(btnInvoices.Text);
                    tp.Tag = in1;
                    tp.Name = "in1";
                    tp.Parent = tabControl;
                    tabControl.SelectedTab = tp;
                    in1.Tag = tp;
                    ocultarBtnSys();
                }
                else
                {
                    int n = tabControl.TabPages.IndexOfKey("in1");
                    tabControl.SelectTab(n);
                    ocultarBtnSys();
                }
            }
            else
            {
                if (this.idioma == "INGLES") { MessageBox.Show("Error, this user hasn't got permits"); }
                else { MessageBox.Show("Error, el usuario no tiene permisos"); }
            }
            
        }

        





        // de aqui para abajo dejo creada la estructura para llamar a los forms de incomes, expenses... con sus correspondientes pestañas. Lo comentado para que se pueda ejecutar hasta que esten
        //      creados

        //metodo incomes(...)
        //{
        //    if (!tabControl.TabPages.ContainsKey("i1"))
        //    {
        //        i1 = new ViewIncomes(this.idioma);
        //        tabControl.Visible = true;
        //        i1.MdiParent = this;
        //        i1.WindowState = FormWindowState.Normal;
        //        i1.FormBorderStyle = FormBorderStyle.None;
        //        i1.TopLevel = false;
        //        i1.Dock = DockStyle.Fill;
        //        i1.Show();

        //        TabPage tp = new TabPage(products.Text);
        //        tp.Tag = i1;
        //        tp.Name = "i1";
        //        tp.Parent = tabControl;
        //        tabControl.SelectedTab = tp;
        //        i1.Tag = tp;
        //    }
        //    else
        //    {
        //        int n = tabControl.TabPages.IndexOfKey("i1");
        //        tabControl.SelectTab(n);
        //    }
        //}

        //metodo expenses(...)
        //{
        //    if (!tabControl.TabPages.ContainsKey("e1"))
        //    {
        //        e1 = new ViewProduct(this.idioma);
        //        tabControl.Visible = true;
        //        e1.MdiParent = this;
        //        e1.WindowState = FormWindowState.Normal;
        //        e1.FormBorderStyle = FormBorderStyle.None;
        //        e1.TopLevel = false;
        //        e1.Dock = DockStyle.Fill;
        //        e1.Show();

        //        TabPage tp = new TabPage(products.Text);
        //        tp.Tag = e1;
        //        tp.Name = "e1";
        //        tp.Parent = tabControl;
        //        tabControl.SelectedTab = tp;
        //        e1.Tag = tp;
        //    }
        //    else
        //    {
        //        int n = tabControl.TabPages.IndexOfKey("e1");
        //        tabControl.SelectTab(n);
        //    }
        //}
        //metodo paymen(...)
        //{

        //metodo debts(...)
        //{
        //    if (!tabControl.TabPages.ContainsKey("d1"))
        //    {
        //        d1 = new ViewProduct(this.idioma);
        //        tabControl.Visible = true;
        //        d1.MdiParent = this;
        //        d1.WindowState = FormWindowState.Normal;
        //        d1.FormBorderStyle = FormBorderStyle.None;
        //        d1.TopLevel = false;
        //        d1.Dock = DockStyle.Fill;
        //        d1.Show();

        //        TabPage tp = new TabPage(products.Text);
        //        tp.Tag = d1;
        //        tp.Name = "d1";
        //        tp.Parent = tabControl;
        //        tabControl.SelectedTab = tp;
        //        d1.Tag = tp;
        //    }
        //    else
        //    {
        //        int n = tabControl.TabPages.IndexOfKey("d1");
        //        tabControl.SelectTab(n);
        //    }
        //}
        //metodo validation(...)
        //{
        //    if (!tabControl.TabPages.ContainsKey("v1"))
        //    {
        //        v1 = new ViewProduct(this.idioma);
        //        tabControl.Visible = true;
        //        v1.MdiParent = this;
        //        v1.WindowState = FormWindowState.Normal;
        //        v1.FormBorderStyle = FormBorderStyle.None;
        //        v1.TopLevel = false;
        //        v1.Dock = DockStyle.Fill;
        //        v1.Show();

        //        TabPage tp = new TabPage(products.Text);
        //        tp.Tag = v1;
        //        tp.Name = "v1";
        //        tp.Parent = tabControl;
        //        tabControl.SelectedTab = tp;
        //        v1.Tag = tp;
        //    }
        //    else
        //    {
        //        int n = tabControl.TabPages.IndexOfKey("v1");
        //        tabControl.SelectTab(n);
        //    }
        //}
    }
}
