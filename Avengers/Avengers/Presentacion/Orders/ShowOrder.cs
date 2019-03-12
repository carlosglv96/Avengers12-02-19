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

namespace Avengers.Presentacion.Orders
{
    public partial class ShowOrder : Form
    {
        //public String idOrder;
        //private String pay;
        //private String fecha;
        //private String total;
        private String idioma;
        private DtoOrder dto;
        public ShowOrder(String idioma, DtoOrder dto)
        {
            InitializeComponent();
            this.idioma = idioma;
            this.dto = dto;
            this.lblSetPedido.Text = dto.IdOrder;
            this.lblSetPay.Text = dto.PayMethod;
            this.lblSetDate.Text = dto.Date;
            this.lblSetTotal.Text = dto.Total;
            lblSetCustomer.Text = dto.Nombre + " " + dto.Apellido;
            if (this.idioma == "ESPAÑOL")
            {
                idioma_es();
            }
            else
            {
                idioma_en();
            }
            iniDGV();
        }

        public void idioma_es()
        {
            this.lblCliente.Text = "CLIENTE:";
            this.lblDate.Text = "FECHA:";
            this.lblPago.Text = "FORMA PAGO:";
            this.lblPedido.Text = "N PEDIDO:";
            this.lblTotal.Text = "TOTAL:";
        }
        public void idioma_en()
        {
            this.lblCliente.Text = "CUSTOMER:";
            this.lblDate.Text = "DATE:";
            this.lblPago.Text = "PAY METHOD:";
            this.lblPedido.Text = "N ORDER:";
            this.lblTotal.Text = "TOTAL:";
        }

        public void iniDGV()
        {

            dgvOrders.Columns.Clear();

            OrderProduct op = new OrderProduct();
            String columnas = " o.idorderproduct, o.reforder,o.refproduct, p.name, o.amount, o.pricesale ";
            String tablas = "  ordersproducts o inner join products p on refproduct=idproduct ";
            String condi = " where o.reforder= " + dto.IdOrder;
            // Console.WriteLine(columnas + tablas + condi);
            op.getGestor().readInDB(columnas, tablas, condi);


            DataTable torders = op.getGestor().getOrderProduct();
            dgvOrders.Columns.Clear();

            if (this.idioma == "ESPAÑOL")
            {
                dgvOrders.Columns.Add("IDORDERPRODUCT", "IDORDERPRODUCT");
                dgvOrders.Columns.Add("REFORDER", "REFORDER");
                dgvOrders.Columns.Add("REFPRODUCT", "IDPRODUCTO");
                dgvOrders.Columns.Add("NAME", "PRODUCTO");
                dgvOrders.Columns.Add("AMOUNT", "CANTIDAD");
                dgvOrders.Columns.Add("PRICESALE", "PRECIO DE VENTA");

            }
            else
            {
                dgvOrders.Columns.Add("IDORDERPRODUCT", "ID");
                dgvOrders.Columns.Add("REFORDER", "REFORDER");
                dgvOrders.Columns.Add("REFPRODUCT", "IDPRODUCT");
                dgvOrders.Columns.Add("NAME", "PRODUCT");
                dgvOrders.Columns.Add("AMOUNT", "AMOUNT");
                dgvOrders.Columns.Add("PRICESALE", "PRICESALE");

            }


            foreach (DataRow row in torders.Rows)
            {
                dgvOrders.Rows.Add(row["IDORDERPRODUCT"], row["REFORDER"], row["REFPRODUCT"], row["NAME"], row["AMOUNT"], row["PRICESALE"]);
            }

            dgvOrders.Columns["IDORDERPRODUCT"].Visible = false;
            dgvOrders.Columns["REFORDER"].Visible = false;
            dgvOrders.Columns["REFPRODUCT"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
