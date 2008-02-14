using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Text;

namespace DataBaseWork
{
    public class QueryExecOracle:QueryExec
    {
        public override bool Execute(string SQL)
        {
            OracleCommand command = new OracleCommand(SQL, DataBaseOracle.Get());
            try
            {
                command.ExecuteNonQuery();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }
    }
}