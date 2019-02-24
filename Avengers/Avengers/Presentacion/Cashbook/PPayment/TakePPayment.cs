
using Avengers.Dominio;
using Avengers.Dominio.Gestores;
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

    public partial class TakePPayment : Form
    {
        private DtoPPayment dto;
        protected string idioma;
        private decimal tota;

        public TakePPayment(string idioma, DtoPPayment dto)
        {
            this.idioma = idioma;
            this.dto = dto;
            InitializeComponent();
            initCmbSource("");
            initComboPayment();
            initComboType();
            rbPartial.Checked = true;
            txtUser.Text = dto.Username;
            dateDto.Value = Convert.ToDateTime( dto.Date);
            txtTotal.Text = dto.Amount;
            txtConcep.Text = dto.Concep;

            if (this.idioma == "ESPAÑOL")
            {
                idioma_es();
                this.Text = "Sacar Pago Pendiente";
            }
            else
            {
                idioma_en();
                this.Text = "Take Pending Payment";
            }

        }

        public void idioma_es()
        {
            lblUser.Text = Avengers.Recursos.Espanol.lblUser;
            lblSource.Text = Avengers.Recursos.Espanol.lblSource;
            lblAmount.Text = Avengers.Recursos.Espanol.lblAmount;
            btnAdd.Text = Avengers.Recursos.Espanol.btnAdd;
            lblDate.Text = Avengers.Recursos.Espanol.lblDate;
            lblConcep.Text = Avengers.Recursos.Espanol.lblConcept;
            btnCancel.Text = Avengers.Recursos.Espanol.btnCancel;

            lblIncomes.Text = Avengers.Recursos.Espanol.lblIncomes;
            lblTPayment.Text = Avengers.Recursos.Espanol.lblTPayment;
            lblType.Text = Avengers.Recursos.Espanol.lblType;
            lblOf.Text = Avengers.Recursos.Espanol.lblOf;
            rbPartial.Text = Avengers.Recursos.Espanol.rbPartial;
            rbComplete.Text = Avengers.Recursos.Espanol.rbComplete;
        }

        public void idioma_en()
        {
            lblUser.Text = Avengers.Recursos.Ingles.lblUser;
            lblSource.Text = Avengers.Recursos.Ingles.lblSource;
            lblAmount.Text = Avengers.Recursos.Ingles.lblAmount;
            btnAdd.Text = Avengers.Recursos.Ingles.btnAdd;
            lblDate.Text = Avengers.Recursos.Ingles.lblDate;
            lblConcep.Text = Avengers.Recursos.Ingles.lblConcept;
            btnCancel.Text = Avengers.Recursos.Ingles.btnCancel;
            lblIncomes.Text = Avengers.Recursos.Ingles.lblIncomes;
            lblTPayment.Text = Avengers.Recursos.Ingles.lblTPayment;
            lblType.Text = Avengers.Recursos.Ingles.lblType;
            lblOf.Text = Avengers.Recursos.Ingles.lblOf;
            rbPartial.Text = Avengers.Recursos.Ingles.rbPartial;
            rbComplete.Text = Avengers.Recursos.Ingles.rbComplete;
        }

        private void initCmbSource(String cond)
        {
            PPayments pay = new PPayments();
            pay.getGestor().readInDB("ID  ,TEXT", "TYPES_PPAYMENT", cond);
            DataTable dt = pay.getGestor().getPPayments();

            cmbSource.DataSource = dt;
            cmbSource.DisplayMember = "TEXT";
            cmbSource.ValueMember = "ID";

            cmbSource.SelectedValue = dto.Refppayment;

        }

        private void initComboPayment()
        {
            Incomes inc = new Incomes();
            inc.getGestor().readInDB("ID, TEXT", "SOURCE_TARGET", "Where ID<100 Order by id");
            DataTable tincome = inc.getGestor().getIncomes();
            cmbIncomes.DataSource = tincome;
            cmbIncomes.DisplayMember = "TEXT";
            cmbIncomes.ValueMember = "ID";
            cmbIncomes.SelectedIndex = -1;

        }
        private void initComboType()
        {
            Incomes inc = new Incomes();
            inc.getGestor().readInDB("ID, TEXT", "TYPES", "Where 1=1");
            DataTable tincome = inc.getGestor().getIncomes();
            cmbType.DataSource = tincome;
            cmbType.DisplayMember = "TEXT";
            cmbType.ValueMember = "ID";
            cmbType.SelectedIndex = -1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void rbPartial_CheckedChanged(object sender, EventArgs e)
        {
            txtAmount.Enabled = (rbPartial.Checked) ? true : false;
            if (!rbPartial.Checked) txtAmount.Text = null; 
        }

        private void rbComplete_CheckedChanged(object sender, EventArgs e)
        {

        }
        
        private String sqlPPayment()
        {
            double total =Convert.ToDouble(dto.Amount);
            int paid = 1;

            if (rbPartial.Checked)
            {
                total -= Convert.ToDouble(txtAmount.Text.Replace("'", "").Replace(".",","));
                total = Math.Round(total, 2);
                paid = 0;
            }
            String sql = "Update  ppayment set DATE_PPAYMENT= trunc(SYSDATE) , Text='" + txtConcep.Text.Replace("'","").ToUpper()+"' , amount='"+total+"' , paid="+paid
                +" where id="+dto.Id;

            return sql;
        }
        private String sqlIcomes()
        {
            String am = dto.Amount;
            double total =Convert.ToDouble(am);
           
            if (rbPartial.Checked)
            {
                total=  Convert.ToDouble(txtAmount.Text.Replace("'", "").Replace(".",","));
                total = Math.Round(total, 2);
            }
            String sql = "Insert into Incomes values (0,trunc(SYSDATE)," + dto.Refuser+","+cmbIncomes.SelectedValue.ToString()+","
                +cmbType.SelectedValue.ToString()+",'"+txtConcep.Text.Replace("'","").ToUpper()+"','"+ total.ToString()+"',0)";

            return sql;
        }
        private void insertPartial()
        {
            if (checkPartial())
            {
                if (Convert.ToDecimal(dto.Amount) > Convert.ToDecimal(txtAmount.Text.Replace("'", "").Replace(".", ",")))
                {
                    String sqlInc = sqlIcomes();
                    String sqlpp = sqlPPayment();
                    Incomes i = new Incomes();

                    i.getGestor().insertIncome(sqlInc);
                    GestorPPayment.setData(sqlpp);
                    Dispose();
                }
                else
                {
                    
                    if (this.idioma == "ESPAÑOL")
                    {
                        MessageBox.Show("Error, cantidad a pagar mayor o igual que el total, cambie a pago completo");
                    }
                    else
                    {
                        MessageBox.Show("Error, Amount to pay is greater than total, please change to complete payment");
                    }
                }
            }

            else
            {
                MessageBox.Show(errorPartial());
            }
        }

        private void insertComplete()
        {
            if ( checkComplete())
            {
                String sqlInc = sqlIcomes();
                String sqlpp = sqlPPayment();

                Incomes i = new Incomes();
                i.getGestor().insertIncome(sqlInc);
                GestorPPayment.setData(sqlpp);
                Dispose();

            }
            else
            {
                MessageBox.Show(errorComp());
            }
        }

        private String errorPartial()
        {
            if (this.idioma == "ESPAÑOL")
            {
                String error = "Se han encontrado algunos errores: \n";
                if (string.IsNullOrEmpty(txtAmount.Text))
                {
                    error += "\t - El campo \"Cantidad\" no puede estar vacio \n";
                }
                if (!Utils.check.checkAmountPos(txtAmount.Text))
                {
                    error += "\t - El campo \"Cantidad\" ha introducido parametros incorrectos \n";
                }
                if (string.IsNullOrEmpty(txtConcep.Text))
                {
                    error += "\t - El campo \"Descripcion\" no puede estar vacio \n";
                }
                if (cmbSource.SelectedIndex == -1)
                {
                    error += "\t - El campo \"Código\" debe estar Selecionado \n";
                }
                if (cmbIncomes.SelectedIndex == -1)
                {
                    error += "\t - El campo \"Código de Entrada\" debe estar Selecionado \n";
                }
                if (cmbType.SelectedIndex == -1)
                {
                    error += "\t - El campo \"Tipo\" debe estar Selecionado \n";
                }

                return error;
            }
            else
            {
                String error = "Some Errors has been found: \n";
                if (string.IsNullOrEmpty(txtAmount.Text))
                {
                    error += "\t - The field \"Amount\" can`t be empty \n";
                }
                if (!Utils.check.checkAmountPos(txtAmount.Text))
                {
                    error += "\t - The field \"Amount\" have wrong parameters  \n";
                }
                if (string.IsNullOrEmpty(txtConcep.Text))
                {
                    error += "\t - The field \"Concept\" can`t be empty \n";
                }
                if (cmbSource.SelectedIndex == -1)
                {
                    error += "\t - The field \"Source\" must be Selected \n";
                }
                if (cmbIncomes.SelectedIndex == -1)
                {
                    error += "\t - The field \"Incomes\" must be Selected \n";
                }
                if (cmbType.SelectedIndex == -1)
                {
                    error += "\t - The field \"Type\" must be Selected \n";
                }

                return error;
            }
        }

        public String errorComp()
        {
            if (this.idioma == "ESPAÑOL")
            {
                String error = "Se han encontrado algunos errores: \n";
               
                if (string.IsNullOrEmpty(txtConcep.Text))
                {
                    error += "\t - El campo \"Descripcion\" no puede estar vacio \n";
                }
                if (cmbSource.SelectedIndex == -1)
                {
                    error += "\t - El campo \"Código\" debe estar Selecionado \n";
                }
                if (cmbIncomes.SelectedIndex == -1)
                {
                    error += "\t - El campo \"Código de Entrada\" debe estar Selecionado \n";
                }
                if (cmbType.SelectedIndex == -1)
                {
                    error += "\t - El campo \"Tipo\" debe estar Selecionado \n";
                }

                return error;
            }
            else
            {
                String error = "Some Errors has been found: \n";
               
                if (string.IsNullOrEmpty(txtConcep.Text))
                {
                    error += "\t - The field \"Concept\" can`t be empty \n";
                }
                if (cmbSource.SelectedIndex == -1)
                {
                    error += "\t - The field \"Source\" must be Selected \n";
                }
                if (cmbIncomes.SelectedIndex == -1)
                {
                    error += "\t - The field \"Incomes\" must be Selected \n";
                }
                if (cmbType.SelectedIndex == -1)
                {
                    error += "\t - The field \"Type\" must be Selected \n";
                }

                return error;
            }
        
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (rbPartial.Checked) insertPartial();

            if (rbComplete.Checked) insertComplete();
        }

        private bool checkPartial()
        {
            return Utils.check.checkAmountPos(txtAmount.Text.Replace(".",",")) && !String.IsNullOrEmpty(txtAmount.Text.Replace("'", "")) && !String.IsNullOrEmpty(txtConcep.Text.Replace("'", ""))
                && cmbIncomes.SelectedIndex != -1 && cmbType.SelectedIndex != -1;
        }

        private bool checkComplete()
        {
            return !String.IsNullOrEmpty(txtConcep.Text.Replace("'", "")) && cmbIncomes.SelectedIndex != -1 && cmbType.SelectedIndex != -1;
        }
    }
}
