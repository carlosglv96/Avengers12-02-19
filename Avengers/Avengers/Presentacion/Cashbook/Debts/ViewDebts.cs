using Avengers.Dominio;
using System;
using System.Data;
using System.Windows.Forms;

namespace Avengers.Presentacion.Cashbook.Debts
{

    public partial class ViewDebts : Form
    {

        private String idioma;
        private User u;
        private Menu m;

        public ViewDebts(String idioma, User u, Menu m)
        {
            this.idioma = idioma;
            this.u = u;
            this.m = m;

            InitializeComponent();
            initTable(" where D.PAID = 0");

            if (this.idioma == "ESPAÑOL")
            {
                idioma_es();
                this.Text = "Deudas";
            }
            else
            {
                idioma_en();
                this.Text = "Debts";
            }
        }

        private void idioma_es()
        {
            lblAmount.Text = Recursos.Espanol.lblAmount;
            lblConcept.Text = Recursos.Espanol.lblDescrip;
            lblFrom.Text = Recursos.Espanol.lblFrom;
            lblTo.Text = Recursos.Espanol.lblTo;
            btnAdd.Text = Recursos.Espanol.btnAdd;
            btnPay.Text = Recursos.Espanol.btnPay;
        }

        private void idioma_en()
        {
            lblAmount.Text = Recursos.Ingles.lblAmount;
            lblConcept.Text = Recursos.Ingles.lblDescrip;
            lblFrom.Text = Recursos.Ingles.lblFrom;
            lblTo.Text = Recursos.Ingles.lblTo;
            btnAdd.Text = Recursos.Ingles.btnAdd;
            btnPay.Text = Recursos.Ingles.btnPay;
        }

        private void initTable(String cond)
        {
            String sql = "select D.ID, D.DATE_DEBTS, D.REFUSER, U.NAME, D.TEXT, D.AMOUNT, D.PAID from DEBTS D inner join USUARIO U on REFUSER = IDUSER ";
            dgvDebts.Columns.Clear();

            Debt d = new Debt();
            d.getGestor().readInDB(sql + cond + " order by D.ID desc");
            DataTable tDebts = d.getGestor().getDebts();

            if (this.idioma == "ESPAÑOL")
            {
                dgvDebts.Columns.Add("D.ID", "ID");
                dgvDebts.Columns.Add("D.DATE_DEBTS", "FECHA");
                dgvDebts.Columns.Add("D.REFUSER", "IDUSUARIO");
                dgvDebts.Columns.Add("U.NAME", "USUARIO");
                dgvDebts.Columns.Add("D.TEXT", "DESCRIPCION");
                dgvDebts.Columns.Add("D.AMOUNT", "CANTIDAD");
                dgvDebts.Columns.Add("D.PAID", "PAGADO");
            }
            else if (this.idioma == "INGLES")
            {
                dgvDebts.Columns.Add("D.ID", "ID");
                dgvDebts.Columns.Add("D.DATE_DEBTS", "DATE");
                dgvDebts.Columns.Add("D.REFUSER", "IDUSER");
                dgvDebts.Columns.Add("U.NAME", "USER");            
                dgvDebts.Columns.Add("D.TEXT", "CONCEPT");
                dgvDebts.Columns.Add("D.AMOUNT", "AMOUNT");
                dgvDebts.Columns.Add("D.PAID", "PAID");
            }

            foreach (DataRow row in tDebts.Rows)
            {
                dgvDebts.Rows.Add(row["ID"], row["DATE_DEBTS"], row["REFUSER"], row["NAME"], row["TEXT"], row["AMOUNT"], row["PAID"]);
            }

            dgvDebts.Columns["D.ID"].Visible = false;
            dgvDebts.Columns["D.REFUSER"].Visible = false;
            dgvDebts.Columns["D.PAID"].Visible = false;

            dgvDebts.ClearSelection();
        }

        private void filtrar()
        {
            String query = " where D.PAID = 0 ";
            if (!String.IsNullOrEmpty(txtConcept.Text.Replace("'", "")))
            {
                query += " and upper(D.TEXT) like '%" + txtConcept.Text.ToUpper() + "%'";
            }
            if (!String.IsNullOrEmpty(txtAmount.Text.Replace("'", "")))
            {
                query += " and D.AMOUNT like '" + txtAmount.Text + "%'";
            }
            query += " and D.DATE_DEBTS >= to_date('" + dateFrom.Text + "','dd/MM/yyyy') ";
            query += " and D.DATE_DEBTS <= to_date('" + dateTo.Text + "','dd/MM/yyyy') ";
            
            initTable(query);
        }

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar();
        }

        private void txtConcept_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar();
        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void dateTo_ValueChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddDebt ad = new AddDebt(this.idioma, this.u);
            ad.ShowDialog();
            if (ad.IsDisposed)
            {
                initTable("where D.PAID = 0");
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtAmount.Text = null;
            txtConcept.Text = null;
            dateFrom.Value = DateTime.Today;
            dateTo.Value = DateTime.Today;
            initTable("where D.PAID = 0");
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                DtoDebt dto = new DtoDebt(
                    dgvDebts.Rows[dgvDebts.CurrentRow.Index].Cells[0].Value.ToString(),
                    dgvDebts.Rows[dgvDebts.CurrentRow.Index].Cells[1].Value.ToString(),
                    dgvDebts.Rows[dgvDebts.CurrentRow.Index].Cells[2].Value.ToString(),
                    dgvDebts.Rows[dgvDebts.CurrentRow.Index].Cells[3].Value.ToString(),
                    dgvDebts.Rows[dgvDebts.CurrentRow.Index].Cells[4].Value.ToString(),
                    dgvDebts.Rows[dgvDebts.CurrentRow.Index].Cells[5].Value.ToString(),
                    dgvDebts.Rows[dgvDebts.CurrentRow.Index].Cells[6].Value.ToString());

                PayDebt pd = new PayDebt(this.idioma, dto, this.m);
                pd.ShowDialog();

                if (pd.IsDisposed)
                {
                    initTable(" where D.PAID = 0");
                }
            }
            catch (Exception ex)
            {
                if (this.idioma == "ESPAÑOL")
                {
                    MessageBox.Show("Debes seleccionar una deuda.");
                }
                else
                {
                    MessageBox.Show("You must select a debt.");
                }
            }
        }

        private void Debts_Shown(object sender, EventArgs e)
        {
            dgvDebts.ClearSelection();
        }
    }

}