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

namespace Avengers.Presentacion.Cashbook
{
    public partial class AddIncomes : Form
    {
        public User user;
        private int refaction;
        private String idioma;
        
        
        public AddIncomes(int refact, String idioma, User us)
        {
            this.user = us;
            this.refaction = refact;
            this.idioma = idioma;
            InitializeComponent();
            initComboSource();
            initComboType();
            intervaloFechas();
            if (this.idioma == "ESPAÑOL" & this.refaction == 0)
            {
                idioma_es();
                this.Text = "Entradas";
            }
            else if (this.idioma == "ESPAÑOL" & this.refaction == 1)
            {
                idioma_es();
                this.Text = "Salidas";
            }
            else if (this.idioma == "INGLES" & this.refaction == 0)
            {
                idioma_es();
                this.Text = "Incomes";
            }
            else if (this.idioma == "INGLES" & this.refaction == 1)
            {
                idioma_en();
                this.Text = "Expenses";
            }
        }

        public void idioma_es()
        {
            lblSourceAdd.Text = Avengers.Recursos.Espanol.lblSource;
            lblTypeAdd.Text = Avengers.Recursos.Espanol.lblTypes;
            lblAmountAdd.Text = Avengers.Recursos.Espanol.lblAmount;
            lblConceptAdd.Text = Avengers.Recursos.Espanol.lblConcept;
            lblDateAdd.Text = Avengers.Recursos.Espanol.lblDateAdd;
            lblUserAdd.Text = Avengers.Recursos.Espanol.lblUserAdd;
            btnAceptar.Text = Avengers.Recursos.Espanol.btnAceptar;
            btnCancel.Text = Avengers.Recursos.Espanol.btnCancel;

        }
        public void idioma_en()
        {
            lblSourceAdd.Text = Avengers.Recursos.Ingles.lblSource;
            lblTypeAdd.Text = Avengers.Recursos.Ingles.lblTypes;
            lblAmountAdd.Text = Avengers.Recursos.Ingles.lblAmount;
            lblConceptAdd.Text = Avengers.Recursos.Ingles.lblConcept;
            lblDateAdd.Text = Avengers.Recursos.Ingles.lblDateAdd;
            lblUserAdd.Text = Avengers.Recursos.Ingles.lblUserAdd;
            btnAceptar.Text = Avengers.Recursos.Ingles.btnAceptar;
            btnCancel.Text = Avengers.Recursos.Ingles.btnCancel;
        }




        private void initComboSource()
        {
            Incomes inc = new Incomes();
            if (refaction == 0)
            {
                inc.getGestor().readInDB("ID, TEXT", "SOURCE_TARGET", "Where ID<100 Order by id");
            }

            else
            {
                inc.getGestor().readInDB("ID, TEXT", "SOURCE_TARGET", "Where ID>100 Order by id");
            }

            DataTable tincome = inc.getGestor().getIncomes();
            cmbSource.DataSource = tincome;
            cmbSource.DisplayMember = "TEXT";
            cmbSource.ValueMember = "ID";
            //cmbSource.SelectedIndex = -1;

        }
        private void initComboType()
        {
            Incomes inc = new Incomes();
            inc.getGestor().readInDB("ID, TEXT", "TYPES", "Where 1=1");
            DataTable tincome = inc.getGestor().getIncomes();
            cmbTypes.DataSource = tincome;
            cmbTypes.DisplayMember = "TEXT";
            cmbTypes.ValueMember = "ID";
            //cmbTypes.SelectedIndex = -1;
        }

        private void intervaloFechas() {

            dateIncomes.MinDate = DateTime.Today.AddDays(-10);
            dateIncomes.MaxDate = DateTime.Today;
                
        }

