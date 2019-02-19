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

        public NewInvoices(String idioma, User u)
        {
            this.idioma = idioma;
            this.u = u;
            InitializeComponent();

           
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
    }
}
