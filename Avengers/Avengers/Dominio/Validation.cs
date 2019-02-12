using Avengers.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avengers.Dominio
{
    class Validation
    {
        private String name;
        private GestorValidation g;
        public Validation()
        {
            g = new GestorValidation();
        }

        public GestorValidation getGestor()
        {
            return this.g;
        }
        public String getName()
        {
            return this.name;
        }

        public void setName(String name)
        {
            this.name = name;
        }
    }

}
