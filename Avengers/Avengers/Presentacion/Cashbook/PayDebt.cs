using Avengers.Dominio;
using Avengers.Dominio.Gestores;
using System;
using System.Data;
using System.Windows.Forms;

namespace Avengers.Presentacion.Cashbook.Debts
{

    public partial class PayDebt : Form
    {

        private string idioma;
        private DtoDebt dto;
        private Menu m;

        public PayDebt(string idioma, DtoDebt dto, Menu m)
        {
            this.idioma = idioma;
            this.dto = dto;
            this.m = m;

            InitializeComponent();   
            initComboPayment();
            initComboType();

            rbPartial.Checked = true;
            txtUser.Text = dto.Username;
            dateDto.Value = Convert.ToDateTime(dto.Date);
            txtTotal.Text = dto.Amount;
            txtConcep.Text = dto.Concept;

            if (this.idioma == "ESPAÑOL")
            {
                idioma_es();
                this.Text = "Pagar Deuda";
            }
            else
            {
                idioma_en();
                this.Text = "Pay Debt";
            }
        }

        public void idioma_es()
        {
            lblUser.Text = Recursos.Espanol.lblUser;
            lblAmount.Text = Recursos.Espanol.lblAmount;
            btnPay.Text = Recursos.Espanol.btnPay;
            lblDate.Text = Recursos.Espanol.lblDate;
            lblConcep.Text = Recursos.Espanol.lblConcept;
            btnCancel.Text = Recursos.Espanol.btnCancel;
            lblTarget.Text = Recursos.Espanol.lblTarget;
            lblTPayment.Text = Recursos.Espanol.lblTPayment;
            lblType.Text = Recursos.Espanol.lblType;
            lblOf.Text = Recursos.Espanol.lblOf;
            rbPartial.Text = Recursos.Espanol.rbPartial;
            rbComplete.Text = Recursos.Espanol.rbComplete;
        }

        public void idioma_en()
        {
            lblUser.Text = Recursos.Ingles.lblUser;
            lblAmount.Text = Recursos.Ingles.lblAmount;
            btnPay.Text = Recursos.Ingles.btnPay;
            lblDate.Text = Recursos.Ingles.lblDate;
            lblConcep.Text = Recursos.Ingles.lblConcept;
            btnCancel.Text = Recursos.Ingles.btnCancel;
            lblTarget.Text = Recursos.Ingles.lblTarget;
            lblTPayment.Text = Recursos.Ingles.lblTPayment;
            lblType.Text = Recursos.Ingles.lblType;
            lblOf.Text = Recursos.Ingles.lblOf;
            rbPartial.Text = Recursos.Espanol.rbPartial;
            rbComplete.Text = Recursos.Espanol.rbComplete;
        }

        private void initComboPayment()
        {
            Incomes i = new Incomes();
            i.getGestor().readInDB("ID, TEXT", "SOURCE_TARGET", "where ID > 100 order by ID");
            DataTable tIncomes = i.getGestor().getIncomes();

            cmbIncomes.DataSource = tIncomes;
            cmbIncomes.DisplayMember = "TEXT";
            cmbIncomes.ValueMember = "ID";
            cmbIncomes.SelectedIndex = -1;
        }

        private void initComboType()
        {
            Incomes i = new Incomes();
            i.getGestor().readInDB("ID, TEXT", "TYPES", "where 1=1");
            DataTable tIncomes = i.getGestor().getIncomes();

            cmbType.DataSource = tIncomes;
            cmbType.DisplayMember = "TEXT";
            cmbType.ValueMember = "ID";
            cmbType.SelectedIndex = -1;
        }

        private void rbPartial_CheckedChanged(object sender, EventArgs e)
        {
            txtAmount.Enabled = (rbPartial.Checked) ? true : false;
            if (!rbPartial.Checked) txtAmount.Text = null;
        }

        private String sqlDebts()
        {
            double total = Convert.ToDouble(dto.Amount);
            int paid = 1;

            if (rbPartial.Checked)
            {
                total -= Convert.ToDouble(txtAmount.Text.Replace("'", "").Replace(",", "."));
                total = Math.Round(total, 3);
                paid = 0;
            }

            String sql = "update  DEBTS set DATE_DEBTS = SYSDATE, TEXT = '" + txtConcep.Text.Replace("'", "").ToUpper() + "', AMOUNT = '" + total + "', PAID = " + paid + " where ID = " + dto.Id;
            return sql;
        }

        private String sqlIcomes()
        {
            String amount = dto.Amount;
            double total = Convert.ToDouble(amount);

            if (rbPartial.Checked)
            {
                total = Convert.ToDouble(txtAmount.Text.Replace("'", "").Replace(",", "."));
                total = Math.Round(total, 3);
            }

            String sql = "insert into INCOMES values (0, SYSDATE, " + dto.Refuser + ", " + cmbIncomes.SelectedValue.ToString() + ", "
                + cmbType.SelectedValue.ToString() + ", '" + txtConcep.Text.Replace("'", "").ToUpper() + "', '" + total.ToString() + "', 1)";
            Console.WriteLine(sql);
            return sql;
        }

