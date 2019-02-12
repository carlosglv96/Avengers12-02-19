using System;

namespace Avengers.Dominio
{

    public class DtoDebt
    {

        private String id;
        private String date;
        private String refuser;
        private String username;
        private String concept;
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

        public string Concept
        {
            get
            {
                return concept;
            }

            set
            {
                concept = value;
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

        public DtoDebt(string id, string date, string refuser, string username, string concept, string amount, string paid)
        {
            this.Id = id;
            this.Date = date;
            this.Refuser = refuser;
            this.Username = username;
            this.Concept = concept;
            this.Amount = amount;
            this.Paid = paid;
        }

    }

}