namespace Logic
{
    /// <summary>
    /// ��������������� ������� ������ �� �� Oracle � �� MSSQL Mobile
    /// (Oracle -> MSSQL Mobile)
    /// </summary>
    public class ActionOracleToPDATransfer:AbstractAction
    {
        public override string Name()
        {
            return "������� ������ �� ���";
        }

        public override void Run()
        {
            /// ��������
            /// 1. �������� ������ ������ (��� � ����������)
            /// 2. ��� ������ ������� ������� ������ �� EXPORT
            ///      Oracle: select * from BMEXPORT.[tablename]
            /// 3. ������� ������ ������� ��� ������� �� ��������� ������ �����
            ///     insert into [tablename]([����1], [����2], .... , ) values ('{0}', '{1}' ... )
            /// 4. ��������� ������ ��������� �� ����� 2 ��������������� ����������� 
            ///     ��� ������ ������ sql ������ �� ��������� ������ ������ � �������
            ///     � ��������� ��� � ���� ���.
            ///     -   �������� ��� ����� �� ��������.
            ///     -   �� ������ ���
            ///     -   �� ������ Running    
        }
    }
}
