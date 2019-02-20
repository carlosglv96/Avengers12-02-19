using Avengers.Dominio;
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

namespace Avengers.Presentacion.Invoices
{
    public partial class NewInvoices : Form
    {
        private String idioma;
        private User u;
        private DtoCustomer dtoCustomer;
        private DtoProduct dtoProduct;
        private DtoLine dtoLine;
        private List<DtoProduct> listProduct;
        private List<DtoLine> listLine;
        private float netprice=0;
        private float priceIva=0;
        private float totalIva;
        private readonly float IVA = 10;


        public NewInvoices(String idioma, User u)
        {
            this.idioma = idioma;
            this.u = u;
            listProduct = new List<DtoProduct>();
            listLine = new List<DtoLine>();
           
        
            this.totalIva = 0;
            InitializeComponent();
            initTable();

           
        }

        public void initTable()
        {
            dgvInv.Columns.Clear();
            if (this.idioma == "ESPAÑOL")
            {
                dgvInv.Columns.Add("PRODUCT", "PRODUCTO");
                dgvInv.Columns.Add("AMOUNT", "CANTIDAD");
                dgvInv.Columns.Add("NET_AMOUNT", "PRECIO NETO");
                dgvInv.Columns.Add("PRICE", "PRECIO TOTAL");
            }
            else
            {
                dgvInv.Columns.Add("PRODUCT", "PRODUCT");
                dgvInv.Columns.Add("AMOUNT", "AMOUNT");
                dgvInv.Columns.Add("NET_AMOUNT", "NET AMOUNT");
                dgvInv.Columns.Add("PRICE", "PRICE");
            }
        }

        public void updateCustomer(DtoCustomer customer)
        {
            //Console.WriteLine(customer.Name+" "+ customer.Surname);
            this.dtoCustomer = customer;
            txtCustomer.Text = customer.Name + " " + customer.Surname;

        }
        public void updateProduct(DtoProduct product)
        {
            // Console.WriteLine(product.Name);
            this.dtoProduct = product;
            txtProduct.Text = product.Name;
            txtPriceProduct.Text = product.Price;

        }

        private void btnFindCust_Click_1(object sender, EventArgs e)
        {
            ViewCustomer vc = new ViewCustomer(this, this.idioma);

            vc.ShowDialog(this);
        }

        private void btnFindProd_Click(object sender, EventArgs e)
        {
            ViewProduct vp = new ViewProduct(this, this.idioma);
            vp.ShowDialog(this);
            this.nudAmount.Value = 1;
        }





        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            if (checkProduct())
            {
                netprice = 0;
                priceIva = 0;
                for (int i = 0; i < nudAmount.Value ; i++)
                {
                    listProduct.Add(dtoProduct);
                    netprice = float.Parse(dtoProduct.Price);
                    priceIva +=netprice + (netprice * (IVA / 100));
                    totalIva += priceIva;
                }
                dgvInv.Rows.Add(dtoProduct.Name, nudAmount.Value, netprice, priceIva);
                txtTotal.Text = (this.totalIva).ToString();
                //insertamos en la tabla y borramos las casillas
                dtoProduct = null;
                txtProduct.Text = null;
                nudAmount.Value = 1;
                txtPriceProduct.Text=null;

            }
        }

        private bool checkProduct()
        {
            return (dtoProduct != null);
        }
        private bool checkLine()
        {
            return !String.IsNullOrEmpty(txtDesc.Text) && !String.IsNullOrEmpty(txtPriceLine.Text) && Utils.check.checkAmountPos(txtPriceLine.Text.Replace("'",""));
        }

        private void btnAddLine_Click(object sender, EventArgs e)
        {
            if (checkLine())
            {
                netprice = float.Parse(txtPriceLine.Text.Replace(".",",").Replace("'",""))* float.Parse(nudAmountLine.Value.ToString());
                priceIva = netprice + (netprice * (IVA / 100));
                totalIva += priceIva;

                DtoLine dtoLine = new DtoLine(txtDesc.Text.Replace("'", ""), (nudAmountLine.Value).ToString(), netprice.ToString());
                listLine.Add(dtoLine);
                dgvInv.Rows.Add(dtoLine.Description, dtoLine.Quantity, netprice, priceIva);
                txtTotal.Text = (this.totalIva).ToString();
                //borramos las casillas
                txtDesc.Text = null;
                nudAmountLine.Value = 1;
                txtPriceLine.Text = null;

            }

        }
    }
}
