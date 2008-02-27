using System.Collections.Generic;
using DataBaseWork;
using Logic.Transfer;

namespace Logic
    
{
    /// <summary>
    /// �������������� ��������� ����� �� �������� ������ - ������� �������
    /// </summary>
    public class ActionPrepExportScripts:AbstractAction
    {
        public override event ExecuteDelegate OnExecute;
        public override string Name()
        {
            return "���������� ���� ��� ��������";
        }
        private int count = 1; //����� ������� �������
        private List<TableInfo> lst;
        public override void Run()
        {
            /// ��������
            /// �������� �� ������� MainParams ������ � isLight
            /// �� ��������� ����� �������� ������ ������ ��� ������.
            /// ���������� ������� � ��������� ������ 
            /// delete from BMEXPORT.[tableName] - � Oracle
            /// delete from [tableName] - PDA 
            /// ��� ��� ���� ��������� ������ �������� ����� 
            ///  - OnExecute ����� ������ �������
            ///  - ���������� � args ���-�� ������ � ����� ������� (��� �������� ����)
            ///  - ��������� Running ����� ������ ��������� � ���� false ���������� ������
            //--
            
            if (MainParams.GetParam(MainParams.ParamName.isLight) == "0")
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
            foreach (TableInfo info in lst)
            {
                if (Running)
                {
                    QueryExecOracle q = new QueryExecOracle();
                    QueryExecPDA qu = new QueryExecPDA();
                    q.Execute("delete from BMEXPORT." + info.tableName);
                    qu.Execute("delete from" + info.tableName);
                    Coordinator.ExecuteDelegateArgs args = new Coordinator.ExecuteDelegateArgs();
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
