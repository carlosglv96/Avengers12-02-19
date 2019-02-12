﻿using Avengers.Dominio;
using Avengers.Dominio.Gestores;
using Avengers.Presentacion.Customers;
using Avengers.Presentacion.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avengers.Presentacion
{
    public partial class ViewCustomer : Form
    {

        private NewOrder observer = null;
        private ModOrder observerMod = null;
        private String idioma;

        public ViewCustomer(String idioma)
        {
            this.idioma = idioma;
            InitializeComponent();
            initTable(" Where Deleted =0");
            initCombos();
            if(this.idioma == "ESPAÑOL")
            {
                idioma_es();
                this.Text = "Clientes";
            }
            else
            {
                idioma_en();
                this.Text = "Customers";
            }
        }     

        public ViewCustomer(NewOrder newOrder, String idioma)
        {
            this.idioma = idioma;
            observer = newOrder;
            InitializeComponent();
            initTable(" Where Deleted =0");
            initCombos();            
            if (this.idioma == "ESPAÑOL")
            {
                idioma_es();
                this.Text = "Clientes";
            }
            else
            {
                idioma_en();
                this.Text = "Customers";
            }
        }
        public ViewCustomer(ModOrder modOrder, String idioma)
        {
            this.idioma = idioma;
            observerMod = modOrder;
            InitializeComponent();
            initTable(" Where Deleted =0");
            initCombos();
            if (this.idioma == "ESPAÑOL")
            {
                idioma_es();
                this.Text = "Clientes";
            }
            else
            {
                idioma_en();
                this.Text = "Customers";
            }
        }

        public void idioma_es()
        {
            lblName.Text = Avengers.Recursos.Espanol.lblName;
            lblSurname.Text = Avengers.Recursos.Espanol.lblSurname;
            lblDni.Text = Avengers.Recursos.Espanol.lblDni;
            lblRegion.Text = Avengers.Recursos.Espanol.lblRegion;
            lblProvince.Text = Avengers.Recursos.Espanol.lblProvince;
            lblCity.Text = Avengers.Recursos.Espanol.lblCity;
            ckDel.Text = Avengers.Recursos.Espanol.ckDel;
            btnClean.Text = Avengers.Recursos.Espanol.btnClean;
            btnNew.Text = Avengers.Recursos.Espanol.btnNewUser;
            btnDelete.Text = Avengers.Recursos.Espanol.btnDeleteUser;
            btnMod.Text = Avengers.Recursos.Espanol.btnModUser;
        }
        public void idioma_en()
        {
            lblName.Text = Avengers.Recursos.Ingles.lblName;
            lblSurname.Text = Avengers.Recursos.Ingles.lblSurname;
            lblDni.Text = Avengers.Recursos.Ingles.lblDni;
            lblRegion.Text = Avengers.Recursos.Ingles.lblRegion;
            lblProvince.Text = Avengers.Recursos.Ingles.lblProvince;
            lblCity.Text = Avengers.Recursos.Ingles.lblCity;
            ckDel.Text = Avengers.Recursos.Ingles.ckDel;
            btnClean.Text = Avengers.Recursos.Ingles.btnClean;
            btnNew.Text = Avengers.Recursos.Ingles.btnNewUser;
            btnDelete.Text = Avengers.Recursos.Ingles.btnDeleteUser;
            btnMod.Text = Avengers.Recursos.Ingles.btnModUser;
        }
        
        private void initTable(String cond)
        {
            dgvCustomer.Columns.Clear();

            Customer c = new Customer();
            c.getGestor().readCustomers(cond);


            DataTable tcustomers = c.getGestor().getCustomers();
            dgvCustomer.Columns.Clear();

            if (this.idioma == "ESPAÑOL")
            {
                dgvCustomer.Columns.Add("IDCUSTOMER", "ID");
                dgvCustomer.Columns.Add("NAME", "NOMBRE");
                dgvCustomer.Columns.Add("SURNAME", "APELLIDO");
                dgvCustomer.Columns.Add("DNI", "NIF/DNI");
                dgvCustomer.Columns.Add("ADDRESS", "DIRECCIÓN");
                dgvCustomer.Columns.Add("PHONE", "TELÉFONO");
                dgvCustomer.Columns.Add("EMAIL", "EMAIL");
                dgvCustomer.Columns.Add("REFZIPCODESCITIES", "REFZIP");
            }
            else
            {
                dgvCustomer.Columns.Add("IDCUSTOMER", "ID");
                dgvCustomer.Columns.Add("NAME", "NAME");
                dgvCustomer.Columns.Add("SURNAME", "SURNAME");
                dgvCustomer.Columns.Add("DNI", "NIF/DNI");
                dgvCustomer.Columns.Add("ADDRESS", "ADDRESS");
                dgvCustomer.Columns.Add("PHONE", "PHONE");
                dgvCustomer.Columns.Add("EMAIL", "EMAIL");
                dgvCustomer.Columns.Add("REFZIPCODESCITIES", "REFZIP");
            }

            


            foreach (DataRow row in tcustomers.Rows)
            {
                dgvCustomer.Rows.Add(row["IDCUSTOMER"], row["NAME"], row["SURNAME"], row["DNI"], row["ADDRESS"], row["PHONE"], row["EMAIL"], row["REFZIPCODESCITIES"]);
            }
            this.dgvCustomer.Columns["IDCUSTOMER"].Visible = false;

            dgvCustomer.ClearSelection();

        }

        private void initCombos()
        {
            initRegion("");
            initProv("");
            cmbCity.Enabled = false;
            //initZip();
        }

        private void initRegion(String cond)
        {
            Customer c = new Customer();
            c.getGestor().readInDB(" REGION", "REGIONS", cond);
            DataTable tregion = c.getGestor().getCustomers();
            cmbReg.Items.Clear();

            foreach (DataRow row in tregion.Rows)
            {
                cmbReg.Items.Add(row["REGION"]);


            }
        }
        private void initProv(String cond)
        {

            Customer c = new Customer();
            c.getGestor().readInDB(" STATE", "STATES", cond);
            DataTable tstate = c.getGestor().getCustomers();
            cmbProv.Items.Clear();

            foreach (DataRow row in tstate.Rows)
            {
                cmbProv.Items.Add(row["STATE"]);

            }

        }

        private void initCities(String cond)
        {
            Customer c = new Customer();
            c.getGestor().readInDB(" CITY", "CITIES", cond);
            DataTable tcity = c.getGestor().getCustomers();
            cmbCity.Items.Clear();

            foreach (DataRow row in tcity.Rows)
            {
                cmbCity.Items.Add(row["CITY"]);

            }
        }
        private void initZIP(String cond)
        {
            Customer c = new Customer();
            c.getGestor().readInDB(" zipcode", "zipcodes", cond);
            DataTable tzip = c.getGestor().getCustomers();
            cmbZip.Items.Clear();

            foreach (DataRow row in tzip.Rows)
            {
                if (tzip.Rows.Count > 1)
                {
                    txtZip.Visible = false;
                    cmbZip.Visible = true;
                    cmbZip.Items.Add(row["zipcode"]);
                }else
                {
                    txtZip.Visible = true;
                    cmbZip.Visible = false;
                    txtZip.Text = row["zipcode"].ToString();
                }
                

            }
        }


        public void filtrar()
        {
            int comb = 0;
            String sql = " Where 1=1";
            String subCons = " AND REFZIPCODESCITIES IN (SELECT IDZIPCODESCITIES FROM ZIPCODESCITIES Z FULL OUTER JOIN STATES S " +
                                "ON Z.REFSTATE = S.IDSTATE FULL OUTER JOIN REGIONS R ON S.REFREGION = R.IDREGION " +
                                " full OUTER JOIN CITIES CI ON Z.REFCITY = CI.IDCITY " +
                                " full OUTER JOIN ZIPCODES ZIP ON ZIP.IDZIPCODE=Z.REFZIPCODE WHERE 1=1 ";

            if (!String.IsNullOrEmpty(txtName.Text.Replace("'","")))
            {
                sql += " And Upper(Name) like '%" + txtName.Text.ToUpper().Replace("'", "") + "%' ";
            }
            if (!String.IsNullOrEmpty(txtSurname.Text.Replace("'", "")))
            {
                sql += " And upper(Surname) like '%" + txtSurname.Text.ToUpper().Replace("'", "") + "%'";
            }
            if (!String.IsNullOrEmpty(txtDNI.Text.Replace("'", "")))
            {
                sql += " And Upper(DNI) like '%" + txtDNI.Text.ToUpper().Replace("'", "") + "%'";
            }


            if (cmbReg.SelectedIndex != -1)
            {
                subCons += " AND R.REGION = '" + cmbReg.SelectedItem.ToString().Replace("'", "") + "' ";
                comb++;
            }
            if (cmbProv.SelectedIndex != -1)
            {
                subCons += " AND  S.STATE = '" + cmbProv.SelectedItem.ToString().Replace("'", "") + "' ";
                comb++;
            }
            if (cmbCity.SelectedIndex != -1)
            {
                subCons += " AND CI.CITY = '" + cmbCity.SelectedItem.ToString().Replace("'", "") + "' ";
                comb++;
            }
            if (!String.IsNullOrEmpty(txtZip.Text.Replace("'", "")))
            {
                subCons += " AND ZIP.ZIPCODE= '%" + txtZip.Text.ToUpper().Replace("'", "") + "%' ";
                comb++;
            }
            if (cmbZip.SelectedIndex != -1)
            {
                subCons += " AND ZIP.ZIPCODE= '" + cmbZip.SelectedItem.ToString() + "' ";
                comb++;
            }
            if (ckDel.Checked)
            {
                sql += " And DELETED=1";
            }else
            {
                sql += " And DELETED=0";
            }


            
            if (comb > 0)
            {
                initTable(sql + subCons + ")");
            }
            else
            {
                initTable(sql);
            }

        }
        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewCustomer nc = new NewCustomer(this.idioma);
            nc.ShowDialog();
            if (nc.IsDisposed)
            {
                initTable(" Where Deleted =0");
            }
        }

        private void txtSurname_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar();
        }

        private void txtDNI_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar();
        }

        private void cmbReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
            cmbProv.Items.Clear();
            cmbCity.Items.Clear();
            cmbZip.Items.Clear();
            String cond = " Where Refregion = (Select idRegion from regions where Region = '" + cmbReg.SelectedItem.ToString() + "')";
            initProv(cond);
        }

        private void cmbProv_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
            String cond = " Where idcity in(select refcity from zipcodescities z inner join states s on z.refstate= s.idstate where state= '" + cmbProv.SelectedItem.ToString() + "')";
            cmbCity.Enabled = true;
            cmbCity.Items.Clear();
            initCities(cond);
        }

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
            String cond = " Where idzipcode in (select refzipcode from  zipcodescities inner join cities  on refcity= idcity where city='" + cmbCity.SelectedItem.ToString() + "')";
            cmbZip.Items.Clear();
            cmbZip.Items.Clear();
            initZIP(cond);
        }

        private void txtZip_KeyUp(object sender, KeyEventArgs e)
        {
            filtrar();
        }

        private void ckDel_CheckedChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtSurname.Clear();
            txtDNI.Clear();
            cmbReg.Items.Clear();
            cmbProv.Items.Clear();
            cmbCity.Items.Clear();
            cmbZip.Items.Clear();
            txtZip.Clear();
            ckDel.Checked = false;
            initCombos();
            
            initTable(" Where Deleted=0");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            String valor = dgvCustomer.Rows[dgvCustomer.CurrentRow.Index].Cells[0].Value.ToString();
            if (!GestorCustomers.existCustomer(valor))
            {
                if (this.idioma == "ESPAÑOL")
                {
                    if (MessageBox.Show("¿Quieres eliminar a este cliente?", "Eliminar Cliente", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        String sql = "update customers set Deleted=1 where idcustomer =" + valor;
                        GestorCustomers.delCustomers(sql);
                        initTable(" Where Deleted=0");
                    }
                }
                else
                {
                    if (MessageBox.Show("Do yo Want Delete this Customer?", "Delete Customer", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        String sql = "update customers set Deleted=1 where idcustomer =" + valor;
                        GestorCustomers.delCustomers(sql);
                        initTable(" Where Deleted=0");
                    }
                }
                

            }
            else
            {
                if (this.idioma == "ESPAÑOL")
                {
                    MessageBox.Show("Este cliente tiene pedidos en DB");
                }
                else
                {
                    MessageBox.Show("This Customer have Orders in DB");
                }
                
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            try
            {
                int idCustomer = Convert.ToInt16(dgvCustomer.Rows[dgvCustomer.CurrentRow.Index].Cells[0].Value.ToString());
                ModCustomer mc = new ModCustomer(idCustomer,this.idioma);
                mc.ShowDialog();
                if (mc.IsDisposed)
                {
                    initTable(" Where Deleted =0");
                }
            }catch (Exception ex){
                if (this.idioma == "ESPAÑOL")
                {
                    MessageBox.Show("Debes seleccionar un cliente");
                }
                else
                {
                    MessageBox.Show("You must Select a Customer");
                }

            }
           
        }

        private void cmbZip_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String id = dgvCustomer.Rows[dgvCustomer.CurrentRow.Index].Cells[0].Value.ToString();
            String name = dgvCustomer.Rows[dgvCustomer.CurrentRow.Index].Cells[1].Value.ToString();
            String surname = dgvCustomer.Rows[dgvCustomer.CurrentRow.Index].Cells[2].Value.ToString();
            String dni = dgvCustomer.Rows[dgvCustomer.CurrentRow.Index].Cells[3].Value.ToString();
            String address = dgvCustomer.Rows[dgvCustomer.CurrentRow.Index].Cells[4].Value.ToString();
            String phone = dgvCustomer.Rows[dgvCustomer.CurrentRow.Index].Cells[5].Value.ToString();
            String email = dgvCustomer.Rows[dgvCustomer.CurrentRow.Index].Cells[6].Value.ToString();
            String refzipcodescities = dgvCustomer.Rows[dgvCustomer.CurrentRow.Index].Cells[7].Value.ToString();


            DtoCustomer dtoC = new DtoCustomer(id, name, surname, address, phone, email, refzipcodescities, dni);
            if (observer!= null)
            {
                observer.updateCustomer(dtoC);
                Dispose();
            }
            if (observerMod != null)
            {
                observerMod.updateCustomer(dtoC);
                Dispose();
            }

        }

        private void Customer_Shown(object sender, EventArgs e)
        {
            dgvCustomer.ClearSelection();
        }
    }
}
