using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avengers.Dominio
{
    public class DtoOrder
    {
        private String idOrder;
        private String nombre;
        private String apellido;
        private String refusuario;
        private String date;
        private String payMethod;
        private String total;
        private String prepaid;

        public string IdOrder
        {
            get
            {
                return idOrder;
            }

            set
            {
                idOrder = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public string Refusuario
        {
            get
            {
                return refusuario;
            }

            set
            {
                refusuario = value;
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

        public string PayMethod
        {
            get
            {
                return payMethod;
            }

            set
            {
                payMethod = value;
            }
        }

        public string Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public string Prepaid
        {
            get
            {
                return prepaid;
            }

            set
            {
                prepaid = value;
            }
        }

        public DtoOrder(string idOrder, string nombre, string apellido, string refusuario, string date, string payMethod, string total, string prepaid)
        {
            this.IdOrder = idOrder;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Refusuario = refusuario;
            this.Date = date;
            this.PayMethod = payMethod;
            this.Total = total;
            this.Prepaid = prepaid;
        }

    }
}
