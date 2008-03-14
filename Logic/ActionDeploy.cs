using System;
using DataBaseWork;
using OpenNETCF.Desktop.Communication;
namespace Logic
{
    public class ActionDeploy:AbstractAction
    {
        string Text = "��������� ���� �� ���";
        bool ToPDA = true;
        /// <summary>
        ///  ����������� ���� �� ���
        /// </summary>
        /// <returns></returns>
        public override string Name()
        {
            return Text;
        }

        public override event ExecuteDelegate OnExecute;
        public ActionDeploy(bool toPDA)
        {
            ToPDA = toPDA;
            if (!toPDA)
                Text = "����������� ���� � ���";
        }
        public override void Run()
        {
            /// ��������
            /// Disconnect �� ��� ����
            /// �� ��������� ConnectionSettings ����������� 
            /// ���� � ����������� �� ���
            /// event � ����� ����� (Max = 1 Pos = 1)
            /// Running �� ���������������    
            /// 

            /// ����������:  ���� ToPDA == true �� ����������� ���� �� �� ��� � �� ���
            DataBasePDA.Disconnect();
            RAPI rapi=new RAPI();
            if(!ToPDA)
               try
                    {
                        if(rapi.DevicePresent)
                        rapi.Connect();
                        rapi.CopyFileToDevice(ConnectionSettings.GetSettings().PDAConnectionString,
                                              ConnectionSettings.GetSettings().PDAConString, true);
                        Loging.Loging.WriteLog("Coping to PDA complete", false, true);
                        
                    }
                    catch (Exception e)
                    {
                        Loging.Loging.WriteLog("Coping  to PDA failed: " + e.Message, false, true);
                    }
               
            else
                try
                {
                    if(rapi.DevicePresent)
                    rapi.Connect();
                    rapi.CopyFileFromDevice(ConnectionSettings.GetSettings().PDAConnectionString,
                                          ConnectionSettings.GetSettings().PDAConString, true);
                    Loging.Loging.WriteLog("Coping  from PDA complete", false, true);
                }
                catch (Exception e)
                {
                    Loging.Loging.WriteLog("Coping from PDA failed: " + e.Message, false, true);
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
