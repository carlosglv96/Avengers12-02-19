using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Avengers.Dominio;

namespace Avengers.Presentacion.Cashbook
{
    public partial class ViewIncomes : Form
    {
        private User usuario;
        public String idioma;
        public int refaction;
        private Menu menu;
        
        public ViewIncomes(String idioma, User usuario, int refact, Menu men)
        {
            this.menu = men;
            this.refaction = refact;
            this.idioma = idioma;
            this.usuario = usuario;
            InitializeComponent();
            initTable("Where REFACTION = '"+this.refaction+"'");
            initComboSource();
            initComboType();
            dateRangeTo.Enabled = chkDateFrom.Checked;
            dateRangeFrom.Enabled = chkDateTo.Checked;
            cmbSource.Enabled = chkSource.Checked;
            cmbTypes.Enabled = chkType.Checked;

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
                idioma_en();
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
            lblSource.Text = Avengers.Recursos.Espanol.lblSource;
            lblTypes.Text = Avengers.Recursos.Espanol.lblTypes;
            lblAmount.Text = Avengers.Recursos.Espanol.lblAmount;
            lblConcept.Text = Avengers.Recursos.Espanol.lblConcept;
            //lblDateRange.Text = Avengers.Recursos.Espanol.lblDateRange;
            lblFrom.Text = Avengers.Recursos.Espanol.lblFrom;
            lblTo.Text = Avengers.Recursos.Espanol.lblTo;
            btnAdd.Text = Avengers.Recursos.Espanol.btnAdd;
            btnDelete.Text = Avengers.Recursos.Espanol.btnDeleteUser;
            btnClean.Text = Avengers.Recursos.Espanol.btnClean;
            btnEject.Text = Avengers.Recursos.Espanol.btnEject;
            
        }
        public void idioma_en()
        {
            lblSource.Text = Avengers.Recursos.Ingles.lblSource;
            lblTypes.Text = Avengers.Recursos.Ingles.lblTypes;
            lblAmount.Text = Avengers.Recursos.Ingles.lblAmount;
            lblConcept.Text = Avengers.Recursos.Ingles.lblConcept;
            //lblDateRange.Text = Avengers.Recursos.Ingles.lblDateRange;
            lblFrom.Text = Avengers.Recursos.Ingles.lblFrom;
            lblTo.Text = Avengers.Recursos.Ingles.lblTo;
            btnAdd.Text = Avengers.Recursos.Ingles.btnAdd;
            btnDelete.Text = Avengers.Recursos.Ingles.btnDeleteUser;
            btnClean.Text = Avengers.Recursos.Ingles.btnClean;
            btnEject.Text = Avengers.Recursos.Ingles.btnEject;
        }


        private void intervaloFechas() {
            dateRangeFrom.MaxDate = DateTime.Today;
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
            cmbSource.SelectedIndex = -1;

        }
        private void initComboType()
        {
            Incomes inc = new Incomes();
            inc.getGestor().readInDB("ID, TEXT", "TYPES", "Where 1=1");
            DataTable tincome = inc.getGestor().getIncomes();
            cmbTypes.DataSource = tincome;
            cmbTypes.DisplayMember = "TEXT";
            cmbTypes.ValueMember = "ID";
            cmbTypes.SelectedIndex = -1;
        }

        public void initTable(String cond)
        {
            dgvIncomes.Columns.Clear();
            
            Incomes inc = new Incomes();
            inc.getGestor().readTable(cond);


            DataTable tincome = inc.getGestor().getIncomes();

           
           

            if (this.idioma == "ESPAÑOL")
            {
                dgvIncomes.Columns.Add("INCOMES.ID", "ID");
                dgvIncomes.Columns.Add("INCOMES.DATE_INCOMES", "FECHA");
                dgvIncomes.Columns.Add("USUARIO.NAME", "USUARIO");
                dgvIncomes.Columns.Add("SOURCE_TARGET.TEXT", "ORIGEN");
                dgvIncomes.Columns.Add("TYPE.TEXT", "TIPO");
                dgvIncomes.Columns.Add("INCOMES.TEXT", "CONCEPTO");
                dgvIncomes.Columns.Add("INCOMES.AMOUNT", "CANTIDAD");
                dgvIncomes.Columns.Add("INCOMES.REFACTION", "ACCION");
                dgvIncomes.Columns.Add("SOURCE_TARGET.ID", "SOURCE ID");
                dgvIncomes.Columns.Add("TYPES.ID", "TYPES ID");
                dgvIncomes.Columns.Add("USUARIO.ID", "USER ID");
            }
            else
            {
            
                dgvIncomes.Columns.Add("INCOMES.ID", "ID");
                dgvIncomes.Columns.Add("INCOMES.DATE_INCOMES", "DATE");
                dgvIncomes.Columns.Add("USUARIO.NAME", "USER");
                dgvIncomes.Columns.Add("SOURCE_TARGET.TEXT", "SOURCE");
                dgvIncomes.Columns.Add("TYPE.TEXT", "TYPE");
                dgvIncomes.Columns.Add("INCOMES.TEXT", "TEXT");
                dgvIncomes.Columns.Add("INCOMES.AMOUNT", "AMOUNT");
                dgvIncomes.Columns.Add("INCOMES.REFACTION", "ACTION");
                dgvIncomes.Columns.Add("SOURCE_TARGET.ID", "SOURCE ID");
                dgvIncomes.Columns.Add("TYPES.ID", "TYPES ID");
                dgvIncomes.Columns.Add("USUARIO.ID", "USER ID");
            }



            foreach (DataRow row in tincome.Rows)
            {
                
                dgvIncomes.Rows.Add(row["ID"], row["DATE_INCOMES"], row["NAME"], row["TEXT"], row["TEXT1"], row["TEXT2"], row["AMOUNT"],row["REFACTION"], row["ID1"], row["ID2"], row["IDUSER"]);
                
            }
            dgvIncomes.Columns["INCOMES.ID"].Visible = false;
            dgvIncomes.Columns["INCOMES.REFACTION"].Visible = false;
            dgvIncomes.Columns["SOURCE_TARGET.ID"].Visible = false;
            dgvIncomes.Columns["TYPES.ID"].Visible = false;
            dgvIncomes.Columns["USUARIO.ID"].Visible = false;

            dgvIncomes.ClearSelection();
            
        }

