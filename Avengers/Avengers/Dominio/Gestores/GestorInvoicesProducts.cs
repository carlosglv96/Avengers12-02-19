using Avengers.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avengers.Dominio.Gestores
{
    class GestorInvoicesProducts
    {
        private DataTable tabla;
        public GestorInvoicesProducts()
        {
            tabla = new DataTable();
        }

        public DataTable getInvoicesProduct()
        {
            return this.tabla;
        }

        public void readInvoicesProduct()
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData("select * from invoices_products order by Idinvoiceproduct", "littlerp");
            tabla = data.Tables["littlerp"];
        }

        public void readInvoicesProduct(String condition)
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData("select * from invoices_products " + condition + " order by Idinvoiceproduct", "littlerp");
            tabla = data.Tables["littlerp"];
        }

        public void readInDB(String sql)
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData(sql, "littlerp");
            tabla = data.Tables["littlerp"];
        }

        public static void insertInvoicesProduct(String sentencia)
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

