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
    public partial class ModInvoice : Form
    {
        private String idioma;
        private User u;
        private DtoInvoice invoice;
        private readonly float IVA = 10;
        private float netprice = 0;
        private float priceIva = 0;
        private float totalNeto = 0;
        private float totalIva = 0;



        public ModInvoice(DtoInvoice invoice,String idioma,User u)
        {
            this.idioma = idioma;
            this.u = u;
            this.invoice = invoice;
            InitializeComponent();
            initTable();
            //inicializamos los totales
            txtTotal.Text = invoice.Amount;
            txtTotalNeto.Text = invoice.Net_Amount;
            this.totalIva = float.Parse(invoice.Amount);
            this.totalNeto = float.Parse(invoice.Net_Amount);


        }


        public void initTable()
        {
            String sql = " select p.idproduct as ID,'P' as TYPE, ip.refinvoice as REFINVOICE ,p.name as PRODUCT ,ip.amount as AMOUNT ,p.price AS UNIPRICE, ROUND(ip.amount*p.price,2) as NET_AMOUNT, ROUND(ip.amount*p.price+(ip.amount*p.price*"+IVA+"/100),2) as PRICE" +
                            " from products p inner join invoices_products ip on p.idproduct=ip.refproduct " +
                            " where ip.refinvoice='" + invoice.IdInvoice + "' " +
                          " union " +
                          " select  l.idline as ID,'L' as type, l.refinvoice as REFINVOICE,l.description as PRODUCT,l.quantity as AMOUNT, l.price  AS UNIPRICE, ROUND(l.quantity*l.price,2) as NET_AMOUNT, ROUND(l.quantity*l.price+(l.quantity*l.price*" + IVA + "/100),2) as PRICE" +
                             " from lines l " +
                             " where l.refinvoice ='" + invoice.IdInvoice + "' " +
                          " union " +
                          " select p.idproduct as ID ,'O' as type, oi.refinvoice as REFINVOICE, p.name as PRODUCT ,op.amount as AMOUNT,op.pricesale  AS UNIPRICE, ROUND(op.amount*op.pricesale,2) as NET_AMOUNT , ROUND(op.amount*op.pricesale+(op.amount*op.pricesale*" + IVA + "/100),2) as PRICE " +
                             " from products p inner join ordersproducts op on p.idproduct = op.refproduct " +
                             " inner join orders_invoices oi on op.reforder = oi.reforder " +
                             " where oi.refinvoice = '" + invoice.IdInvoice+"'";
           

            Dominio.Invoices i = new Dominio.Invoices();
            i.getGestor().readInDB(sql);
            DataTable dt = i.getGestor().getInvoices();


            dgvInv.Columns.Clear();
            if (this.idioma == "ESPAÑOL")
            {         
                dgvInv.Columns.Add("ID", "ID");
                dgvInv.Columns.Add("TYPE", "TIPO");
                dgvInv.Columns.Add("REFINVOICE", "ID INVOICE");
                dgvInv.Columns.Add("PRODUCT", "PRODUCTO");
                dgvInv.Columns.Add("AMOUNT", "CANTIDAD");
                dgvInv.Columns.Add("UNIPRICE", "PRECIO UNIDAD");
                dgvInv.Columns.Add("NET_AMOUNT", "PRECIO NETO");
                dgvInv.Columns.Add("PRICE", "PRECIO TOTAL");
            }
            else
            {
                dgvInv.Columns.Add("ID", "ID");
                dgvInv.Columns.Add("TYPE", "TIPO");
                dgvInv.Columns.Add("REFINVOICE", "ID INVOICE");
                dgvInv.Columns.Add("PRODUCT", "PRODUCT");
                dgvInv.Columns.Add("AMOUNT", "AMOUNT");
                dgvInv.Columns.Add("UNIPRICE", "UNIT PRICE");
                dgvInv.Columns.Add("NET_AMOUNT", "NET AMOUNT");
                dgvInv.Columns.Add("PRICE", "PRICE");


            }
            dgvInv.Columns["ID"].Visible = false;
            dgvInv.Columns["TYPE"].Visible = false;
            dgvInv.Columns["REFINVOICE"].Visible = false;
            dgvInv.Columns["UNIPRICE"].Visible = false;

            foreach(DataRow row in dt.Rows)
            {
                dgvInv.Rows.Add(row["ID"], row["TYPE"], row["REFINVOICE"], row["PRODUCT"], row["AMOUNT"], row["UNIPRICE"], row["NET_AMOUNT"], row["PRICE"]);
            }

        }


  }

   
}
