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
    public partial class ModInvoice : Form
    {
        private String idioma;
        private User u;
        private DtoInvoice invoice;
        private DtoProduct dtoProduct;
        private DtoLine dtoLine;
        private readonly float IVA = 10;
        private float netprice = 0;
        private float priceIva = 0;
        private float totalNeto = 0;
        private float totalIva = 0;



        public ModInvoice(DtoInvoice invoice, String idioma, User u)
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
            String sql = " select p.idproduct as ID,'P' as TYPE, ip.refinvoice as REFINVOICE ,p.name as PRODUCT ,ip.amount as AMOUNT ,p.price AS UNIPRICE, ROUND(ip.amount*p.price,2) as NET_AMOUNT, ROUND(ip.amount*p.price+(ip.amount*p.price*" + IVA + "/100),2) as PRICE" +
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
                             " where oi.refinvoice = '" + invoice.IdInvoice + "'";


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

            foreach (DataRow row in dt.Rows)
            {
                dgvInv.Rows.Add(row["ID"], row["TYPE"], row["REFINVOICE"], row["PRODUCT"], row["AMOUNT"], row["UNIPRICE"], row["NET_AMOUNT"], row["PRICE"]);
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //sacamos todos los datos de la fila
            int id = Convert.ToInt16(dgvInv.Rows[dgvInv.CurrentRow.Index].Cells[0].Value.ToString());
            String tipo = dgvInv.Rows[dgvInv.CurrentRow.Index].Cells[1].Value.ToString();
            String invoice = dgvInv.Rows[dgvInv.CurrentRow.Index].Cells[2].Value.ToString();
            String name = dgvInv.Rows[dgvInv.CurrentRow.Index].Cells[3].Value.ToString();
            int amount = Convert.ToInt16(dgvInv.Rows[dgvInv.CurrentRow.Index].Cells[4].Value.ToString());
            float uniprice = float.Parse(dgvInv.Rows[dgvInv.CurrentRow.Index].Cells[5].Value.ToString());
            float net_amount = float.Parse(dgvInv.Rows[dgvInv.CurrentRow.Index].Cells[6].Value.ToString());
            float totalPrice = float.Parse(dgvInv.Rows[dgvInv.CurrentRow.Index].Cells[7].Value.ToString());

            //si la cantidad de elementos a quitar es mayor que la cantidad de elementos que hay
            if (nudRemove.Value >= amount)
            {

                this.totalIva -= totalPrice;
                this.totalNeto -= net_amount;
                txtTotalNeto.Text = this.totalNeto.ToString();
                txtTotal.Text = this.totalIva.ToString();
                nudRemove.Value = 1;
                dgvInv.Rows.RemoveAt(dgvInv.CurrentRow.Index);


            }
            else
            {
                //cambiamos las cantidades
                dgvInv.Rows[dgvInv.CurrentRow.Index].Cells[4].Value = amount - nudRemove.Value;
                //cambiamos el precio neto
                net_amount -= uniprice * float.Parse(nudRemove.Value.ToString());
                net_amount = (float)Math.Round(net_amount, 2);
                dgvInv.Rows[dgvInv.CurrentRow.Index].Cells[6].Value = net_amount;
                //cambiamos el precio + iva
                totalPrice -= uniprice * float.Parse(nudRemove.Value.ToString()) + (uniprice * IVA / 100);
                totalPrice = (float)Math.Round(totalPrice, 2);
                dgvInv.Rows[dgvInv.CurrentRow.Index].Cells[7].Value = totalPrice;
                //restamos la cantidad al total
                totalNeto -= uniprice * float.Parse(nudRemove.Value.ToString());
                totalNeto = (float)Math.Round(totalNeto, 2);
                txtTotalNeto.Text = totalNeto.ToString();
                totalIva -= uniprice * float.Parse(nudRemove.Value.ToString()) + (uniprice * IVA / 100);
                totalIva = (float)Math.Round(totalIva, 2);
                txtTotal.Text = totalIva.ToString();

                //volvemos a poner nudRemove a 1
                nudRemove.Value = 1;



            }
        }

        public void removeFromBD(String tipo, String invoice, int id, String name)
        {
            String sql = "";
            switch (tipo)
            {
                case "P":
                    sql = "Delete from Invoices_Products where refinvoice='" + invoice + "' and refproduct='" + id + "'";
                    Dominio.Gestores.GestorInvoicesProducts.deleteInvoicesProduct(sql);
                    break;
                case "L":
                    sql = "Delete from Lines where refinvoice='" + invoice + "' and description='" + name + "'";
                    Dominio.Gestores.GestorInvoicesProducts.deleteInvoicesProduct(sql);
                    break;
                case "O":
                    sql = "Delete from Orders_Invoices where refinvoice=-'" + invoice + "'";
                    Dominio.Gestores.GestorInvoicesProducts.deleteInvoicesProduct(sql);
                    break;
            }
        }

        private void btnFindProd_Click(object sender, EventArgs e)
        {
            ViewProduct vp = new ViewProduct(this, this.idioma);
            vp.ShowDialog(this);
            this.nudAmount.Value = 1;
        }

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            if (!searchProduct(dtoProduct))
            {
               
                netprice = float.Parse(txtPriceProduct.Text.Replace(".", ",").Replace("'", "")) * float.Parse(nudAmount.Value.ToString());
                netprice = (float)Math.Round(netprice, 2);
                priceIva = netprice + (netprice * (IVA / 100));
                priceIva = (float)Math.Round(priceIva, 2);
                totalNeto += netprice;
                totalNeto = (float)Math.Round(netprice, 2);
                totalIva += priceIva;
                totalIva = (float)Math.Round(totalIva, 2);

                dgvInv.Rows.Add(dtoProduct.Idproduct, "P",this.invoice.IdInvoice, dtoProduct.Name, nudAmount.Value, dtoProduct.Price, netprice, priceIva);
                txtTotal.Text = (this.totalIva).ToString();
                txtTotalNeto.Text = (this.totalNeto).ToString();
                //insertamos en la tabla y borramos las casillas
                clearproduct();
            }
            else
            {
                for (int i = 0; i < dgvInv.RowCount; i++)
                {
                    String id = dgvInv.Rows[i].Cells[0].Value.ToString();
                    String name = dgvInv.Rows[i].Cells[3].Value.ToString();
                    int amount = Int32.Parse(dgvInv.Rows[i].Cells[4].Value.ToString());
                    float price = float.Parse(dgvInv.Rows[i].Cells[5].Value.ToString());
                    float net_price = float.Parse(dgvInv.Rows[i].Cells[6].Value.ToString());
                    float priceiva = float.Parse(dgvInv.Rows[i].Cells[7].Value.ToString());

                    //si hay alguna coincidencia en la tabla de id y nombre sumamos cantidades y precios
                    if (dtoProduct.Idproduct.Equals(id) && dtoProduct.Name.Equals(name))
                    {

                        dgvInv.Rows[i].Cells[4].Value = amount + nudAmount.Value;
                        net_price = net_price + (price * float.Parse(nudAmount.Value.ToString()));
                        dgvInv.Rows[i].Cells[6].Value = net_price;
                        priceiva = net_price + (net_price * IVA / 100);
                        dgvInv.Rows[i].Cells[7].Value = priceiva;
                        this.totalIva = totalIva + (price + (price * IVA / 100) * float.Parse(nudAmount.Value.ToString()));
                        totalNeto += net_price;
                        totalNeto = (float)Math.Round(net_price, 2);
                        txtTotal.Text = totalIva.ToString();
                        txtTotalNeto.Text = (this.totalNeto).ToString();
                        clearproduct();

                    }
                }
            }
        }
        private void clearproduct()
        {
            dtoProduct = null;
            txtProduct.Text = null;
            nudAmount.Value = 1;
            txtPriceProduct.Text = null;
        }
        public void updateProduct(DtoProduct product)
        {
            // Console.WriteLine(product.Name);
            this.dtoProduct = product;
            txtProduct.Text = product.Name;
            txtPriceProduct.Text = product.Price;

        }

        public bool searchProduct(DtoProduct dtoProduct)
        {

            for (int i = 0; i < dgvInv.RowCount; i++)
            {
                String type = dgvInv.Rows[i].Cells[1].Value.ToString();
                String id = dgvInv.Rows[i].Cells[0].Value.ToString();
                if (type.Equals("P") && dtoProduct.Idproduct.Equals(id)){
                    return true;

                }
            }
            return false;
        }
    }
   
}
