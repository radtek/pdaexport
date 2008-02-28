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
        private int count = 1;//����� ������� �������
        List<TableInfo> lst;
        private List<int> idBr;
        public override event ExecuteDelegate OnExecute;
        public ActionToTempTransferScripts(List<int> IDBR)
        {
            idBr = IDBR;
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
            ///  �������������� ������ ��������������� � 
            ///     insert into BMEXPORT.[tablename] [������] 
            /// ��� ��� ���� ��������� ������ �������� ����� 
            ///  - OnExecute ����� ������ �������
            ///  - ���������� � args ���-�� ������ � ����� ������� (��� �������� ����)
            ///  - ��������� Running ����� ������ ��������� � ���� false ���������� ������

            if(MainParams.GetParam(MainParams.ParamName.isLight) == "0")
            {
                lst = TableInfo.LoadTables(TableInfo.WayType.AllImport);
            }
            else
            {
                lst = TableInfo.LoadTables(TableInfo.WayType.LightImport);
            }
            Exec();
        }

        public void Exec()
        {
            count = 1;
            foreach (TableInfo info in lst)
            {
                if (Running)
                {
                    //Dictionary<TableInfo.QryType, string> sql = info.sqlText;
                    string select = info.sqlText[TableInfo.QryType.SelectBM];
                    List<string> sel = new List<string>();
                    if (select.Contains("'{0}'"))
                    {
                        foreach (int i in idBr)
                        {
                            sel.Add(string.Format(select, i));
                        }
                    }
                    else sel.Add(select);
                    List<string> ins = new List<string>();
                    foreach (string s in sel)
                    {
                        ins.Add("insert into BMEXPORT." + info.tableName + " " + s);
                    }
                    Coordinator.ExecuteDelegateArgs args = new Coordinator.ExecuteDelegateArgs();
                    args.runningAction = this;
                    args.Name = Name();
                    args.Maximum = lst.Count;//���������� � args ���-�� ������ � ����� ������� (��� �������� ����)
                    args.Pos = count;
                    OnExecute(this, args);
                    count++;
                }
                else break;
            }
        }
       

    }
}
