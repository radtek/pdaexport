using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// ������������� ����� � ������ "��� ������"
    /// </summary>
    public class ActionSetBrReadOnly:AbstractAction
    {
        public ActionSetBrReadOnly(List<int> IDBR)
        {
            
        }
        public override string Name()
        {
            return "������ � ���� Oracle ����� � ��������";
        }

        public override void Run()
        {
            
        }
        public override void Cancel()
        {
            // ������ �������� - ������ ����� �� �����
        }
    }
}
