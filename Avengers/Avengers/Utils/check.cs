using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avengers.Utils
{
    class check
    {
        /*
         * Metodo para comprobar si el DNI cumple con el formato correcto
         */
        public static bool checkDNI(String dni)
        {
            Regex regex = new Regex("[0-9]{8,8}[A-Za-z]");
            return regex.IsMatch(dni);
        }
        /*
         * Metodo para comprobar si el email cumple el formato correcto
         */
        public static bool checkEmail(String email)
        {
            Regex regex = new Regex("^[a-zA-Z0-9_!#$%&’*+/=?`{|}~^.-]+@[a-zA-Z0-9.-]+$");
            return regex.IsMatch(email);
        }
        public static bool checkInt(String number)
        {
            Regex regex = new Regex("^([0-9]{1,8})$");
            return regex.IsMatch(number);
        }
        public static bool checkPrice(String price)
        {
            Regex regex = new Regex("^([0-9]{1,7}[.,]{1,1}[0-9]{1,2})|([0-9]{1,5})$");
            return regex.IsMatch(price);
        }

        //metodo para controlar cantidades tanto positivas como negativas
		public static bool checkAmount(String amount)
        {
            bool check = false;
            Regex regex = new Regex("^-?([0-9]{1,5}[.,]{1,1}[0-9]{1,2})|-?([0-9]{1,5})");
            if (regex.IsMatch(amount)){
                double cant = Convert.ToDouble(amount);
                check= (cant >= -99999.99 && cant <= 99999.99)?true:false;

            }
            return check;
        }
        //Metodo para controlar las cantidades solo positivas
        public static bool checkAmountPos(String amount)
        {
            bool check = false;
            Regex regex = new Regex("^([0-9]{1,5}[.,]{1,1}[0-9]{1,2})|([0-9]{1,5})");
            if (regex.IsMatch(amount))
            {
                double cant = Convert.ToDouble(amount);
                check = (cant > 0 && cant <= 99999.99) ? true : false;

            }
            return check;
        }
     
    }
}
