using Avengers.Dominio;
using Avengers.Dominio.Gestores;
using Avengers.Presentacion.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avengers.Presentacion.Orders
{
    public partial class ModOrder : Form
    {
        //Atributos Orders
        public String idOrder;
        private String idcustomer;
        private String refuser;
        private String refpaymentmethod;
        private String fecha;
        private String total;
        private String prepaid;

        private DtoOrder dto;
        private User u;
        private String idioma;
       
        private DtoCustomer dtoCustomer;
        private DtoProduct dtoProduct;
        private float t;
        
        public ModOrder(User u, String idioma, DtoOrder dto)
        {
            InitializeComponent();
            this.u = u;
            this.idioma = idioma;
            this.dto = dto;
            this.idOrder = dto.IdOrder;
            txtCustomer.Text = dto.Nombre + " " + dto.Apellido;
            nudAmount.Value = 1;
            nudAmount.Minimum = 1;
            initTable();
            initPay(" Where deleted=0");
            initOrder();
        }

        private void initOrder()
        {
            Order o = new Order();
            o.getGestor().readInOrders("*", " Where idorder='" + this.idOrder + "'");

            DataTable torder = o.getGestor().getOrders();
            lblNumeroOrder.Text = "ORDER ID: " + this.idOrder;
            foreach (DataRow row in torder.Rows)
            {
                
                this.idcustomer = row["REFCUSTOMER"].ToString();
                this.refuser = row["REFUSER"].ToString();
                date.Text = row["DATETIME"].ToString();
                this.refpaymentmethod = row["REFPAYMENTMETHOD"].ToString();
                this.total = row["TOTAL"].ToString();
                this.prepaid = row["PREPAID"].ToString();

            }

            //esta consulta me da -1 comprobar por que
            //Console.WriteLine(GestorCustomers.getData(" NAME ", " CUSTOMERS ", " IDCUSTOMER = '" + this.idcustomer + "'"));
           // txtCustomer.Text = GestorCustomers.getData(" NAME||' '||SURNAME ", " CUSTOMERS ", " IDCUSTOMER='" + this.idcustomer + "'").ToString();
            cmbPay.SelectedValue = refpaymentmethod;
            txtTotal.Text = this.total;
            
        }

        private void initTable()
        {
            

            dgvModOrder.Columns.Clear();

            OrderProduct op = new OrderProduct();
            String columnas = " o.idorderproduct, o.reforder,o.refproduct, p.name, o.amount, o.pricesale ";
            String tablas = "  ordersproducts o inner join products p on refproduct=idproduct ";
            String condi = " where o.reforder= " + this.idOrder;
           // Console.WriteLine(columnas + tablas + condi);
            op.getGestor().readInDB(columnas, tablas, condi);


            DataTable torders = op.getGestor().getOrderProduct();
            dgvModOrder.Columns.Clear();

            if (this.idioma == "ESPAÑOL")
            {
                dgvModOrder.Columns.Add("IDORDERPRODUCT", "IDORDERPRODUCT");
                dgvModOrder.Columns.Add("REFORDER", "REFORDER");
                dgvModOrder.Columns.Add("REFPRODUCT", "IDPRODUCTO");
                dgvModOrder.Columns.Add("NAME", "PRODUCTO");
                dgvModOrder.Columns.Add("AMOUNT", "CANTIDAD");
                dgvModOrder.Columns.Add("PRICESALE", "PRECIO DE VENTA");

            }
            else
            {
                dgvModOrder.Columns.Add("IDORDERPRODUCT", "ID");
                dgvModOrder.Columns.Add("REFORDER", "REFORDER");
                dgvModOrder.Columns.Add("REFPRODUCT", "IDPRODUCT");
                dgvModOrder.Columns.Add("NAME", "PRODUCT");
                dgvModOrder.Columns.Add("AMOUNT", "AMOUNT");
                dgvModOrder.Columns.Add("PRICESALE", "PRICESALE");

            }


            foreach (DataRow row in torders.Rows)
            {
                dgvModOrder.Rows.Add(row["IDORDERPRODUCT"], row["REFORDER"], row["REFPRODUCT"],row["NAME"], row["AMOUNT"], row["PRICESALE"]);
            }

            dgvModOrder.Columns["IDORDERPRODUCT"].Visible = true;
            dgvModOrder.Columns["REFORDER"].Visible = true;
            dgvModOrder.Columns["REFPRODUCT"].Visible = true;


        }
        public void initPay(String cond)
        {
            Order o = new Order();
            o.getGestor().readInDB("IDPAYMENTMETHOD, PAYMENTMETHOD ", "PAYMENTMETHODS", cond);
            DataTable torder = o.getGestor().getOrders();

            cmbPay.DataSource = torder;
            cmbPay.DisplayMember = "PAYMENTMETHOD";
            cmbPay.ValueMember = "IDPAYMENTMETHOD";

        }

        public void idioma_es()
        {
            this.lblCustomer.Text = Avengers.Recursos.Espanol.lblCustomer;
            this.lblAmount.Text = Avengers.Recursos.Espanol.lblAmount;
            this.lblDate.Text = Avengers.Recursos.Espanol.lblDate;
            this.lblPayMethod.Text = Avengers.Recursos.Espanol.lblPay;
            this.lblPricesale.Text = Avengers.Recursos.Espanol.lblPricesale;
            this.lblProduct.Text = Avengers.Recursos.Espanol.lblProduct;
            this.btnModify.Text = Avengers.Recursos.Espanol.btnModify;
            this.btnCancel.Text = Avengers.Recursos.Espanol.btnCancel;

        }
        public void idioma_en()
        {
            this.lblCustomer.Text = Avengers.Recursos.Ingles.lblCustomer;
            this.lblAmount.Text = Avengers.Recursos.Ingles.lblAmount;
            this.lblDate.Text = Avengers.Recursos.Ingles.lblDate;
            this.lblPayMethod.Text = Avengers.Recursos.Ingles.lblPay;
            this.lblPricesale.Text = Avengers.Recursos.Ingles.lblPricesale;
            this.lblProduct.Text = Avengers.Recursos.Ingles.lblProduct;
            this.btnModify.Text = Avengers.Recursos.Ingles.btnModify;
            this.btnCancel.Text = Avengers.Recursos.Ingles.btnCancel;
        }

        private void btnFindProd_Click(object sender, EventArgs e)
        {
            ViewProduct vp = new ViewProduct(this, this.idioma);
            
            vp.ShowDialog(this);
            this.nudAmount.Value = 1;
            
        }

        private void btnFindCust_Click(object sender, EventArgs e)
        {
            ViewCustomer vc = new ViewCustomer(this,this.idioma);
            vc.ShowDialog(this);
        }

        public void updateProduct(DtoProduct product)
        {
            //Console.WriteLine(product.Name);
            this.dtoProduct = product;
            this.txtProduct.Text = product.Name;
            this.txtPrice.Text = product.Price;

        }
        public void updateCustomer(DtoCustomer customer)
        {
            //Console.WriteLine(customer.Name+" "+ customer.Surname);
            this.dtoCustomer = customer;
            this.idcustomer = customer.Idcustomer;
            txtCustomer.Text = customer.Name + " " + customer.Surname;

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.t = 0;
            if (dgvModOrder.RowCount > 1)
            {
                dgvModOrder.Rows.RemoveAt(dgvModOrder.CurrentRow.Index);

                //restar cantidad del precio
                for (int i = 0; i < dgvModOrder.RowCount; i++)
                {
                    this.t = this.t + (float.Parse(dgvModOrder.Rows[i].Cells[4].Value.ToString()) * float.Parse(dgvModOrder.Rows[i].Cells[5].Value.ToString()));
                }
                txtTotal.Text = Convert.ToString(t);
            }
        
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            this.t = 0;
            Order o = new Order();
            String idorderproduct = "";
            String idorder = "";
            String idproduct = "";
            String sql1 = "";
            String sql2 = "";

            if (!String.IsNullOrEmpty(txtProduct.Text.Replace("'", "")))
            {
                idorder = this.idOrder;
                sql1 = "Select idorderproduct from ordersproducts where reforder = '" + idorder + "'";
                sql2 = "Select idproduct from products where upper(name) = upper('" + this.txtProduct.Text.Replace("'", "") + "')";
                //Console.WriteLine(sql1);
                //Console.WriteLine(sql2);
                idorderproduct = o.getGestor().getUnString(sql1);
                
                idproduct = o.getGestor().getUnString(sql2);
                //Console.WriteLine("IDORDERPRODUCT >>>>>" + idorderproduct);
                //Console.WriteLine("IDORDER >>>>>>" + idorder);
                //Console.WriteLine("IDPRODUCT >>>>>>>>>" + idproduct);
                dgvModOrder.Rows.Add(idorderproduct,idorder,idproduct,txtProduct.Text.Replace("'", ""), nudAmount.Value.ToString().Replace("'", ""), txtPrice.Text.Replace("'", ""));
                //if (!String.IsNullOrEmpty(txtDiscount.Text))
                //{
                //    // -1 esta puesto por la fila en blanco
                //    for (int i = 0; i < dataGridView1.RowCount ; i++)
                //    {
                //        this.t = this.t + (float.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) * float.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()));                        
                //    }
                //    this.t = this.t - (this.t * ((float.Parse(txtDiscount.Text)) / 100));
                //    tbxTotal.Text = Convert.ToString(t);

                //}
                //else {
                //if (dataGridView1.RowCount > 1)
                //{

                for (int i = 0; i < dgvModOrder.RowCount; i++)
                {
                    this.t = this.t + (float.Parse(dgvModOrder.Rows[i].Cells[4].Value.ToString()) * float.Parse(dgvModOrder.Rows[i].Cells[5].Value.ToString()));
                }
                this.txtTotal.Text = Convert.ToString(t);
                //}                      
                //}
            }
            else
            {
                if (this.idioma == "ESPAÑOL")
                {
                    MessageBox.Show("Debes seleccionar un producto");
                }
                else
                {
                    MessageBox.Show("You must select one Product");
                }

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Order o = new Order();
            //Update Orders
            String sql = "";
            sql = "Select refcustomer from orders where idorder ='" + this.idOrder + "'";
            Console.WriteLine("traza  1 " + sql);
            String idcustomer = o.getGestor().getUnString(sql);
            String refpayment = this.cmbPay.SelectedValue.ToString().Replace("'", "");
            String total = this.txtTotal.Text;
            String fecha = this.date.Value.ToString("dd/MM/yyyy").Replace("'", "");
            sql = "Update orders set refcustomer ='" + idcustomer + "',datetime ='" + fecha + "',refpaymentmethod = '" + refpayment + "', total = '" + total + "' where idorder = '" + this.idOrder + "'";
            Console.WriteLine("traza 2 " + sql);
            o.getGestor().setData(sql);
            


            //Por implementar

            //Insert OrdersProducts
            String idorderproduct = dgvModOrder.Rows[dgvModOrder.CurrentRow.Index].Cells[0].Value.ToString();
            String idOrder = this.idOrder;
            String idProduct = "";
            String amount = "";
            String pricesale = "";
           
            sql = "delete from ordersproducts where reforder = '" + idOrder + "'";
            Console.WriteLine("traza 3 "+sql);
            o.getGestor().setData(sql);
            
            for (int i = 0; i < dgvModOrder.RowCount; i++)
            {
                idProduct = dgvModOrder.Rows[i].Cells[2].Value.ToString();
                idProduct.Replace("'", "");
                amount = dgvModOrder.Rows[i].Cells[4].Value.ToString();
                amount.Replace("'", "").Replace(".", ",");
                pricesale = dgvModOrder.Rows[i].Cells[5].Value.ToString();
                pricesale.Replace("'", "").Replace(".", ",");
                sql = "Insert into ordersproducts values(null,'"+idOrder+"','"+idProduct+"','"+amount+"','"+pricesale+"')";
                Console.WriteLine("traza 4 "+sql);
                o.getGestor().setData(sql);
               
            }
            this.Dispose();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
