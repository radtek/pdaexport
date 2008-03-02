using System;
using DataBaseWork;
using OpenNETCF.Desktop.Communication;
namespace Logic
{
    public class ActionDeploy:AbstractAction
    {
        /// <summary>
        ///  ����������� ���� �� ���
        /// </summary>
        /// <returns></returns>
        public override string Name()
        {
            return "��������� ���� �� ���";
        }

        public override event ExecuteDelegate OnExecute;

        public override void Run()
        {
            /// ��������
            /// Disconnect �� ��� ����
            /// �� ��������� ConnectionSettings ����������� 
            /// ���� � ����������� �� ���
            /// event � ����� ����� (Max = 1 Pos = 1)
            /// Running �� ���������������    
            /// 
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
