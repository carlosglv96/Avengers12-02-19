using Avengers.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avengers.Dominio
{
    class PPayments
    {
        private String name;
        private GestorPPayment g;

        public PPayments()
        {

            g = new GestorPPayment();
        }

        public GestorPPayment getGestor()
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
