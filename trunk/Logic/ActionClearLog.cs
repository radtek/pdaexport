using System;
using System.Collections.Generic;
using System.Text;
using DataBaseWork;

namespace Logic
{
    /// <summary>
    /// Очитска таблиц лога BrLog и BrLogDet в PDA базе
    /// </summary>
    public class ActionClearLog:AbstractAction
    {
        public override event ExecuteDelegate OnExecute;
        public QueryExecPDA q=new QueryExecPDA();
        private readonly string clearBrLog = "delete  from BrLog";
        private readonly string clearBrLogDet = "delete  from BrLogDet";
        public override string Name()
        {
            return "Очистка лога";
        }

        public override void Run()
        {
            if (Running)
            {
                if(q.Execute(clearBrLog))
                {
                    Loging.Loging.WriteLog("OK: " + clearBrLog, false, false);
                }
                else Loging.Loging.WriteLog("Error: " + clearBrLog, true, true);
                if (q.Execute(clearBrLogDet))
                {
                    Loging.Loging.WriteLog("OK: " + clearBrLogDet, false, false);
                }
                else Loging.Loging.WriteLog("Error: " + clearBrLogDet, true, true);
            }
            Coordinator.ExecuteDelegateArgs args = new Coordinator.ExecuteDelegateArgs();
            args.Maximum = 1;
            args.Pos = 1;
            args.runningAction = this;
            args.Name = Name();
            OnExecute(this, args);
        }
    }
}
