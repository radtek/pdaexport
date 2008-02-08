using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Text;

namespace DataBaseWork
{
    public class QuerySelectPDA:QuerySelect
    {
        private class RecordSet
        {
            private bool EndOfLines = false;
            public RecordSet(SqlCeDataReader reader)
            {
                this.reader = reader;
                EndOfLines = false;
                /*
                if (reader.HasRows)
                {
                    EndOfLines = false;
                }
                else
                {
                    EndOfLines = true;
                }*/
            }
            public void Next()
            {
                if (!EndOfLines)
                {
                    try
                    {
                        if (!reader.Read())
                        {
                            EndOfLines = true;
                        }
                    }
                    catch
                    {
                        EndOfLines = true;
                    }
                }
            }
            public bool Eof
            {
                get
                {
                    return EndOfLines;
                }
            }
            public string[] Fileds()
            {
                string [] fields = new string[reader.FieldCount];
                for(int i = 0; i<reader.FieldCount; i++)
                {
                    fields[i] = reader.GetName(i);
                }
                return fields;
            }
            public String FieldByName(String Name)
            {
                if (!EndOfLines)
                    return reader[Name].ToString();
                else throw new Exception("Достигнут конец выборки");
            }
            private readonly SqlCeDataReader reader;
        }

        public override bool Select(string SQL)
        {
            pErrorMsg = "No error";
            pErrorCode = 0;
            try
            {
                SqlCeCommand command = new SqlCeCommand(SQL, DataBasePDA.Get());
                RecordSet Set = new RecordSet(command.ExecuteReader());
                Set.Next();
                string[] fields = Set.Fileds();
                Rows = new List<DataRows>();
                while(!Set.Eof)
                {
                    DataRows row = new DataRows();
                    foreach (string fieldname in fields)
                    {
                        row.AddField(new DataField(fieldname, Set.FieldByName(fieldname)));
                    }
                    Rows.Add(row);
                    Set.Next();
                }
            }
            catch(Exception ex)
            {
                pErrorMsg = ex.Message;
                pErrorCode = 1;
                throw;
                //return false;
            }
            return true;
        }
    }
}
