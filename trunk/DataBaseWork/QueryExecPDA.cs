using System;
using System.Data.SqlServerCe;

namespace DataBaseWork
{
   public class QueryExecPDA:QueryExec
    {
        public override bool Execute(string SQL)
        {
            bool Res = true;
            SqlCeCommand command = new SqlCeCommand(SQL, DataBasePDA.Get());
            try
            {
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Res = false;
                pErrorMsg = ex.Message;
                pErrorCode = -1;
            }
            return Res;
        }
    }
}