        public void filtrar()
        {
            String sql = "Where REFACTION = '"+this.refaction+"'";
            if (!String.IsNullOrEmpty(txtConcept.Text.Replace("'","")))
            {
                sql += " And Upper(INCOMES.TEXT) like '%" + txtConcept.Text.ToUpper().Replace("'", "") + "%' ";
            }

            if (cmbSource.SelectedIndex >-1 && chkSource.Checked)
            {
                sql += " And SOURCE_TARGET.ID = '" + cmbSource.SelectedValue.ToString() + "'";
            }
            if (cmbTypes.SelectedIndex >-1 && chkType.Checked)
            {
                sql += " And TYPES.ID ='" + cmbTypes.SelectedValue.ToString() + "'";
            }
            if (!String.IsNullOrEmpty(txtAmount.Text.Replace("'","")))
            {
                sql += " And INCOMES.AMOUNT  like '" + txtAmount.Text.Replace("'","") + "%'";
            }
            if (dateRangeTo.Enabled || dateRangeFrom.Enabled)
            {
                String fecha = dateRangeFrom.Value.ToString("dd/MM/yyyy").Replace("'", "");
                String fecha2 = dateRangeTo.Value.ToString("dd/MM/yyyy").Replace("'", "");
                sql += " And DATE_INCOMES BETWEEN '" + fecha + "'  AND '"+fecha2+"'";
            }
            //Console.WriteLine(sql);
            initTable(sql);
        }


       

        private void txtConceptKeyUP(object sender, KeyEventArgs e)
        {
            filtrar();
        }

        private void dateRangeFromValueChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void dateRangeToVAlueChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            AddIncomes ai = new AddIncomes(this.refaction, this.idioma, this.usuario);
            if (this.refaction == 0 & this.idioma == "ESPAÑOL") { ai.Text = "Añadir Entrada"; }
            else if (this.refaction == 0 & this.idioma == "INGLES") { ai.Text = "Add Income"; }
            else if (this.refaction == 1 & this.idioma == "ESPAÑOL") { ai.Text = "Añadir Salida"; }
            else { ai.Text = "Add Expense"; }
            ai.lblUsuario.Text = this.usuario.getNombre();
            ai.ShowDialog();
            
            
            
           
            if (ai.IsDisposed)
            {
                initTable("Where REFACTION = '"+this.refaction+"'");
                initComboSource();
                initComboType();
                menu.initMenu();
                
            }
        }

