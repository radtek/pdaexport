using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Logic.PDAStruct;

namespace Logic
{
    public class ActionWriteCreateTableScript:AbstractAction
    {
        private List<PDATable> tables = new List<PDATable>();
        private StreamWriter writer = null;

        public ActionWriteCreateTableScript(StreamWriter writer, List<PDATable> tables)
        {
            this.tables = tables;
            this.writer = writer;
        }

        public override string Name()
        {
            return "Скрипт: создание таблиц";
        }
        public override event AbstractAction.ExecuteDelegate OnExecute;
        public override void Run()
        {
            int count = 1;
            foreach (PDATable table in tables)
            {
                writer.WriteLine("CREATE TABLE " + table.Name + " {");
                int i = 1;
                int Count = table.fields.Count;
                bool HasPK = false;
                string PKStr = "";
                foreach (PDAField field in table.fields)
                {
                    writer.WriteLine("    " + field.Name + "\t\t  " + field.FullDataType + 
                        "  \t" + (field.Nullable?"NULL":"NOT NULL") +
                        ((i<Count)?", ":""));
                    i++;
                    if (field.IsPK)
                    {
                        HasPK = true;
                        PKStr += field.Name + ", ";

                    }
                }
                writer.WriteLine("}");
                writer.WriteLine("GO");
                if(HasPK)
                {
                    PKStr = PKStr.Remove(PKStr.Length - 2, 2);
                    writer.WriteLine("ALTER TABLE " +table.Name + " ADD PRIMARY KEY (" + PKStr + ")");
                    writer.WriteLine("GO");
                }

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
/* CREATE TABLE EditInterface (
        idPointer            numeric(10,0) NOT NULL,
        idMainPointer        numeric(10,0) NULL,
        idElement            numeric(10,0) NULL,
        textDefinition       nvarchar(250) NULL,
        fieldName            nvarchar(40) NULL,
        fieldLenght          numeric(10,0) NULL,
        fieldLinesCount      numeric(10,0) NULL,
        clsFlagTrue          numeric(10,0) NULL,
        clsFlagFalse         numeric(10,0) NULL,
        queryGroup           numeric(10,0) NULL,
        queryList            numeric(10,0) NULL
 )
go
 
 
 ALTER TABLE EditInterface
        ADD PRIMARY KEY (idPointer)
 
  ALTER TABLE BrBeam
        ADD PRIMARY KEY (idBrBeam, idBr)
 */