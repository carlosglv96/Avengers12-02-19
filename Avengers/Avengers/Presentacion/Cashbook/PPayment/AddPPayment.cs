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
    public partial class AddPPayment : Form
    {
        private string idioma;
        private User u;
        public AddPPayment(string idioma, User u)
        {
            this.idioma = idioma;
            this.u = u;

            InitializeComponent();
            txtUser.Text = u.getNombre().ToString();
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            initCmbSource("");

            if (this.idioma == "ESPAÑOL")
            {
                idioma_es();
                this.Text = "Añadir Pago Pendiente";
            }
            else
            {
                idioma_en();
                this.Text = "Add Pending Payment";
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

        private bool checkAdd()
        {
            //Console.WriteLine(Utils.check.checkAmountPos(txtAmount.Text));
            return !String.IsNullOrEmpty(txtAmount.Text.Replace("'", "")) && !String.IsNullOrEmpty(txtConcep.Text.Replace("'", "") ) && cmbSource.SelectedIndex != -1 && Utils.check.checkAmountPos(txtAmount.Text.Replace(".",","));
        }

    
        private String insertSql()
        {
            
            String concep= txtConcep.Text.ToUpper().Replace("'", "");
            String amount = txtAmount.Text.Replace("'", "").Replace(".",",");
            Double amnt = Convert.ToDouble(amount);
            amnt = Math.Round(amnt, 2);

            String sql = "Insert into ppayment values (0,SYSDATE,"+this.u.getId()+","+cmbSource.SelectedValue.ToString()+",'"+concep+"','"
                +amnt+"',0)";
            return sql;
        }

        private String errorDialog()
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
                    error += "\t - El campo \"Cantidad\" ha introducido parametros incorrectos o es Negativo \n";
                }
                if (string.IsNullOrEmpty(txtConcep.Text))
                {
                    error += "\t - El campo \"Descripcion\" no puede estar vacio \n";
                }
                if(cmbSource.SelectedIndex == -1)
                {
                    error += "\t - El campo \"Código\" debe estar Selecionado \n";
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
                    error += "\t - The field \"Amount\" have wrong parameters or is Negative  \n";
                }
                if (string.IsNullOrEmpty(txtConcep.Text))
                {
                    error += "\t - The field \"Concept\" can`t be empty \n";
                }
                if (cmbSource.SelectedIndex == -1)
                {
                    error += "\t - The field \"Source\" must be Selected \n";
                }

                return error;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(Utils.check.checkAmountPos(txtAmount.Text.Replace(".",",")));
            if (checkAdd())
            {

                String sql = insertSql();
                GestorPPayment.insertPPayment(sql);
                Dispose();

            }
            else
            {
                MessageBox.Show(errorDialog());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
