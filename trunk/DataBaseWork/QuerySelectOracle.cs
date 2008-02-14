using System;
using System.Collections.Generic;
using System.Data.OracleClient;

namespace DataBaseWork
{
    public class QuerySelectOracle:QuerySelect
    {
        public override bool Select(string SQL)
        {
            OracleCommand command = new OracleCommand(SQL, DataBaseOracle.Get());
            OracleDataReader reader;
            try
            {
                reader = command.ExecuteReader();
            }
            catch(Exception)
            {
                return false;
            }
            DataRows row;
            Rows=new List<DataRows>();
            while (reader.Read())
            {
                row = new DataRows();
                for (int i = 0; i < reader.FieldCount; i++)
                row.AddField(new DataField(reader.GetName(i), Convert.ToString(reader.GetValue(i))));
                Rows.Add(row);
            }
            DataBaseOracle.Disconnect();
            return true;
            
        }
    }
}
