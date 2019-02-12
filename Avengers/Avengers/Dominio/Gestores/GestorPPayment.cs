using Avengers.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avengers.Dominio.Gestores
{
    class GestorPPayment
    {
        private DataTable tabla;

        public GestorPPayment()
        {
            tabla = new DataTable();
        }

        public DataTable getPPayments()
        {
            return this.tabla;
        }

        public void readPPayment()
        {
            DataSet data = new DataSet();
            Persistencia.ConnectOracle search = new Persistencia.ConnectOracle();

            data = search.getData("Select * from ppayment order by id desc", "littlerp");
            tabla = data.Tables["littlerp"];
        }

        public void readPPayment(String cond)
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData("Select * from ppayment " + cond +" order by id desc", "littlerp");
            tabla = data.Tables["littlerp"];
        }

        public void readInPPayment(String cond, String col)
        {

            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData("Select " + col + " from ppayment " + cond + " order by id desc", "littlerp");
            tabla = data.Tables["littlerp"];
        }

        public void readInDB(String column, String table, String cond)
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData("Select " + column + " from " + table + " " + cond, "littlerp");
            tabla = data.Tables["littlerp"];
        }
        public void readInDB(String sql)
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData(sql, "littlerp");
            tabla = data.Tables["littlerp"];
        }
        public static void insertPPayment(String sentencia)
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

