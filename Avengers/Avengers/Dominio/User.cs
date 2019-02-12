using Avengers.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.Data;

namespace Avengers.Dominio
{
    public class User
    {
        private String nombre;
        private String contra;
        private int id;
        private GestorUsers g;
        private List<string> permits;
      
        public User()
        {
            g = new GestorUsers();
        }

        public void setPermits()
        {
            DataTable tPermits = GestorUsers.getPermits(nombre);
            permits = new List<string>();

            foreach (DataRow row in tPermits.Rows)
            {
                permits.Add(row[0].ToString());
            }
        }

        public List<string> getPermits()
        {
            return permits;
        }

        public GestorUsers gestor()
        {
            return g;
        }

        public String getNombre()
        {
            return nombre;
        }

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public String getContra()
        {
            return this.contra;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getId()
        {
            return this.id;
        }

        public void setContra(String contra)
        {
            this.contra = contra;
        }
    }
}
