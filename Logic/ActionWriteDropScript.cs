using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Logic.PDAStruct;

namespace Logic
{
    public class ActionWriteDropScript:AbstractAction
    {
        private List<PDATable> tables = new List<PDATable>();
        private StreamWriter writer = null;
        public ActionWriteDropScript(StreamWriter writer, List<PDATable> tables)
        {
            this.tables = tables;
            this.writer = writer;
        }
        public override string Name()
        {
            return "Скрипт: Очистка базы";
        }

        public override event AbstractAction.ExecuteDelegate OnExecute;
        public override void Run()
        {
            int count = 1;
            foreach (PDATable table in tables)
            {
                writer.WriteLine("DROP TABLE " + table.Name);
                writer.WriteLine("GO");
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