        private bool checkCashCompleto()
        {
            String strTotal = txtTotal.Text;
            double total = Convert.ToDouble(strTotal);
            return total < m.getTotalCash();
        }

        private bool checkCashParcial()
        {
            String strAmount = txtAmount.Text;
            double total = Convert.ToDouble(strAmount);
            return total < m.getTotalCash();
        }

        private void insertPartial()
        {
            if (checkPartial())
            {
                if (Convert.ToDecimal(dto.Amount) > Convert.ToDecimal(txtAmount.Text.Replace("'", "").Replace(",", ".")))
                {
                    String sqlInc = sqlIcomes();
                    String sqlpp = sqlDebts();
                    Incomes i = new Incomes();

                    i.getGestor().insertIncome(sqlInc);
                    GestorDebts.setData(sqlpp);
                    m.initMenu();
                    Dispose();
                }
                else
                {
                    if (this.idioma == "ESPAÑOL")
                    {
                        MessageBox.Show("Error, cantidad a pagar mayor o igual que el total, cambie a pago completo.");
                    }
                    else
                    {
                        MessageBox.Show("Error, amount to pay is greater or equal than total, please change to complete payment.");
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
            if (checkComplete())
            {
                String sqlInc = sqlIcomes();
                String sqlpp = sqlDebts();

                Incomes i = new Incomes();
                i.getGestor().insertIncome(sqlInc);
                GestorDebts.setData(sqlpp);
                m.initMenu();
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
                    error += "\t - El campo \"Cantidad\" no puede estar vacío. \n";
                }
                if (!Utils.check.checkAmountPos(txtAmount.Text))
                {
                    error += "\t - El campo \"Cantidad\" tiene parámetros incorrectos. \n";
                }
                if (string.IsNullOrEmpty(txtConcep.Text))
                {
                    error += "\t - El campo \"Descripción\" no puede estar vacío. \n";
                }
                if (cmbIncomes.SelectedIndex == -1)
                {
                    error += "\t - El campo \"Objetivo\" debe estar sSelecionado. \n";
                }
                if (cmbType.SelectedIndex == -1)
                {
                    error += "\t - El campo \"Tipo\" debe estar selecionado. \n";
                }
                if (!checkCashParcial())
                {
                    error += "\t - No hay suficiente dinero disponible. \n";
                }
                return error;
            }
            else
            {
                String error = "Some errors has been found: \n";
                if (string.IsNullOrEmpty(txtAmount.Text))
                {
                    error += "\t - The field \"Amount\" can't be empty. \n";
                }
                if (!Utils.check.checkAmountPos(txtAmount.Text))
                {
                    error += "\t - The field \"Amount\" has wrong parameters. \n";
                }
                if (string.IsNullOrEmpty(txtConcep.Text))
                {
                    error += "\t - The field \"Concept\" can't be empty. \n";
                }
                if (cmbIncomes.SelectedIndex == -1)
                {
                    error += "\t - The field \"Target\" must be selected. \n";
                }
                if (cmbType.SelectedIndex == -1)
                {
                    error += "\t - The field \"Type\" must be selected. \n";
                }
                if (!checkCashParcial())
                {
                    error += "\t - There is not enough money available. \n";
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
                    error += "\t - El campo \"Descripción\" no puede estar vacío. \n";
                }
                if (cmbIncomes.SelectedIndex == -1)
                {
                    error += "\t - El campo \"Objetivo\" debe estar selecionado. \n";
                }
                if (cmbType.SelectedIndex == -1)
                {
                    error += "\t - El campo \"Tipo\" debe estar selecionado. \n";
                }
                if (!checkCashCompleto())
                {
                    error += "\t - No hay suficiente dinero disponible. \n";
                }

                return error;
            }
            else
            {
                String error = "Some errors has been found: \n";

                if (string.IsNullOrEmpty(txtConcep.Text))
                {
                    error += "\t - The field \"Concept\" can't be empty. \n";
                }
                if (cmbIncomes.SelectedIndex == -1)
                {
                    error += "\t - The field \"Target\" must be selected. \n";
                }
                if (cmbType.SelectedIndex == -1)
                {
                    error += "\t - The field \"Type\" must be selected. \n";
                }
                if (!checkCashCompleto())
                {
                    error += "\t - There is not enough money available. \n";
                }
                return error;
            }

        }

        private bool checkPartial()
        {
            return Utils.check.checkAmount(txtAmount.Text) && !String.IsNullOrEmpty(txtAmount.Text.Replace("'", "")) && !String.IsNullOrEmpty(txtConcep.Text.Replace("'", ""))
                && cmbIncomes.SelectedIndex != -1 && cmbType.SelectedIndex != -1 && checkCashParcial();
        }

        private bool checkComplete()
        {
            return !String.IsNullOrEmpty(txtConcep.Text.Replace("'", "")) && cmbIncomes.SelectedIndex != -1 && cmbType.SelectedIndex != -1 && checkCashCompleto();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (rbPartial.Checked) insertPartial();
            if (rbComplete.Checked) insertComplete();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

    }

}