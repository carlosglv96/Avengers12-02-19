using Avengers.Dominio;
using Avengers.Dominio.Gestores;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avengers
{
    public partial class Login : Form
    {
        private User u1;
        String idioma;
        Presentacion.Menu m1;
        public Login()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            u1 = new User();
            String hash = "c93ccd78b2076528346216b3b2f701e6";
            String sql;
          
            u1.setNombre(nom.Text.ToUpper());
          
            u1.setContra(GestorUsers.GetMD5(pass.Text)); 

            

            int val = GestorUsers.ValidarConx(u1);

            if (GestorUsers.existsUser(u1.getNombre()))
            {
                if (val == 1)
                {
                    sql = "Select IDUSER from usuario where upper(name) ='" + u1.getNombre().ToUpper() + "'";
                    String idUser = GestorUsers.getUnString(sql);
                    sql = "Select Password from usuario where iduser=" + idUser;
                    u1.setId(int.Parse(idUser));
                    String passUser = GestorUsers.getUnString(sql);
                    
                    if (passUser.Equals(hash, StringComparison.OrdinalIgnoreCase))
                    {

                        if (this.idioma == "ESPAÑOL")
                        {
                            String newPass = (Interaction.InputBox("Bienvenido " + u1.getNombre() + " Introduce nueva contraseña", "Nueva contraseña"));
                            //Console.WriteLine(newPass);
                            u1.setContra(GestorUsers.GetMD5(newPass));
                            u1.gestor().setDataV2("update usuario set password = '" + u1.getContra() + "' Where iduser = "+idUser);
                            MessageBox.Show("Contraseña modificada correctamente");
                        }
                        else
                        {
                            String newPass = (Interaction.InputBox("Welcolme " + u1.getNombre() + " Input your new pass", "New Pass"));
                            //Console.WriteLine(newPass);
                            u1.setContra(GestorUsers.GetMD5(newPass));
                            u1.gestor().setDataV2("update usuario set password = '" + u1.getContra() + "' Where iduser = "+idUser);
                            MessageBox.Show("pass modify successful");
                        }
                         m1 = new Presentacion.Menu(u1, this.idioma);
                        this.Hide();
                        m1.Show();
                    }
                    else
                    {
                         m1 = new Presentacion.Menu(u1, this.idioma);
                        this.Hide();
                        m1.Show();
                    }

                }
                else
                {
                    if (this.idioma == "ESPAÑOL")
                    {
                        MessageBox.Show("Contraseña Incorrecta");
                    }
                    else
                    {
                        MessageBox.Show("wrong Password");
                    }
                }

            }
            else
            {
                if (this.idioma == "ESPAÑOL")
                {
                    MessageBox.Show("El Usuario no existe");
                }
                else
                {
                    MessageBox.Show("User dont Exist");
                }
            }
        }
           

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.idioma = comboBox1.Text.ToUpper();
            if (this.idioma == "ESPAÑOL")
            {
                idioma_es();
                this.Text = "Identificarse";
            }
            else if(this.idioma == "INGLES")
            {
                idioma_en();
                this.Text = "Login";
            }
           
        }

        private void idioma_en()
        {
            //Login
            lblSelectIdioma.Text = Avengers.Recursos.Ingles.lblSelectIdioma;
            lblU.Text = Avengers.Recursos.Ingles.lblU;
            lblP.Text = Avengers.Recursos.Ingles.lblP;
            button1.Text = Avengers.Recursos.Ingles.button1;
            button2.Text = Avengers.Recursos.Ingles.button2;           
        }

        private void idioma_es()
        {
            //Login
            lblSelectIdioma.Text = Avengers.Recursos.Espanol.lblSelectIdioma;
            lblU.Text = Avengers.Recursos.Espanol.lblU;
            lblP.Text = Avengers.Recursos.Espanol.lblP;
            button1.Text = Avengers.Recursos.Espanol.button1;
            button2.Text = Avengers.Recursos.Espanol.button2;
        }
    }
}
