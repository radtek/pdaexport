using System.Collections.Generic;
using Logic.Transfer;

namespace Logic
{
    /// <summary>
    /// ������� ������ �� ��������� ������ ( ���� ��������������) 
    /// �� ���������� ����� � ����� ������� (Oracle -> Oracle).
    /// </summary>
    public class ActionToTempTransferScripts:AbstractAction
    {
        public ActionToTempTransferScripts(List<int> IDBR)
        {
           
        }
        public override string Name()
        {
            return "��������� ������ ��� ��������";
        }

        public override void Run()
        {
            // �������� ������
            /// ������� �� ������� MainParams ������ � isLight
            /// �� ��������� ����� �������� ������ ������ ��� ������.
            /// ���������� ������� � ��������� ������ Select 
            /// ��������� ���� �� � ������� ������ '{0}' 
            ///     - ��� ������ ��� ���� ���������� �� ������
            ///     - ��� �������� �� ������ ��� �� ������ ��������� ��������
            ///         ��������� string.format([������], idBR);
            ///     - ���� ������ ����������� �� ���������� ������ 
            ///         ������� �� ������ �� ���� � ������ ����� ������ Select
            ///  �������������� ������ ���������������� � 
            ///     insert into BMEXPORT.[tablename] [������] 
            /// ��� ��� ���� ��������� ������ �������� ����� 
            ///  - OnExecute ����� ������ �������
            ///  - ���������� � args ���-�� ������ � ����� ������� (��� �������� ����)
            ///  - ��������� Running ����� ������ ��������� � ���� false ���������� ������
           
    
        }
    }
}
