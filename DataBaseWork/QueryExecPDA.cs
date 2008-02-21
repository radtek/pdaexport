using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Text;

namespace DataBaseWork
{
   public class QueryExecPDA:QueryExec
    {
        public override bool Execute(string SQL)
        {

            SqlCeCommand command = new SqlCeCommand(SQL, DataBasePDA.Get());
            command.ExecuteNonQuery();
            return true;
           
        }
    }
}
