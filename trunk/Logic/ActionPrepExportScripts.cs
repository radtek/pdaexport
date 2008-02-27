using System.Collections.Generic;
using DataBaseWork;
using Logic.Transfer;

namespace Logic
    
{
    /// <summary>
    /// ѕодготавливает временную схему дл прин€ти€ мостов - очищает таблицы
    /// </summary>
    public class ActionPrepExportScripts:AbstractAction
    {
        public override event ExecuteDelegate OnExecute;
        public override string Name()
        {
            return "ѕодготовка базы дл€ переноса";
        }
        private int count = 1; //номер текущей таблицы
        private List<TableInfo> lst;
        public override void Run()
        {
            /// алгоритм
            /// ѕолучаем из таблицы MainParams данные о isLight
            /// на основании этого получает список таблиц дл€ работы.
            /// перебирает таблицы и выполн€ет запрос 
            /// delete from BMEXPORT.[tableName] - ¬ Oracle
            /// delete from [tableName] - PDA 
            /// при все этом учитываем вызовы обратной св€зи 
            ///  - OnExecute после кахдой таблицы
            ///  - передавать в args кол-во таблиц и номер текущей (дл€ прогресс бара)
            ///  - провер€ть Running перед каждой итерацией и если false прекращать работу
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
                    args.Maximum = lst.Count;//передавать в args кол-во таблиц и номер текущей (дл€ прогресс бара)
                    args.Pos = count;
                    OnExecute(this, args);
                    count++;
                }
                else break;
            }
        }
    }
}
