using System;
using Logic.Transfer;

namespace Logic
{
    /// <summary>
    /// Заверешение переноса в БД на КПК. Установка системных заначений
    /// </summary>
    public class ActionFinishExportScripts:AbstractAction
    {
        public override string Name()
        {
            return "Завершения формирования базы КПК";
        }

        public override event ExecuteDelegate OnExecute;

        public override void Run()
        {
            /// алгоритм
            /// просто устанавливает в MainParams
            ///     -   expDate = текущая дата и время
            ///     -   expState = done если нет в логе ошибок (Logging.WasError)
            /// event в самом конце (Max = 1 Pos = 1)
            /// Running не обрабатываеться
   
            MainParams.SetParam(MainParams.ParamName.expDate,DateTime.Now.ToString());
            if(!Loging.Loging.WasError())
                MainParams.SetParam(MainParams.ParamName.expState,"done");
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
