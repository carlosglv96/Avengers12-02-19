using Avengers.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avengers.Presentacion.Orders.PrintInvoOrder
{
    public partial class InvoOrder : Form
    {
        private int idCusto;
        private int idOrder;
        private int idInvoice;
        public InvoOrder(int refCusto, int idOrder, int idInvoice, int refTipo)
        {
            InitializeComponent();

            this.idCusto = refCusto;
            this.idOrder = idOrder;
            this.idInvoice = idInvoice;
        }

        private DataTable llenaInvo()
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();
            DataTable tcustomers = new DataTable();

            tcustomers.Columns.Add("id", Type.GetType("System.String"));
            tcustomers.Columns.Add("fecha", Type.GetType("System.String"));
            tcustomers.Columns.Add("total", Type.GetType("System.String"));
            tcustomers.Columns.Add("totaliva", Type.GetType("System.String"));
            tcustomers.Columns.Add("iva", Type.GetType("System.String"));

            data = search.getData("select idinvoice, date_invoice, net_amount, amount, ROUND(amount - net_amount, 2) as iva from invoices where idinvoice = " + idInvoice, "cus");
            DataTable tmp = data.Tables["cus"];

            foreach (DataRow row in tmp.Rows)
            {
                tcustomers.Rows.Add(new Object[] { row["idinvoice"], row["date_invoice"], row["net_amount"], row["amount"], row["iva"] });
            }

            return tcustomers;
        }

        private DataTable llenaCusto()
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();
            DataTable tcustomers = new DataTable();
            String aux;

            tcustomers.Columns.Add("nombre", Type.GetType("System.String"));
            tcustomers.Columns.Add("ape", Type.GetType("System.String"));
            tcustomers.Columns.Add("cp", Type.GetType("System.String"));
            tcustomers.Columns.Add("pob", Type.GetType("System.String"));
            tcustomers.Columns.Add("pro", Type.GetType("System.String"));
            tcustomers.Columns.Add("dir", Type.GetType("System.String"));
            tcustomers.Columns.Add("tel", Type.GetType("System.String"));
            tcustomers.Columns.Add("dni", Type.GetType("System.String"));

            data = search.getData("select * from customers where idcustomer = " + idCusto, "cus");
            DataTable tmp = data.Tables["cus"];

            foreach (DataRow row in tmp.Rows)
            {
                tcustomers.Rows.Add(new Object[] { row["name"], row["surname"], row["address"], row["refzipcodescities"], row["phone"], row["address"], row["phone"], row["dni"] });
            }
            //tcustomers.Rows.Add(new Object[] { "NOMBRE", "APE", "CP", "POBLA", "PROV", "DIRE", "TEL", "DNI" });
            DataTable tempo = new DataTable();
            tempo.Columns.Add("1", Type.GetType("System.String"));
            tempo.Columns.Add("2", Type.GetType("System.String"));
            tempo.Columns.Add("3", Type.GetType("System.String"));

            DataSet data1 = search.getData("select refzipcode, refcity, refstate from ZIPCODESCITIES where IDZIPCODESCITIES = " + tcustomers.Rows[0][3].ToString(), "ojo");
            tmp = data1.Tables["ojo"];
            foreach (DataRow row in tmp.Rows)
            {
                tempo.Rows.Add(new Object[] { row["refzipcode"], row["refcity"], row["refstate"] });
            }

            tcustomers.Rows[0][2] = search.getData("select zipcode from ZIPCODES where IDZIPCODE = " + tempo.Rows[0][0].ToString());
            tcustomers.Rows[0][3] = search.getData("select city from CITIES where IDCITY = " + tempo.Rows[0][1].ToString());
            tcustomers.Rows[0][4] = search.getData("select state from STATES where IDSTATE = " + tempo.Rows[0][2].ToString());


            return tcustomers;
        }

        private DataTable llenaPro()
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();
            DataTable tcustomers = new DataTable();

            tcustomers.Columns.Add("cant", Type.GetType("System.String"));
            tcustomers.Columns.Add("nombre", Type.GetType("System.String"));
            tcustomers.Columns.Add("precio", Type.GetType("System.String"));
            tcustomers.Columns.Add("total", Type.GetType("System.String"));


            String sql1 = "select p.name as PRODUCT ,ip.amount as AMOUNT ,p.price AS UNIPRICE, ROUND(ip.amount * p.price, 2) as PRICE " +
                            "from products p inner join invoices_products ip on p.idproduct = ip.refproduct " +
                            "where ip.refinvoice = " + idInvoice +
                            " union " +
                            "select l.description as PRODUCT,l.quantity as AMOUNT, l.price AS UNIPRICE, ROUND(l.quantity * l.price, 2) as PRICE " +
                            "from lines l " +
                            "where l.refinvoice = " + idInvoice +
                            " union " +
                            "select p.name as PRODUCT ,op.amount as AMOUNT,op.pricesale AS UNIPRICE, ROUND(op.amount * op.pricesale, 2) as PRICE " +
                            "from products p inner join ordersproducts op on p.idproduct = op.refproduct " +
                            "inner join orders_invoices oi on op.reforder = oi.reforder " +
                            "where oi.refinvoice = " + idInvoice;

            //String sql = " select p.idproduct as ID,'P' as TYPE, ip.refinvoice as REFINVOICE ,p.name as PRODUCT ,ip.amount as AMOUNT ,p.price AS UNIPRICE, ROUND(ip.amount*p.price+(ip.amount*p.price*" + IVA + "/100),2) as PRICE" +
            //                " from products p inner join invoices_products ip on p.idproduct=ip.refproduct " +
            //                " where ip.refinvoic e= 20190002" +
            //              " union " +
            //              " select  l.idline as ID,'L' as type, l.refinvoice as REFINVOICE,l.description as PRODUCT,l.quantity as AMOUNT, l.price  AS UNIPRICE, ROUND(l.quantity*l.price+(l.quantity*l.price*" + IVA + "/100),2) as PRICE" +
            //                 " from lines l " +
            //                 " where l.refinvoice = 20190002" +
            //              " union " +
            //              " select p.idproduct as ID ,'O' as type, oi.refinvoice as REFINVOICE, p.name as PRODUCT ,op.amount as AMOUNT,op.pricesale  AS UNIPRICE, ROUND(op.amount*op.pricesale+(op.amount*op.pricesale*" + IVA + "/100),2) as PRICE " +
            //                 " from products p inner join ordersproducts op on p.idproduct = op.refproduct " +
            //                 " inner join orders_invoices oi on op.reforder = oi.reforder " +
            //                 " where oi.refinvoice = 20190002";


            data = search.getData(sql1, "cus");
            DataTable tmp = data.Tables["cus"];

            foreach (DataRow row in tmp.Rows)
            {
                tcustomers.Rows.Add(new Object[] { row["AMOUNT"], row["PRODUCT"], row["UNIPRICE"], row["PRICE"] });
            }
            //tcustomers.Rows.Add(new Object[] { "CANTIDAD", "DESCRIP", "PRECIO", "TOTAL" });

            return tcustomers;
        }

        private DataTable llenaOrd()
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();
            DataTable tcustomers = new DataTable();

            tcustomers.Columns.Add("forma", Type.GetType("System.String"));


            //data = search.getData("select * from invoices where idinvoice = " + "20190001", "cus");
            //DataTable tmp = data.Tables["cus"];

            //foreach (DataRow row in tmp.Rows)
            //{
            //tcustomers.Rows.Add(new Object[] { row["idinvoice"], row["date_invoice"], row["net_amount"], row["amount"] });
            //}
            String tipo = search.getData("select PAYMENTMETHOD from PAYMENTMETHODS where IDPAYMENTMETHOD = " + 3);
            tcustomers.Rows.Add(new Object[] { tipo });

            return tcustomers;
        }

        private void Load(object sender, EventArgs e)
        {
            DataTable tinvo = llenaInvo();
            DataTable tcus = llenaCusto();
            DataTable tpro = llenaPro();
            DataTable to = llenaOrd();

            Crys miReporte = new Crys();
            miReporte.Database.Tables["invo"].SetDataSource(tinvo);
            miReporte.Database.Tables["custo"].SetDataSource(tcus);
            miReporte.Database.Tables["produ"].SetDataSource(tpro);
            miReporte.Database.Tables["order"].SetDataSource(to);


            crystalReportViewer1.ReportSource = miReporte;
        }
    }
}
