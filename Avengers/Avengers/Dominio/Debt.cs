using Avengers.Dominio.Gestores;
using System;

namespace Avengers.Dominio
{

    class Debt
    {

        private String name;
        private GestorDebts g;

        public Debt()
        {
            g = new GestorDebts();
        }

        public GestorDebts getGestor()
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