        private bool checkAdd()
        {
            return !String.IsNullOrEmpty(txtAmount.Text.Replace("'", "")) && !String.IsNullOrEmpty(txtConceptIncomes.Text.Replace("'", ""))
                && cmbSource.SelectedIndex != -1 && cmbTypes.SelectedIndex != -1 && Utils.check.checkAmountPos(txtAmount.Text.Replace("'","").Replace(".",",")) ;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            Incomes inc = new Incomes();
            double incomes = 0;
            double cashIn = 0;
            double checkIn = 0;
            double receiptIn = 0;
            double cashEx = 0;
            double checkEx = 0;
            double receiptEx = 0;
            double totalCash = 0;
            double totalCheck = 0;
            double totalReceipt = 0;
            double expenses = 0;
            double total = 0;
            String strincomes;
            String strexpenses;
            String strtotalCashIn;
            String strtotalCashEx;
            String strtotalCheckIn;
            String strtotalCheckEx;
            String strtotalReceiptIn;
            String strtotalReceiptEx;
            String cantidad;
            double cant = 0;
            strincomes = inc.getGestor().getUnString("Select sum(amount) from INCOMES where REFACTION = 0");
            strexpenses = inc.getGestor().getUnString("Select sum(amount) from INCOMES where REFACTION = 1");
            strtotalCashIn = inc.getGestor().getUnString("Select sum(amount) from INCOMES where REFACTION = 0 AND REFTIPO = (Select ID from TYPES where UPPER(TEXT) = UPPER('CASH'))");
            strtotalCashEx = inc.getGestor().getUnString("Select sum(amount) from INCOMES where REFACTION = 1 AND REFTIPO = (Select ID from TYPES where UPPER(TEXT) = UPPER('CASH'))");
            strtotalCheckIn = inc.getGestor().getUnString("Select sum(amount) from INCOMES where REFACTION = 0 AND REFTIPO = (Select ID from TYPES where UPPER(TEXT) = UPPER('CHECK'))");
            strtotalCheckEx = inc.getGestor().getUnString("Select sum(amount) from INCOMES where REFACTION = 1 AND REFTIPO = (Select ID from TYPES where UPPER(TEXT) = UPPER('CHECK'))");
            strtotalReceiptIn = inc.getGestor().getUnString("Select sum(amount) from INCOMES where REFACTION = 0 AND REFTIPO = (Select ID from TYPES where UPPER(TEXT) = UPPER('RECEIPT'))");
            strtotalReceiptEx = inc.getGestor().getUnString("Select sum(amount) from INCOMES where REFACTION = 1 AND REFTIPO = (Select ID from TYPES where UPPER(TEXT) = UPPER('RECEIPT'))");

            if (!String.IsNullOrEmpty(strincomes)) { incomes = double.Parse(strincomes); }
            else { incomes = 0; }
            if (!String.IsNullOrEmpty(strexpenses)) { expenses = double.Parse(strexpenses); }
            else { expenses = 0; }
            if (!String.IsNullOrEmpty(strtotalCashIn)) { cashIn = double.Parse(strtotalCashIn); }
            else { cashIn = 0; }
            if (!String.IsNullOrEmpty(strtotalCheckIn)) { checkIn = double.Parse(strtotalCheckIn); }
            else { checkIn = 0; }
            if (!String.IsNullOrEmpty(strtotalReceiptIn)) { receiptIn = double.Parse(strtotalReceiptIn); }
            else { receiptIn = 0; }
            if (!String.IsNullOrEmpty(strtotalCashEx)) { cashEx = double.Parse(strtotalCashEx); }
            else { cashEx = 0; }
            if (!String.IsNullOrEmpty(strtotalCheckEx)) { checkEx = double.Parse(strtotalCheckEx); }
            else { checkEx = 0; }
            if (!String.IsNullOrEmpty(strtotalReceiptEx)) { receiptEx = double.Parse(strtotalReceiptEx); }
            else { receiptEx = 0; }
            totalCash = cashIn - cashEx;
            totalCheck = checkIn - checkEx;
            totalReceipt = receiptIn - receiptEx;
            total = incomes - expenses;
          
            if (checkAdd())
            {
                cantidad = txtAmount.Text.Replace(".", ",").Replace("'","");
                cant = Convert.ToDouble(txtAmount.Text.Replace(".",",").Replace("'",""));
                //redondeamos
                cant = Math.Round(cant, 2);

                if (this.refaction == 1 && total < cant)
                {
                    if (this.idioma == "ESPAÑOL")
                    { MessageBox.Show("Error, no se puede realizar una Salida que deje la caja en negativo"); }
                    else
                    { MessageBox.Show("Error, you can not make an Output that leaves the box in negative"); }
                }
                else if (cmbTypes.SelectedValue.ToString() == "1" && this.refaction == 1 && totalCash < cant) {

                    if (this.idioma == "ESPAÑOL")
                    { MessageBox.Show("Error, no se puede realizar una Salida que deje la caja en negativo"); }
                    else
                    { MessageBox.Show("Error, you can not make an Output that leaves the box in negative"); }
                }
                else if (cmbTypes.SelectedValue.ToString() == "2" && this.refaction == 1 && totalCheck < cant)
                {

                    if (this.idioma == "ESPAÑOL")
                    { MessageBox.Show("Error, no se puede realizar una Salida que deje los checks en negativo"); }
                    else
                    { MessageBox.Show("Error, you can not make an Output that leaves the checks in negative"); }
                }
                else if (cmbTypes.SelectedValue.ToString() == "3" && this.refaction == 1 && totalReceipt < cant)
                {

                    if (this.idioma == "ESPAÑOL")
                    { MessageBox.Show("Error, no se puede realizar una Salida que deje los recivos en negativo"); }
                    else
                    { MessageBox.Show("Error, you can not make an Output that leaves the receipts in negative"); }
                }

                else
                {

                    String fecha = dateIncomes.Value.ToString("dd/MM/yyyy").Replace("'", "");
                    String source = cmbSource.SelectedValue.ToString().Replace("'", "");
                    String type = cmbTypes.SelectedValue.ToString().Replace("'", "");
                    String concept = txtConceptIncomes.Text.ToUpper().Replace("'", "");
                    inc.getGestor().insertIncome("Insert into INCOMES VALUES('" + 0 + "','" + fecha + "','" +
                        user.getId() + "','" + source + "','" + type +
                        "','" + concept + "','" + cant + "','" + this.refaction + "')");
                    this.Dispose();
                }
            }
            else
            {

                    MessageBox.Show(errors());
               

            }

            
            
        }

