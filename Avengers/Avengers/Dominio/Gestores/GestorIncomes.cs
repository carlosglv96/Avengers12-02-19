using Avengers.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avengers.Dominio.Gestores
{
    class GestorIncomes
    {
        private DataTable tabla;

        public GestorIncomes()
        {
            tabla = new DataTable();
        }

        public DataTable getIncomes()
        {
            return this.tabla;
        }

        public void readIncome()
        {
            DataSet data = new DataSet();
            Persistencia.ConnectOracle search = new Persistencia.ConnectOracle();

            data = search.getData("Select * from incomes where refaction = 0 order by id", "littlerp");
            tabla = data.Tables["littlerp"];
        }

        public void readIncomes(String cond)
        {
            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData("Select * from incomes where refaction = 0 and" + cond, "littlerp");
            tabla = data.Tables["littlerp"];
        }

        public void readInIncomes(String cond, String col)
        {

            DataSet data = new DataSet();
            ConnectOracle search = new ConnectOracle();

            data = search.getData("Select " + col + " from incomes where refaction = 0 and" + cond + " order by id", "littlerp");
            tabla = data.Tables["littlerp"];
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

            data = search.getData("SELECT INCOMES.ID,SOURCE_TARGET.ID,TYPES.ID, USUARIO.IDUSER, INCOMES.DATE_INCOMES, USUARIO.NAME, SOURCE_TARGET.TEXT, TYPES.TEXT,INCOMES.TEXT, INCOMES.AMOUNT, INCOMES.REFACTION FROM INCOMES INNER JOIN USUARIO ON REFUSER = IDUSER INNER JOIN SOURCE_TARGET ON REFENTRADA = SOURCE_TARGET.ID INNER JOIN TYPES ON REFTIPO = TYPES.ID "+cond+" ORDER BY INCOMES.ID DESC ", "littlerp");
            tabla = data.Tables["littlerp"];
        }
        public String getUnString(String sql)
        {
            ConnectOracle select = new ConnectOracle();
            return select.getData(sql);
        }



        public void insertIncome(String sentencia)
        {
            ConnectOracle insert = new ConnectOracle();
            insert.setData(sentencia);
        }

        public void deleteIncome(String sentencia)
        {
            ConnectOracle delete = new ConnectOracle();
            delete.setData(sentencia);
        }

        public void updateIncome(String sentencia, String id)
        {
            ConnectOracle update = new ConnectOracle();
            sentencia += " Where ID =" + id;
            update.setData(sentencia);
        }

    }
}
