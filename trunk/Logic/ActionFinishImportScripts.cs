using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using Logic.Transfer;

namespace Logic
{
    public class ActionFinishImportScripts:AbstractAction
    {
        public override string Name()
        {
            return "Завершения переноса";
        }
        public override event ExecuteDelegate OnExecute;
        public override void Run()
        {
            /// алгоритм
            /// просто устанавливает в MainParams
            ///     -   impDate = текущая дата и время
            ///     -   impState = done если нет в логе ошибок (Logging.WasError)
            /// event в самом конце (Max = 1 Pos = 1)
            /// Running не обрабатываеться
            MainParams.SetParam(MainParams.ParamName.impDate, DateTime.Now.ToShortDateString());
            if (!Loging.Loging.WasError())
                MainParams.SetParam(MainParams.ParamName.impState, "done");
            Coordinator.ExecuteDelegateArgs args = new Coordinator.ExecuteDelegateArgs();
            args.Maximum = 1;
            args.Pos = 1;
            args.runningAction = this;
            args.Name = Name();
            Loging.Loging.WriteLog("DONE", false, true);
            OnExecute(this, args);
        }
    }
}
