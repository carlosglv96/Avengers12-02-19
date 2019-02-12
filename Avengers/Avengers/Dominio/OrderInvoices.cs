using Avengers.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avengers.Dominio
{
    class OrderInvoices
    {
        private String name;
        private GestorOrderInvoices g;

        public OrderInvoices()
        {

            g = new GestorOrderInvoices();
        }

        public GestorOrderInvoices getGestor()
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
