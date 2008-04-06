using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using DAO.Bridges;
using DataBaseWork;
using Logic.Transfer;

namespace Logic
{
    public class ActionClearOracleBr:AbstractAction
    {
        private List<BridgeData> bridges = null;
        public override event AbstractAction.ExecuteDelegate  OnExecute;
        List<TableInfo> lst;
        private int count = 1;//номер текущей таблицы
        public ActionClearOracleBr(List<BridgeData> list)
        {
            bridges = list;
        }

        public override string Name()
        {
            return "Очистка базы от старых данных";
        }

        public override void Run()
        {
            /// 1. Получить список таблиц для импорта (порядок обратный вставке - WayType == ExportClear
            /// 2. Сформировать запрос на очистку (выполять скрипт QryType.Clear в нем выполнить подстановку
            ///    вместо {0} всех idBr (выполнять по очереди - агналогично как при выборе  - ActionToTempTransferScripts)
            ///     -   прогресс бар вести по таблицам. 
            ///     -   не забыть лог
            ///     -   не забыть Running 
            lst = TableInfo.LoadTables(TableInfo.WayType.ExportClear);
            Exec();
        }

        private void Exec()
        {
            count = 1;
            foreach (TableInfo info in lst)
            {
                if (Running)
                {
                    QueryExecOracle q = new QueryExecOracle();
                    string delete = info.sqlText[TableInfo.QryType.Clear];
                    List<string> del = new List<string>();
                    if(delete.Trim() != "") // Проверка на пустой запрос
                       for (int i = 0; i < bridges.Count;i++ )
                            del.Add(string.Format(delete, bridges[i].IDBR));
                    foreach (string s in del)
                    {
                        if(Running)
                        {
                            if (q.Execute(s))
                            {
                                Loging.Loging.WriteLog("OK: " + s, false, false);
                            }
                        }
                        else Loging.Loging.WriteLog("Error: " + s, true, true);}
                    }
                     Coordinator.ExecuteDelegateArgs args = new Coordinator.ExecuteDelegateArgs();
                    args.runningAction = this;
                    args.Name = Name();
                    args.Maximum = lst.Count;//передавать в args кол-во таблиц и номер текущей (для прогресс бара)
                    args.Pos = count;
                    OnExecute(this, args);
                    count++;
                }
                else break;
                }
            }
        }
    }

