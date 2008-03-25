using System.Collections.Generic;
using System.Threading;
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
            count = 1;
            foreach (TableInfo info in lst)
            {
                if (Running)
                {
                    QueryExecOracle q = new QueryExecOracle();
                    QueryExecPDA qu = new QueryExecPDA();
                    if (!q.Execute("delete from BMEXPORT." + info.tableName))
                    {
                        Loging.Loging.WriteLog("Error:delete from BMEXPORT." + info.tableName, true, true);
                    }
                    else
                    {
                        Loging.Loging.WriteLog("OK:delete from BMEXPORT." + info.tableName, false, false);
                    }
                    if(!qu.Execute("delete from " + info.tableName))
                    {
                        Loging.Loging.WriteLog("Error:delete from " + info.tableName, true, true);
                    }
                    else
                    {
                        Loging.Loging.WriteLog("OK:delete from " + info.tableName, false, false);
                    }
                    Coordinator.ExecuteDelegateArgs args = new Coordinator.ExecuteDelegateArgs();
                    args.Maximum = lst.Count;//���������� � args ���-�� ������ � ����� ������� (��� �������� ����)
                    args.Pos = count;
                    args.runningAction = this;
                    args.Name = Name();
                    OnExecute(this, args);
                    count++;
                }
                else break;
            }
        }
    }
}
