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

namespace Avengers.Presentacion.Users
{
    public partial class NewRole : Form
    {
        private String idioma;

        public NewRole(String idioma)
        {
            InitializeComponent();
            initListBox(" where deleted = 0");
            this.idioma = idioma;
            if (this.idioma == "ESPAÑOL")
            {
                idioma_es();
            }
            else if (this.idioma == "INGLES")
            {
                idioma_en();
            }
        }

        public void idioma_es()
        {
            lblRoleName.Text = Recursos.Espanol.lblRoleName;
            lblPermList.Text = Recursos.Espanol.lblPermList;
            lblSelectedPerm.Text = Recursos.Espanol.lblSelectedPerm;
            btnCancel.Text = Recursos.Espanol.btnCancel;
            btnCreate.Text = Recursos.Espanol.btnCreate;
        }
        public void idioma_en()
        {
            lblRoleName.Text = Recursos.Ingles.lblRoleName;
            lblPermList.Text = Recursos.Ingles.lblPermList;
            lblSelectedPerm.Text = Recursos.Ingles.lblSelectedPerm;
            btnCancel.Text = Recursos.Ingles.btnCancel;
            btnCreate.Text = Recursos.Ingles.btnCreate;
        }

        private void initListBox(String condition)
        {

            User u = new User();
            u.gestor().readPermits(condition);

            DataTable tPermits = u.gestor().getUsers();

            lbxPermissionList.DataSource = tPermits;
            lbxPermissionList.DisplayMember = "name";
            lbxPermissionList.ValueMember = "idpermit";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            List<object> listTemp = new List<object>();

            foreach (var item in lbxPermissionList.SelectedItems)
            {
                listTemp.Add(item);
            }

            DataTable dt = lbxSelectedPerm.DataSource as DataTable;

            if (dt == null)
            {
                dt = new DataTable();
                dt.Columns.Add("idpermit");
                dt.Columns.Add("name");

                lbxSelectedPerm.ValueMember = "idpermit";
                lbxSelectedPerm.DisplayMember = "name";

            }

            foreach (var item in listTemp)
            {

                DataRowView rowOrigen = (DataRowView) item;

                DataRow newRow = dt.NewRow();
                newRow["idpermit"] = rowOrigen["idpermit"]; //nombre columna definida como ValueMemeber en el listbox1
                newRow["name"] = rowOrigen["name"];
                dt.Rows.Add(newRow);

                lbxPermissionList.Items.Remove(item);
            }

            lbxSelectedPerm.DataSource = dt;
        }

        private void btnAddOne_Click(object sender, EventArgs e)
        {
            lbxSelectedPerm.Items.Add(((DataRowView)lbxPermissionList.SelectedItem).Row.ItemArray[1].ToString());
    

        }

        private void btnRemoveOne_Click(object sender, EventArgs e)
        {
            while (lbxSelectedPerm.SelectedIndices.Count > 0)
            {
                lbxPermissionList.Items.Add(lbxSelectedPerm.SelectedItems[0]);
                lbxSelectedPerm.Items.Remove(lbxSelectedPerm.SelectedItems[0]);
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            while (lbxPermissionList.Items.Count > 0)
            {
                lbxSelectedPerm.Items.Add(lbxPermissionList.Items[0]);
                lbxPermissionList.Items.Remove(lbxPermissionList.Items[0]);
            }
        }
    }
}