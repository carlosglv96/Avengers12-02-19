using Avengers.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avengers.Dominio.Gestores
{
    class GestorValidation
    {
        private DataTable tabla;

        public GestorValidation()
        {
            tabla = new DataTable();
        }
        public DataTable getValidation()
        {
            return this.tabla;
        }

        public void readInDB(String column, String table, String cond)
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();
            data = search.getData("Select " + column + " from " + table + " " + cond, "littlerp");

            tabla = data.Tables["littlerp"];
        }

        public void readInDB2(String query)
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData(query, "littlerp");
            tabla = data.Tables["littlerp"];
        }

        public void readTable(String cond)
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();
            
            data = search.getData("SELECT V.ID, V.DATE_DEBTS, U.NAME, V.AINCASH, V.ARECEIPT, V.ACHECK, V.TOTAL FROM VALIDATIONS V inner join USUARIO U on REFUSER = IDUSER " + cond + " order by V.DATE_DEBTS desc ", "littlerp");
            tabla = data.Tables["littlerp"];
        }
        public void readTable2(String sql)
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData(sql, "littlerp");
            tabla = data.Tables["littlerp"];
        }
        public void insertValidation(String sentencia)
        {
            ConnectOracle insert = new ConnectOracle();
            insert.setData(sentencia);
        }
    }
}
