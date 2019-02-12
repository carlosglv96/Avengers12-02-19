using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avengers.Dominio
{
    public class DtoPPayment
    {
        private String id;
        private String date;
        private String refuser;
        private String username;
        private String refppayment;
        private String ppaymentText;
        private String concep;
        private String amount;
        private String paid;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public string Refuser
        {
            get
            {
                return refuser;
            }

            set
            {
                refuser = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Refppayment
        {
            get
            {
                return refppayment;
            }

            set
            {
                refppayment = value;
            }
        }

        public string PpaymentText
        {
            get
            {
                return ppaymentText;
            }

            set
            {
                ppaymentText = value;
            }
        }

        public string Concep
        {
            get
            {
                return concep;
            }

            set
            {
                concep = value;
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

        public string Paid
        {
            get
            {
                return paid;
            }

            set
            {
                paid = value;
            }
        }

        public DtoPPayment(string id, string date, string refuser, string username, string refppayment, string ppaymentText, string concep, string amount, string paid)
        {
            this.Id = id;
            this.Date = date;
            this.Refuser = refuser;
            this.Username = username;
            this.Refppayment = refppayment;
            this.PpaymentText = ppaymentText;
            this.Concep = concep;
            this.Amount = amount;
            this.Paid = paid;
        }


    }
}
