using Avengers.Dominio;
using Avengers.Dominio.Gestores;
using System;
using System.Windows.Forms;

namespace Avengers.Presentacion.Cashbook.Debts
{

    public partial class AddDebt : Form
    {

        private string idioma;
        private User u;

        public AddDebt(String idioma, User u)
        {
            this.idioma = idioma;
            this.u = u;

            InitializeComponent();
            txtUser.Text = u.getNombre();
            intervaloFechas();

            if (this.idioma == "ESPAÑOL")
            {
                idioma_es();
                this.Text = "Añadir Deuda";
            }
            else
            {
                idioma_en();
                this.Text = "Add Debt";
            }
        }

        public void idioma_es()
        {
            lblUser.Text = Recursos.Espanol.lblUser;
            lblAmount.Text = Recursos.Espanol.lblAmount;
            btnAdd.Text = Recursos.Espanol.btnAdd;
            lblDate.Text = Recursos.Espanol.lblDate;
            lblConcept.Text = Recursos.Espanol.lblConcept;
            btnCancel.Text = Recursos.Espanol.btnCancel;
        }

        public void idioma_en()
        {
            lblUser.Text = Recursos.Ingles.lblUser;
            lblAmount.Text = Recursos.Ingles.lblAmount;
            btnAdd.Text = Recursos.Ingles.btnAdd;
            lblDate.Text = Recursos.Ingles.lblDate;
            lblConcept.Text = Recursos.Ingles.lblConcept;
            btnCancel.Text = Recursos.Ingles.btnCancel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(checkAdd());
            if (checkAdd())
            {
                String sql = insertSql();
                GestorDebts.insertDebt(sql);
                Dispose();
            }
            else
            {
                MessageBox.Show(errorDialog());
            }
        }

        private String errorDialog()
        {
            if (this.idioma == "ESPAÑOL")
            {
                String error = "Se han encontrado algunos errores: \n";

                if (string.IsNullOrEmpty(txtAmount.Text.Replace("'","")))
                {
                    error += "\t - El campo \"Cantidad\" no puede estar vacío. \n";
                }
                if (string.IsNullOrEmpty(txtConcept.Text.Replace("'", "")))
                {
                    error += "\t - El campo \"Descripción\" no puede estar vacío. \n";
                }
                if (!Utils.check.checkAmountPos(txtAmount.Text.Replace("'", "")))
                {
                    error += "\t - El campo \"Cantidad\" tiene parámetros incorrectos. \n";
                }
                return error;
            }
            else
            {
                String error = "Some errors have been found: \n";

                if (string.IsNullOrEmpty(txtAmount.Text.Replace("'", "")))
                {
                    error += "\t - The field \"Amount\" can't be empty. \n";
                }
                if (string.IsNullOrEmpty(txtConcept.Text.Replace("'", "")))
                {
                    error += "\t - The field \"Concept\" can't be empty. \n";
                }
                if (!Utils.check.checkAmountPos(txtAmount.Text.Replace("'", "")))
                {
                    error += "\t - The field \"Amount\" has wrong parameters.  \n";
                }

                return error;
            }

        }

        private bool checkAdd()
        {
            return !String.IsNullOrEmpty(txtAmount.Text.Replace("'", "")) && !String.IsNullOrEmpty(txtConcept.Text.Replace("'", "")) && Utils.check.checkAmountPos(txtAmount.Text.Replace(".",","));
            
        }

        private String insertSql()
        {
            String concept = txtConcept.Text.ToUpper().Replace("'", "");
            String amount = txtAmount.Text.Replace("'", "").Replace(".", ",");
            Double amnt = Convert.ToDouble(amount);
            amnt = Math.Round(amnt, 2);

            String sql = "insert into DEBTS values (null, '" + dateDebt.Value.ToString("dd/MM/yyyy") + "', " + this.u.getId() + ", '" + concept + "', '" + amnt + "', 0)";
            return sql;
        }
        
        private void intervaloFechas()
        {
            dateDebt.MinDate = DateTime.Today.AddDays(-10);
            dateDebt.MaxDate = DateTime.Today;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

    }

}