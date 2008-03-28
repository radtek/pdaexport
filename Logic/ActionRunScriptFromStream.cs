using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DataBaseWork;

namespace Logic
{
    public class ActionRunScriptFromStream:AbstractAction
    {
        private int Lines = 0;
        private string fileName = "";
        public ActionRunScriptFromStream(string fileName)
        {
            StreamReader file = new StreamReader(fileName);
            Lines = 0;
            while(!file.EndOfStream)
            {
                string RSQL = file.ReadLine();
                if (RSQL.ToUpper().Trim(' ') == "GO")
                {
                    Lines++;
                }
            }
            file.Close();
            this.fileName = fileName;
        }

        public override string Name()
        {
            return "Ваполнение скрипта";
        }

        public override event AbstractAction.ExecuteDelegate OnExecute;
        public override void Run()
        {
            int count = 1;
            StreamReader file = new StreamReader(fileName);
            string SQL = "";
            while (!file.EndOfStream)
            {
                string RSQL = file.ReadLine();
                if(RSQL.ToUpper().Trim(' ') == "GO")
                {
                    // run SQL
                    if(!QueryExec.Create(BaseType.PDA).Execute(SQL))
                    {
                        Loging.Loging.WriteLog("SQL Error: " + SQL, true, true);
                    }
                    // clear SQL
                    SQL = "";
                    // event 
                    Coordinator.ExecuteDelegateArgs args = new Coordinator.ExecuteDelegateArgs();
                    args.Maximum = Lines;//передавать в args кол-во таблиц и номер текущей (для прогресс бара)
                    args.Pos = count;
                    args.runningAction = this;
                    args.Name = Name();
                    OnExecute(this, args);
                    count++;
                }
                else
                {
                    SQL += RSQL;    
                }
            }
        }
    }
}
