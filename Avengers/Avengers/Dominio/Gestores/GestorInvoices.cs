using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Avengers.Persistencia;

namespace Avengers.Dominio.Gestores
{
    class GestorInvoices
    {
        private DataTable tabla;

        public GestorInvoices()
        {
            tabla = new DataTable();
        }

        public DataTable getInvoices()
        {
            return this.tabla;
        }

        public void readInvoices()
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData("Select * from invoices order by idinvoice", "littlerp");
            tabla = data.Tables["littlerp"];
        }
        public String getDataV2(String column, String table, String cond)
        {
            ConnectOracle select = new ConnectOracle();
            return select.DLookUp(column, table, cond).ToString();

        }

        public static String getUnString(String sql)
        {
            ConnectOracle select = new ConnectOracle();
            return select.getData(sql);
        }

        public void readInInvoices(String column, String cond)
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData("Select " + column + " from invoices " + cond + " order by idinvoice", "littlerp");
            tabla = data.Tables["littlerp"];
        }

        public void readInDB(String column, String table, String cond)
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData("Select " + column + " from " + table + " " + cond, "littlerp");
            tabla = data.Tables["littlerp"];

        }

        public void readInDB(String query)
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData(query, "littlerp");
            tabla = data.Tables["littlerp"];
        }

        public static void deleteInvoice(String sentencia)
        {
            ConnectOracle delete = new ConnectOracle();
            delete.setData(sentencia);

        }
        public static void insertInvoice(String sentencia)
        {
            ConnectOracle insert = new ConnectOracle();
            insert.setData(sentencia);
        }
        public static String getData(String column, String table, String cond)
        {
            ConnectOracle select = new ConnectOracle();
            return select.DLookUp(column, table, cond).ToString();

        }

        public void setData(String sentencia)
        {
            ConnectOracle update = new ConnectOracle();
            update.setData(sentencia);
        }

    }
}

