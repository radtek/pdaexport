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

        public override void Run()
        {
            /// ��������
            /// ������ ������������� � MainParams
            ///     -   expDate = ������� ���� � �����
            ///     -   expState = done ���� ��� � ���� ������ (Logging.WasError)
            /// event � ����� ����� (Max = 1 Pos = 1)
            /// Running �� ���������������
   
        }
    }
}
