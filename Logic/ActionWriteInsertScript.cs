using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DataBaseWork;
using Logic.PDAStruct;

namespace Logic
{
    public class ActionWriteInsertScript:AbstractAction
    {
        private List<PDATable> tables = new List<PDATable>();
        private StreamWriter writer = null;
        public ActionWriteInsertScript(StreamWriter writer, List<PDATable> tables)
        {
            this.tables = tables;
            this.writer = writer;
        }

        public override string Name()
        {
            return "Скрипт: перенос данных";
        }
        public override event AbstractAction.ExecuteDelegate OnExecute;
        public override void Run()
        {
            int count = 1;
            foreach (PDATable table in tables)
            {
                // select data
                QuerySelect query = QuerySelect.Create(BaseType.PDA);
                query.Select("select * from " + table.Name);
                List<DataRows> rows = query.GetRows();
                foreach (DataRows row in rows)
                {
                    // create insert script
                    writer.WriteLine("INSERT INTO " + table.Name + " ");
                    writer.WriteLine("( ");
                    string Fields = "  ";
                    foreach (PDAField field in table.fields)
                    {
                        Fields +=(field.Name +  ", " );
                    }
                    Fields = Fields.Remove(Fields.Length - 2, 2);
                    writer.WriteLine(Fields);
                    writer.WriteLine(") ");
                    writer.WriteLine("VALUES ");
                    writer.WriteLine("( ");
                    string Values = "  ";
                    foreach (PDAField field in table.fields)
                    {
                        string val =  "'" + row.FieldByName(field.Name).Replace("'", "''") + "'";
                        if(val == "''")
                            if((field.DataType == "numeric")||(field.DataType == "datetime"))
                                val = "NULL";
                        if((field.DataType == "numeric"))
                            val = val.Replace(',', '.');
                        
                        Values += (val + ", " );
                    }
                    Values = Values.Remove(Values.Length - 2, 2);
                    writer.WriteLine(Values);
                    writer.WriteLine(") ");
                    writer.WriteLine("GO");

                    }
                Loging.Loging.WriteLog("TABLE: " + table.Name + " exported " + rows.Count + " rows", false, true);
                Coordinator.ExecuteDelegateArgs args = new Coordinator.ExecuteDelegateArgs();
                args.Maximum = tables.Count;//передавать в args кол-во таблиц и номер текущей (для прогресс бара)
                args.Pos = count;
                args.runningAction = this;
                args.Name = Name();
                OnExecute(this, args);
                count++;
            }
        }
    }
}
