using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using DataBaseWork;
using Logic.Transfer;

namespace Logic
{
    public class ActionPDAToOracleTransfer:AbstractAction
    {
        public override string Name()
        {
            return "Перенос данных";
        }
        private int count = 1; //номер текущей таблицы
        public override event AbstractAction.ExecuteDelegate  OnExecute;
        private List<TableInfo> lst;
        public override void Run()
        {
            /// 1. Получить список таблиц для импорта
            /// 2. для каждой таблицы считать данные из PDA
            ///      PDA: select * from [tablename]
            /// 3. Сформировать запрос на вставку и вставить данныхв Oracle (напрямую)
            ///     -   прогресс бар вести по таблицам. (это значит что Pos запсисит от номера 
            ///         переносимой таблицы - форму добавлять не надо:) )
            ///     -   не забыть лог
            ///     -   не забыть Running 
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
                 if (Running)
                 {
                     QuerySelectPDA q = new QuerySelectPDA();
                     QueryExecOracle qu = new QueryExecOracle();
                     if (!q.Select("select * from " + info.tableName))
                     {
                         Loging.Loging.WriteLog("Error:select * from " + info.tableName, true, true);
                     }
                     else
                     {
                         Loging.Loging.WriteLog("OK:select * from " + info.tableName, false, false);
                         List<DataRows> dr = q.GetRows();
                         foreach (DataRows rows in dr)
                         {
                             ins = "insert into " + info.tableName + "(";
                             foreach (FieldInfo field in info.fields)
                             {
                                 ins += field.fieldName + ", ";
                                 temp += "'" + rows.FieldByName(field.fieldName) + "', ";

                             }
                             ins = ins.Remove(ins.LastIndexOf(','), 1);
                             temp = temp.Remove(temp.LastIndexOf(','), 1);
                             ins += ") values (" + temp + ")";
                             if (!qu.Execute(ins))
                             {
                                 Loging.Loging.WriteLog("Error:" + ins, true, true);
                             }
                             else Loging.Loging.WriteLog("OK:" + ins, false, false);
                         }
                     }
                     Coordinator.ExecuteDelegateArgs args = new Coordinator.ExecuteDelegateArgs();
                    args.Maximum = lst.Count;//передавать в args кол-во таблиц и номер текущей (для прогресс бара)
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
