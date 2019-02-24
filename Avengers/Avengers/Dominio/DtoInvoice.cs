using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avengers.Dominio
{
    public class DtoInvoice
    {
        private String idInvoice;
        private String dateInvoice;
        private String refCustomer;
        private String net_Amount;
        private String amount;

        public string IdInvoice
        {
            get
            {
                return idInvoice;
            }

            set
            {
                idInvoice = value;
            }
        }

        public string DateInvoice
        {
            get
            {
                return dateInvoice;
            }

            set
            {
                dateInvoice = value;
            }
        }

        public string RefCustomer
        {
            get
            {
                return refCustomer;
            }

            set
            {
                refCustomer = value;
            }
        }

        public string Net_Amount
        {
            get
            {
                return net_Amount;
            }

            set
            {
                net_Amount = value;
            }
        }

        public string Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public DtoInvoice(string idInvoice, string dateInvoice, string refCustomer, string net_Amount, string amount)
        {
            this.idInvoice = idInvoice;
            this.dateInvoice = dateInvoice;
            this.refCustomer = refCustomer;
            this.net_Amount = net_Amount;
            this.amount = amount;
        }

        public DtoInvoice()
        {

        }


    }
}