        private String errors()
        {
            String error = "";
            if (this.idioma.Equals("ESPAÑOL"))
            {
                 error = "Se han encontrado los siguientes errores: \n";

                if (String.IsNullOrEmpty(txtAmount.Text.Replace("'", ""))) error += "\t - El campo Cantidad no puede estar vacio \n";

                if (!Utils.check.checkAmountPos(txtAmount.Text.Replace("'", "").Replace(".", ","))) error += "\t - El formato de la cantidad introducida no es correcto o es negativo\n"
                        +"\t Ejemplo: (xxxxx.xx) \n";

                if (String.IsNullOrEmpty(txtConceptIncomes.Text.Replace("'", ""))) error += "\t - El campo Concepto no puede estar vacio";

                if (cmbSource.SelectedIndex == -1) error += "\t - Debe selecionar un Origen \n";

                if (cmbTypes.SelectedIndex == -1) error += "\t - Debe seleccionar un tipo \n";
            }
            else
            {
                error = "Some Errors has been found: \n";

                if (String.IsNullOrEmpty(txtAmount.Text.Replace("'", ""))) error += "\t - The field \"Amount\" can`t be empty \n";

                if (!Utils.check.checkAmountPos(txtAmount.Text.Replace("'", "").Replace(".", ","))) error += "\t - The field \"Amount\" have wrong parameters or is Negative Amount \n"
                            +"\t Example (xxxxx.xx) \n";
                if (String.IsNullOrEmpty(txtConceptIncomes.Text.Replace("'", ""))) error += " \t - The field \"Concept\" can`t be empty \n";

                if (cmbSource.SelectedIndex == -1) error += "\t - The field \"Source\" must be Selected \n";

                if (cmbTypes.SelectedIndex == -1) error += "\t - The field \"Type\" must be Selected \n";
            }

           

            return error ;
        }
    }
}
