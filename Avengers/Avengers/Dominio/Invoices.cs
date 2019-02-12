using Avengers.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avengers.Dominio
{
    class Invoices
    {
        private String name;
        private GestorInvoices g;

        public Invoices()
        {

            g = new GestorInvoices();
        }

        public GestorInvoices getGestor()
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
