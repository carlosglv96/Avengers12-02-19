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

namespace Avengers.Presentacion.Cashbook.PPayment
{
    public partial class viewPPayment : Form
    {
        private String idioma;
        private User u;

        public viewPPayment(String idioma,User u)
        {
            this.idioma = idioma;
            this.u = u;
            InitializeComponent();
            dateFrom.Enabled = chkFrom.Checked;
            dateTo.Enabled = chkTo.Checked;
            cmbSource.Enabled = chkSource.Checked;
            
            initCmbSource("");
            
            initDGV(" where P.Paid =0");

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
        }

        public void idioma_es()
        {
            lblSource.Text = Avengers.Recursos.Espanol.lblSource;
            lblAmount.Text = Avengers.Recursos.Espanol.lblAmount;
            btnAdd.Text = Avengers.Recursos.Espanol.btnAdd;
            lblFrom.Text = Avengers.Recursos.Espanol.lblFrom;
            lblTo.Text = Avengers.Recursos.Espanol.lblTo;
            lblConcept.Text = Avengers.Recursos.Espanol.lblConcept;
            btnClear.Text = Avengers.Recursos.Espanol.btnClean;
            btnTake.Text = Avengers.Recursos.Espanol.btnTake;
        }

        public void idioma_en()
        {
            lblSource.Text = Avengers.Recursos.Ingles.lblSource;
            lblAmount.Text = Avengers.Recursos.Ingles.lblAmount;
            btnAdd.Text = Avengers.Recursos.Ingles.btnAdd;
            lblFrom.Text = Avengers.Recursos.Ingles.lblFrom;
            lblTo.Text = Avengers.Recursos.Ingles.lblTo;
            lblConcept.Text = Avengers.Recursos.Ingles.lblConcept;
            btnClear.Text = Avengers.Recursos.Ingles.btnClean;
            btnTake.Text = Avengers.Recursos.Ingles.btnTake;
        }

        private void initCmbSource(String cond)
        {
            PPayments pay = new PPayments();
            pay.getGestor().readInDB("ID  ,TEXT", "TYPES_PPAYMENT", cond);
            DataTable dt = pay.getGestor().getPPayments();

            cmbSource.DataSource = dt;
            cmbSource.DisplayMember = "TEXT";
            cmbSource.ValueMember = "ID";

            cmbSource.SelectedIndex = -1;

        }

        private void initDGV(String cond)
        {
            String sql = "Select P.ID, P.DATE_PPAYMENT, P.REFUSER, U.NAME,P.REFPPAYMENT,TP.TEXT,P.TEXT  DESCRIP,P.AMOUNT,P.PAID  "
                          + " from PPAYMENT P inner join USUARIO U on REFUSER = IDUSER "
                          + " inner join TYPES_PPAYMENT TP on REFPPAYMENT = TP.ID ";
            String order = " order by P.ID desc";
            dgvPPayment.Columns.Clear();
            PPayments pp = new PPayments();
            pp.getGestor().readInDB(sql + cond+ order);

            DataTable tPPayment = pp.getGestor().getPPayments();

            if (this.idioma == "ESPAÑOL")
            {
                dgvPPayment.Columns.Add("P.ID", "ID");
                dgvPPayment.Columns.Add("P.DATE_PPAYMENT", "FECHA");
                dgvPPayment.Columns.Add("P.REFUSER", "IDUSUARIO");
                dgvPPayment.Columns.Add("U.NAME", "USUARIO");
                dgvPPayment.Columns.Add("P.REFPPAYMENT", "REF PENDIENTE PAGO");
                dgvPPayment.Columns.Add("TP.TEXT", "PENDIENTE PAGO");
                dgvPPayment.Columns.Add("DESCRIP", "DESCRIPCION");
                dgvPPayment.Columns.Add("P.AMOUNT", "CANTIDAD");
                dgvPPayment.Columns.Add("P.PAID", "PAGADO");
            }
            else if (this.idioma == "INGLES")
            {
                dgvPPayment.Columns.Add("P.ID", "ID");
                dgvPPayment.Columns.Add("P.DATE_PPAYMENT", "DATE");
                dgvPPayment.Columns.Add("P.REFUSER", "IDUSER");
                dgvPPayment.Columns.Add("U.NAME", "USER");
                dgvPPayment.Columns.Add("P.REFPPAYMENT", "REF PENDING PAYMENT");
                dgvPPayment.Columns.Add("TP.TEXT", "PENDING PAYMENT");
                dgvPPayment.Columns.Add("DESCRIP", "CONCEPT");
                dgvPPayment.Columns.Add("P.AMOUNT", "AMOUNT");
                dgvPPayment.Columns.Add("P.PAID", "PAID");

            }

            foreach (DataRow row in tPPayment.Rows)
            {
                dgvPPayment.Rows.Add(row["ID"], row["DATE_PPAYMENT"],row["REFUSER"], row["NAME"], row["REFPPAYMENT"],row["TEXT"], row["DESCRIP"], row["AMOUNT"], row["PAID"]);
            }
            dgvPPayment.Columns["P.ID"].Visible = false;
            dgvPPayment.Columns["P.REFUSER"].Visible = false;
            dgvPPayment.Columns["P.REFPPAYMENT"].Visible = false;
            dgvPPayment.Columns["P.PAID"].Visible = false;
            dgvPPayment.ClearSelection();


        }

