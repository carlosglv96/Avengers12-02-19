using Avengers.Dominio.Gestores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avengers.Dominio
{
    class InvoicesProducts
    {
        private String name;
        private GestorInvoicesProducts g;

        public InvoicesProducts()
        {

            g = new GestorInvoicesProducts();
        }

        public GestorInvoicesProducts getGestor()
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

