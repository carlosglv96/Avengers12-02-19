using Avengers.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avengers.Dominio.Gestores
{
    class GestorLines
    {
        private DataTable tabla;

        public GestorLines()
        {
            tabla = new DataTable();
        }

        public DataTable getLines()
        {
            return this.tabla;
        }

        public void readLines()
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData("select * from lines order by Idline", "littlerp");
            tabla = data.Tables["littlerp"];
        }

        public void readLines(String condition)
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData("select * from lines " + condition + " order by idlines", "littlerp");
            tabla = data.Tables["littlerp"];
        }

        public void readInDB(String sql)
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData(sql, "littlerp");
            tabla = data.Tables["littlerp"];
        }

        public static void insertLine(String sentencia)
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

