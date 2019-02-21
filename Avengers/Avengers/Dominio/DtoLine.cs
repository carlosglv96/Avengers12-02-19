using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avengers.Dominio
{
    class DtoLine
    {
        private String idLine;
        private String refInvoice;
        private String description;
        private String quantity;
        private String price;

 
        public string RefInvoice
        {
            get
            {
                return refInvoice;
            }

            set
            {
                refInvoice = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public string Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public string IdLine
        {
            get
            {
                return idLine;
            }

            set
            {
                idLine = value;
            }
        }

        public DtoLine(String description,String quantity,String price)
        {
            this.Description = description;
            this.Quantity = quantity;
            this.Price = price;

        }

        public  bool Equals(object obj)
        {
            
            DtoLine line = obj as DtoLine;
            if (line == null)
            {
                return false;
            }
            return (this.idLine.Equals(line.idLine) && this.description.Equals(line.description));
          
        }


    }
}
