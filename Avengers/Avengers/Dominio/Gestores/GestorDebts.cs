using System;
using System.Data;
using Avengers.Persistencia;

namespace Avengers.Dominio.Gestores
{

    class GestorDebts
    {

        private DataTable tabla;

        public GestorDebts()
        {
            tabla = new DataTable();
        }

        public DataTable getDebts()
        {
            return this.tabla;
        }

        public void readDebts()
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData("select * from DEBTS order by ID desc", "littlerp");
            tabla = data.Tables["littlerp"];
        }

        public void readDebts(String condition)
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData("select * from DEBTS " + condition + " order by ID desc", "littlerp");
            tabla = data.Tables["littlerp"];
        }

        public void readInDB(String column, String table, String cond)
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData("select " + column + " from " + table + " " + cond, "littlerp");
            tabla = data.Tables["littlerp"];
        }

        public void readInDB(String sql)
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData(sql, "littlerp");
            tabla = data.Tables["littlerp"];
        }

        public static void insertDebt(String sentencia)
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