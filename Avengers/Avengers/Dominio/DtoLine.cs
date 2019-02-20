using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avengers.Dominio
{
    class DtoLine
    {
        private String IidLine;
        private String refInvoice;
        private String description;
        private String quantity;
        private String price;

        public string IidLine1
        {
            get
            {
                return IidLine;
            }

            set
            {
                IidLine = value;
            }
        }

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

        public DtoLine(String description,String quantity,String price)
        {
            this.Description = description;
            this.Quantity = quantity;
            this.Price = price;

        }


    }
}
