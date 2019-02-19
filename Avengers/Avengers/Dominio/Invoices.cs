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

        //metodo para sacar la secuencia del idInvoice siendo el año en el que estamos + 4 numeros
        public static int getIdInvoice()
        {
            String year = DateTime.Now.Year.ToString();
            String consulta = "Select max(Idinvoice) from invoices";
            String idDB = GestorInvoices.getUnString(consulta);
            
            int id = 0;
            if (!String.IsNullOrEmpty(idDB))
            {
                String sub = idDB.Substring(0, 4);
                id = (year.Equals(sub)) ? Int32.Parse(idDB) + 1 : Int32.Parse(year + "0001");

            }else
            {
                id = Int32.Parse(year + "0001");
            }

            return id;

        }
    }
}
