using System;
using Logic.Transfer;

namespace Logic
{
    /// <summary>
    /// ����������� �������� � �� �� ���. ��������� ��������� ���������
    /// </summary>
    public class ActionFinishExportScripts:AbstractAction
    {
        public override string Name()
        {
            return "���������� ������������ ���� ���";
        }

        public override event ExecuteDelegate OnExecute;

        public override void Run()
        {
            /// ��������
            /// ������ ������������� � MainParams
            ///     -   expDate = ������� ���� � �����
            ///     -   expState = done ���� ��� � ���� ������ (Logging.WasError)
            /// event � ����� ����� (Max = 1 Pos = 1)
            /// Running �� ���������������
   
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
