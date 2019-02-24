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

namespace Avengers.Presentacion.Cashbook.Validation
{
    public partial class ViewValidation : Form
    {
        private String idioma;
        private User u;
        private Menu m;
        public ViewValidation(String idioma, User u, Menu m)
        {
            this.idioma = idioma;
            this.u = u;
            this.m = m;
            InitializeComponent();

            if (this.idioma == "ESPAÑOL")
            {
                idioma_es();
                this.Text = "Pagos Pendientes";
            }
            else
            {
                idioma_en();
                this.Text = "Pending Payment";
            }
            initDGV();


        }

        public void idioma_es()
        {
            DateTime d = DateTime.Now;
            date.Value = d;
            date.Enabled = false;
            lblDate.Text = Avengers.Recursos.Espanol.lblDate;
            btnValida.Text ="Pulsa para validar";
        }

        public void idioma_en()
        {
            DateTime d = DateTime.Now;
            date.Value = d;
            date.Enabled = false;
            lblDate.Text = Avengers.Recursos.Ingles.lblDate;
            btnValida.Text = "Push to validation";
        }

        private void initDGV()
        {
            String sql = "SELECT V.ID, V.DATE_DEBTS, U.NAME, V.AINCASH, V.ARECEIPT, V.ACHECK, V.TOTAL  "
                          + " FROM VALIDATIONS V inner join USUARIO U on REFUSER = IDUSER "
                          + " order by V.DATE_DEBTS desc ";
            dgvValida.Columns.Clear();
            Dominio.Validation v = new Dominio.Validation();
            v.getGestor().readTable2(sql);

            DataTable tValidation = v.getGestor().getValidation();

            if (this.idioma == "ESPAÑOL")
            {
                dgvValida.Columns.Add("V.ID", "ID");
                dgvValida.Columns.Add("V.DATE_DEBTS", "FECHA");
                dgvValida.Columns.Add("U.NAME", "NOMBRE");
                dgvValida.Columns.Add("V.AINCASH", "EN CAJA");
                dgvValida.Columns.Add("V.ARECEIPT", "RECIBO");
                dgvValida.Columns.Add("V.ACHECK", "CHEQUE");
                dgvValida.Columns.Add("V.TOTAL", "TOTAL");                
            }
            else if (this.idioma == "INGLES")
            {
                dgvValida.Columns.Add("V.ID", "ID");
                dgvValida.Columns.Add("V.DATE_DEBTS", "DATE");
                dgvValida.Columns.Add("U.NAME", "NAME");
                dgvValida.Columns.Add("V.AINCASH", "IN-CASH");
                dgvValida.Columns.Add("V.ARECEIPT", "RECEIPT");
                dgvValida.Columns.Add("V.ACHECK", "CHECK");
                dgvValida.Columns.Add("V.TOTAL", "TOTAL");            

            }

            foreach (DataRow row in tValidation.Rows)
            {
                dgvValida.Rows.Add(row["ID"], row["DATE_DEBTS"], row["NAME"], row["AINCASH"], row["ARECEIPT"], row["ACHECK"], row["TOTAL"]);
            }
            dgvValida.Columns["V.ID"].Visible = false;

            dgvValida.ClearSelection();


        }

        private void btnValida_Click(object sender, EventArgs e)
        {
            Double caja = double.Parse(m.txbcash.Text);
            Double recibo = double.Parse(m.txbreceip.Text);
            Double cheque = double.Parse(m.txbcheck.Text);
            Double total = double.Parse(m.texbtotal.Text);

            String sql = "Insert into validations values (null, trunc(SYSDATE)," + u.getId()+",'"+caja+"','"+ recibo + "','"+ cheque + "','"+ total + "')";
            Dominio.Validation v = new Dominio.Validation();
            v.getGestor().insertValidation(sql);
            initDGV();
        }

        private void Validation_Shown(object sender, EventArgs e)
        {
            dgvValida.ClearSelection();
        }
    }
}
