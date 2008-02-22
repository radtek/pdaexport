using System.Data.SqlServerCe;

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
