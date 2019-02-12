using Avengers.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avengers.Dominio.Gestores
{
    class GestorOrderInvoices
    {
        private DataTable tabla;
        public GestorOrderInvoices()
        {
            tabla = new DataTable();
        }

        public DataTable getOrderInvoices()
        {
            return this.tabla;
        }

        public void readOrderInvoices()
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData("select * from orders_invoices order by Idorderinvoiced", "littlerp");
            tabla = data.Tables["littlerp"];
        }

        public void readOrderInvoices(String condition)
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData("select * from orders_invoices " + condition + " order by Idorderinvoiced", "littlerp");
            tabla = data.Tables["littlerp"];
        }

        public void readInDB(String sql)
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData(sql, "littlerp");
            tabla = data.Tables["littlerp"];
        }

        public static void insertOrderInvoices(String sentencia)
        {
            ConnectOracle insert = new ConnectOracle();
            insert.setData(sentencia);
        }

        public static void setData(String sentencia)
        {
            ConnectOracle update = new ConnectOracle();
            update.setData(sentencia);
        }

    }
}