        private void cmbTypesClick(object sender, EventArgs e)
        {
            //filtrar();
        }

 

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                String id = dgvIncomes.Rows[dgvIncomes.CurrentRow.Index].Cells[0].Value.ToString();
                String date = dgvIncomes.Rows[dgvIncomes.CurrentRow.Index].Cells[1].Value.ToString();
                String concept = dgvIncomes.Rows[dgvIncomes.CurrentRow.Index].Cells[5].Value.ToString();
                String amount = dgvIncomes.Rows[dgvIncomes.CurrentRow.Index].Cells[6].Value.ToString();
                String refacti = dgvIncomes.Rows[dgvIncomes.CurrentRow.Index].Cells[7].Value.ToString();
                String idSource = dgvIncomes.Rows[dgvIncomes.CurrentRow.Index].Cells[8].Value.ToString();
                String idType = dgvIncomes.Rows[dgvIncomes.CurrentRow.Index].Cells[9].Value.ToString();
                String idUser = dgvIncomes.Rows[dgvIncomes.CurrentRow.Index].Cells[10].Value.ToString();
                Double cantidad = Convert.ToDouble(amount);
                if (cantidad < 0) {
                    if (this.idioma == "ESPAÑOL")
                    {
                        MessageBox.Show("No puedes eliminar un registro negativo");
                    }
                    else if (this.idioma == "INGLES") {
                        MessageBox.Show("You can not delete a negative record");
                    }
                } else {
                    Double negativeamount = cantidad * (-1);
                    DateTime dd = DateTime.Parse(date);
                    String datedef = dd.ToString("dd/MM/yyyy");

                    if (this.idioma == ("ESPAÑOL"))
                    {
                        if (MessageBox.Show("¿Seguro que desea 'eliminar' el registro con el concepto: " + concept + " ?", "Eliminar Entrada", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            String sql = "Insert into INCOMES VALUES('" + 0 + "','" + datedef + "','" +
                            idUser + "','" + idSource + "','" + idType +
                            "','" + concept + "','" + negativeamount + "','" + this.refaction + "')";
                            Incomes incom = new Incomes();
                            incom.getGestor().deleteIncome(sql);

                            initTable("Where REFACTION = '" + this.refaction + "'");

                        }

                    }
                    if (this.idioma == "INGLES") {

                        if (MessageBox.Show("Are you sure you want to 'delete' the registration with the concept: " + concept + " ?", "Delete Incomes", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            String sql = "Insert into INCOMES VALUES('" + 0 + "','" + datedef + "','" +
                            idUser + "','" + idSource + "','" + idType +
                            "','" + concept + "','" + negativeamount + "','" + this.refaction + "')";
                            Incomes incom = new Incomes();
                            incom.getGestor().deleteIncome(sql);

                            initTable("Where REFACTION = '" + this.refaction + "'");
                            menu.initMenu();
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                if (this.idioma.Equals("ESPAÑOL"))
                {
                    MessageBox.Show("No hay ninguna fila seleccionada");
                }
                else
                {
                    MessageBox.Show("Unselected any row");
                }
            }

            }
        private void chkSource_CheckedChanged(object sender, EventArgs e)
        {
            cmbSource.Enabled = chkSource.Checked;
            if (!chkSource.Checked)
            {
                cmbSource.SelectedIndex = -1;
            }
        }

        private void chkTypes_CheckedChanged(object sender, EventArgs e)
        {
            cmbTypes.Enabled = chkType.Checked;
            if (!chkType.Checked)
            {
                cmbTypes.SelectedIndex = -1;
            }
        }

        private void chkDateFrom_CheckedChanged(object sender, EventArgs e)
        {
            dateRangeFrom.Enabled = chkDateFrom.Checked;
            filtrar();
        }

        private void chkDateTo_CheckedChanged(object sender, EventArgs e)
        {
            dateRangeTo.Enabled = chkDateTo.Checked;
            filtrar();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbSource.SelectedIndex = -1;
            cmbTypes.SelectedIndex = -1;
            txtAmount.Text = null;
            txtConcept.Text = null;
            dateRangeTo.Value = DateTime.Today;
            dateRangeFrom.Value = DateTime.Today;
            chkDateFrom.Checked = false;
            chkDateTo.Checked = false;
            chkSource.Checked = false;
            chkType.Checked = false;
        }

      

        private void btnEject_Click(object sender, EventArgs e)
        {
            int cont = 0;
            int type = 0;
            int source = 0;
            int refa = 0;
            double amount = 0;
            String[] text = new String[2];
            text[0] = "Incomes";
            text[1] = "Expenses";
            Incomes inc = new Incomes();
            if (Utils.check.checkInt(txtRegistros.Text))
            {
                int cantidad = int.Parse(txtRegistros.Text);
                while (cont < cantidad)
                {
                    
                    refa = Utils.RandomNumber.random_Number(0,2);
                    if (refa == 0 )
                    {
                        type = Utils.RandomNumber.random_Number(1, 4);
                        source = Utils.RandomNumber.random_Number(1, 5);
                        amount = Utils.RandomNumber.random_Number(100, 1001) * 0.25;
                        inc.getGestor().insertIncome("Insert into INCOMES VALUES('" + 0 + "', SYSDATE ,'" +
                        this.usuario.getId() + "','" + source + "','" + type +
                        "','" + text[0] + "','" + amount + "','" + refa + "')");
                    }
                    else if(double.Parse(menu.texbtotal.Text)>1000)
                    {
                        type = Utils.RandomNumber.random_Number(1, 4);
                        source = Utils.RandomNumber.random_Number(101, 106);
                        amount = Utils.RandomNumber.random_Number(100, 1001) * 0.25;
                        inc.getGestor().insertIncome("Insert into INCOMES VALUES('" + 0 + "', SYSDATE ,'" +
                        this.usuario.getId() + "','" + source + "','" + type +
                        "','" + text[1] + "','" + amount + "','" + refa + "')");
                    }
                    cont++;
                }
            }
            else {
                if(this.idioma == "ESPAÑOL") { MessageBox.Show("Ha escrito una cantidad inválida"); }
                else { MessageBox.Show("You have written an invalid amount"); }
            }

            initTable("Where REFACTION = '" + this.refaction + "'");
        }

        private void txtAmount_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar();
        }

        private void cmbSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void cmbTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void Incomes_Shown(object sender, EventArgs e)
        {
            dgvIncomes.ClearSelection();
        }

      
    }
}
