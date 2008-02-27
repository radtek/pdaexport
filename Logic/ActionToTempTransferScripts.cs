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
                Exec(lst);
            }
            else
            {
                lst = TableInfo.LoadTables(TableInfo.WayType.LightImport);
                Exec(lst);
            }
          
        }

        public void Exec(List<TableInfo> lst)
        {
            foreach (TableInfo info in lst)
            {
                if (Running)
                {
                    Dictionary<TableInfo.QryType, string> sql = info.sqlText;
                    string select = sql[TableInfo.QryType.SelectBM];
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

                    AbstractAction action;
                    Coordinator.ExecuteDelegateArgs args = new Coordinator.ExecuteDelegateArgs();
                    args.Maximum = lst.Count;//���������� � args ���-�� ������ � ����� ������� (��� �������� ����)
                    args.Pos = count;
                    OnExecute += new ExecuteDelegate(ActionToTempTransferScripts_OnExecute);//�� ���� ��� �������
                }
                else break;
            }
        }

        void ActionToTempTransferScripts_OnExecute(AbstractAction action, Coordinator.ExecuteDelegateArgs args)
        {
            throw new System.Exception("The method or operation is not implemented.");
        }
       

    }
}
