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
                    AbstractAction action;
                    Coordinator.ExecuteDelegateArgs args = new Coordinator.ExecuteDelegateArgs();
                    args.Maximum = lst.Count;//���������� � args ���-�� ������ � ����� ������� (��� �������� ����)
                    args.Pos = count;
                    OnExecute += new ExecuteDelegate(ActionPrepExportScripts_OnExecute);//�� ���� ��� �������
                    count++;
                }
                else break;
            }
        }

        void ActionPrepExportScripts_OnExecute(AbstractAction action, Coordinator.ExecuteDelegateArgs args)
        {
            throw new System.Exception("The method or operation is not implemented.");
        }
    }
}
