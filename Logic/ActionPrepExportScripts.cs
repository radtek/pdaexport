namespace Logic
{
    /// <summary>
    /// �������������� ��������� ����� �� �������� ������ - ������� �������
    /// </summary>
    public class ActionPrepExportScripts:AbstractAction
    {
        public override string Name()
        {
            return "���������� ���� ��� ��������";
        }

        public override void Run()
        {
            /// ��������
            /// ������� �� ������� MainParams ������ � isLight
            /// �� ��������� ����� �������� ������ ������ ��� ������.
            /// ���������� ������� � ��������� ������ 
            /// delete from BMEXPORT.[tableName] - � Oracle
            /// delete from [tableName] - PDA 
            /// ��� ��� ���� ��������� ������ �������� ����� 
            ///  - OnExecute ����� ������ �������
            ///  - ���������� � args ���-�� ������ � ����� ������� (��� �������� ����)
            ///  - ��������� Running ����� ������ ��������� � ���� false ���������� ������
        }
    }
}
