using System;
using DataBaseWork;
using OpenNETCF.Desktop.Communication;
namespace Logic
{
    public class ActionDeploy:AbstractAction
    {
        string Text = "Установка базы на КПК";
        bool ToPDA = true;
        /// <summary>
        ///  Копирование базы на КПК
        /// </summary>
        /// <returns></returns>
        public override string Name()
        {
            return Text;
        }

        public override event ExecuteDelegate OnExecute;
        public ActionDeploy(bool toPDA)
            : base()
        {
            ToPDA = toPDA;
            if (!toPDA)
                Text = "Копирование базы с КПК";
        }
        public override void Run()
        {
            /// алгоритм
            /// Disconnect от КПК базы
            /// на основании ConnectionSettings скопировать 
            /// базу с винчейстера на КПК
            /// event в самом конце (Max = 1 Pos = 1)
            /// Running не обрабатываеться    
            /// 

            /// Дополнение:  если ToPDA == false то копирование идет не на КПК а из КПК
            DataBasePDA.Disconnect();
            RAPI rapi=new RAPI();

            try
            {
                rapi.CopyFileToDevice(ConnectionSettings.GetSettings().OracleConnectionString,
                                      ConnectionSettings.GetSettings().PDAConString);
                Loging.Loging.WriteLog("Coping complete",false,true);
            }
            catch(Exception e)
            {
                Loging.Loging.WriteLog("Coping failed: "+e.Message, false, true);
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
