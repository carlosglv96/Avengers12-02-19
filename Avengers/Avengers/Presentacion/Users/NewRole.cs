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

        for (int i = 0; i < tPermits.Rows.Count; i++)
        {
            DataRow row = tPermits.Rows[i];
            string rol = row["name"].ToString();
            lbxPermissionList.Items.Add(rol);
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        Dispose();
    }

    private void btnAddAll_Click(object sender, EventArgs e)
    {
        List<string> listTemp = new List<string>();

        foreach (string rol in lbxPermissionList.Items)
        {
            listTemp.Add(rol);
        }
        foreach (string rol in listTemp)
        {
            lbxSelectedPerm.Items.Add(rol);
            lbxPermissionList.Items.Remove(rol);
        }
    }

    private void btnAddOne_Click(object sender, EventArgs e)
    {
        if (lbxPermissionList.SelectedIndex > -1)
        {
            List<string> listTemp = new List<string>();

            foreach (string rol in lbxPermissionList.SelectedItems)
            {
                listTemp.Add(rol);
            }
            foreach (string rol in listTemp)
            {
                lbxSelectedPerm.Items.Add(rol);
                lbxPermissionList.Items.Remove(rol);
            }
        }
    }

    private void btnRemoveOne_Click(object sender, EventArgs e)
    {
        if (lbxSelectedPerm.SelectedIndex > -1)
        {

            List<string> listTemp = new List<string>();

            foreach (string rol in lbxSelectedPerm.SelectedItems)
            {
                listTemp.Add(rol);
            }

            foreach (string rol in listTemp)
            {
                lbxPermissionList.Items.Add(rol);
                lbxSelectedPerm.Items.Remove(rol);
            }
        }
    }

    private void btnRemoveAll_Click(object sender, EventArgs e)
    {
        List<string> listTemp = new List<string>();

        foreach (string rol in lbxSelectedPerm.Items)
        {
            listTemp.Add(rol);
        }
        foreach (string rol in listTemp)
        {
            lbxPermissionList.Items.Add(rol);
            lbxSelectedPerm.Items.Remove(rol);
        }
    }

    private void btnCreate_Click(object sender, EventArgs e)
    {
        if (checkAdd())
        {
            insertRol();
            insertPermits();
            MessageBox.Show("Role created");
            Dispose();
        }
        else
        {
            MessageBox.Show(errorDialog());
        }
    }

    private void insertRol()
    {
        String sql = "insert into ROL values (null, '" + txtRoleName.Text.ToUpper() + "', null, 0)";
        GestorUsers.insertUser(sql);
    }

    private void insertPermits()
    {
        foreach (string rol in lbxSelectedPerm.Items)
        {
            string sql = "insert into ROL_PERMITS values (null, (select IDROL from ROL where upper(NAME) = '" + txtRoleName.Text.ToUpper() + "')";
            sql += ", (select IDPERMIT from PERMITS where upper(NAME) = '" + rol + "'))";
            GestorUsers.insertUser(sql);
        }
    }

    private bool checkAdd()
    {
        bool correct = true;
        if (string.IsNullOrEmpty(txtRoleName.Text.Replace("'", "")))
        {
            correct = false;
        }
        if (GestorUsers.existsRole(txtRoleName.Text.Replace("'", "")))
        {
            correct = false;
        }
        if (lbxSelectedPerm.Items.Count <= 0)
        {
            correct = false;
        }
        return correct;
    }

    private String errorDialog()
    {
        if (this.idioma == "ESPAÑOL")
        {
            String error = "Se han encontrado algunos errores: \n";

            if (string.IsNullOrEmpty(txtRoleName.Text.Replace("'", "")))
            {
                error += "\t - El campo \"Nombre del Rol\" no puede estar vacio. \n";
            }
            if (GestorUsers.existsRole(txtRoleName.Text.Replace("'", "")))
            {
                error += "\t - Este rol ya existe. \n";
            }
            if (lbxSelectedPerm.Items.Count <= 0)
            {
                error += "\t - Debes seleccionar al menos un permiso. \n";
            }
            return error;
        }
        else
        {
            String error = "Some Errors have been found: \n";

            if (string.IsNullOrEmpty(txtRoleName.Text.Replace("'", "")))
            {
                error += "\t - The field \"Role Name\" can't be empty. \n";
            }
            if (GestorUsers.existsRole(txtRoleName.Text.Replace("'", "")))
            {
                error += "\t - This role already exists. \n";
            }
            if (lbxSelectedPerm.Items.Count <= 0)
            {
                error += "\t - You must select at least one permit. \n";
            }
            return error;
        }
    }
}
}