        private void filtrar()
        {
            String query = " Where P.Paid=0 ";
            if (cmbSource.SelectedIndex > -1 && chkSource.Checked)
            {
                query += " and P.REFPPAYMENT=" + cmbSource.SelectedValue.ToString();
            }
            if (!String.IsNullOrEmpty(txtConcep.Text.Replace("'","")))
            {
                query += " and Upper(p.text) like '%"+txtConcep.Text.ToUpper().Replace("'", "") + "%'";
            }
            if (!String.IsNullOrEmpty(txtAmount.Text.Replace("'", "")))
            {
                query += " and p.amount like '" + txtAmount.Text.Replace("'", "") + "%'";
            }
            if (dateFrom.Enabled)
            {
                query += " and p.date_ppayment >= to_date('" + dateFrom.Text + "','dd/MM/yyyy') ";
            }
            if (dateTo.Enabled)
            {
                query += " and p.date_ppayment <= to_date('" + dateTo.Text + "','dd/MM/yyyy') ";
            }
            //Console.WriteLine(query);
            initDGV(query);
        }


        private void cmbSource_SelectedIndexChanged(object sender, EventArgs e)
        {

            filtrar();
            

        }

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddPPayment ap = new AddPPayment(this.idioma, this.u);
            ap.ShowDialog();
            if (ap.IsDisposed)
            {
                initDGV(" where P.Paid =0");
            }
        }

        private void txtConcep_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbSource.SelectedIndex = -1;
            txtAmount.Text = null;
            txtConcep.Text = null;
            dateFrom.Value = DateTime.Today;
            dateTo.Value = DateTime.Today;
            chkFrom.Checked = false;
            chkTo.Checked = false;
            chkSource.Checked = false;


            //fechas
        }

        private void btnTake_Click(object sender, EventArgs e)
        {
            try
            {
                DtoPPayment pp = new DtoPPayment(
                    dgvPPayment.Rows[dgvPPayment.CurrentRow.Index].Cells[0].Value.ToString(),
                    dgvPPayment.Rows[dgvPPayment.CurrentRow.Index].Cells[1].Value.ToString(),
                    dgvPPayment.Rows[dgvPPayment.CurrentRow.Index].Cells[2].Value.ToString(),
                    dgvPPayment.Rows[dgvPPayment.CurrentRow.Index].Cells[3].Value.ToString(),
                    dgvPPayment.Rows[dgvPPayment.CurrentRow.Index].Cells[4].Value.ToString(),
                    dgvPPayment.Rows[dgvPPayment.CurrentRow.Index].Cells[5].Value.ToString(),
                    dgvPPayment.Rows[dgvPPayment.CurrentRow.Index].Cells[6].Value.ToString(),
                    dgvPPayment.Rows[dgvPPayment.CurrentRow.Index].Cells[7].Value.ToString(),
                    dgvPPayment.Rows[dgvPPayment.CurrentRow.Index].Cells[8].Value.ToString());

                TakePPayment tp = new TakePPayment(this.idioma, pp);
                tp.ShowDialog();
                if (tp.IsDisposed)
                {
                    initDGV(" where P.Paid =0");
                }
            }
            catch (Exception ex)
            {
                if (this.idioma == "ESPAÑOL")
                {
                    MessageBox.Show("Debes seleccionar un Pago Pendiente");
                }
                else
                {
                    MessageBox.Show("You must Select a Pending Payment");
                }

            }
        }

        private void chkFrom_CheckedChanged(object sender, EventArgs e)
        {
            dateFrom.Enabled = chkFrom.Checked; 
            filtrar();
        }

        private void chkTo_CheckedChanged(object sender, EventArgs e)
        {
            dateTo.Enabled = chkTo.Checked;
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

        private void chkSource_CheckedChanged(object sender, EventArgs e)
        {
            cmbSource.Enabled = chkSource.Checked;
            if (!chkSource.Checked)
            {
                cmbSource.SelectedIndex = -1;
            }
        }

        private void PPayment_Shown(object sender, EventArgs e)
        {
            dgvPPayment.ClearSelection();
        }

 
    }
    
}
