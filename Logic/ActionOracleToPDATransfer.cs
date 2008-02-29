using System.Collections.Generic;
using System.Windows.Forms;
using DataBaseWork;
using Logic.Transfer;

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
        private int count = 1;
        private List<TableInfo> lst;
        public override event AbstractAction.ExecuteDelegate OnExecute;
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
                string ins = "";
                string temp = "";
                List<DataRows> dr;
                if (Running)
                {
                    QuerySelectOracle q = new QuerySelectOracle();
                    QueryExecPDA qu =new QueryExecPDA();
                    if (!q.Select("select * from BMEXPORT." + info.tableName))
                    {
                        Loging.Loging.WriteLog("Error Select From BMEXPORT", true, true);
                    }
                    else
                    {
                        Loging.Loging.WriteLog("Success Select From BMEXPORT", false, true);
                        dr = q.GetRows();
                        foreach (DataRows rows in dr)
                        {
                            ins = "insert into" + info.tableName + "(";
                            foreach (FieldInfo field in info.fields) 
                        {
                            ins += field.fieldName + ", ";
                            temp += rows.FieldByName(field.fieldName)+ ", ";
                            
                        }
                            ins = ins.Remove(ins.LastIndexOf(','), 1);
                            temp = temp.Remove(temp.LastIndexOf(','), 1);
                            ins += ") values (" + temp + ")";
                            if(!qu.Execute(ins))
                            {
                                Loging.Loging.WriteLog("Error insert into" + info.tableName , true,true);
                            }
                            else Loging.Loging.WriteLog("Success insert into" + info.tableName, false,true);
                            
                        }
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
