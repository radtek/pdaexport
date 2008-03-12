using System.Collections.Generic;
using DataBaseWork;
using Logic.Transfer;

namespace Logic
{
    /// <summary>
    /// Перенос данных по выбранным мостам ( плюс классификаторы) 
    /// из клиентской схемы в схему импорта (Oracle -> Oracle).
    /// </summary>
    public class ActionToTempTransferScripts:AbstractAction
    {
        private int count = 1;//номер текущей таблицы
        List<TableInfo> lst;
        private readonly List<int> idBr;
        public override event ExecuteDelegate OnExecute;
        public ActionToTempTransferScripts(List<int> IDBR)
        {
            idBr = IDBR;
        }
        public override string Name()
        {
            return "Подготока мостов для переноса";
        }

        public override void Run()
        {
            // алгоритм работы
            /// Получам из таблицы MainParams данные о isLight
            /// на основании этого получает список таблиц для работы.
            /// перебирает таблицы и формирует запрос Select 
            /// проверяет есть ли в запросе строка '{0}' 
            ///     - это значит что надо перебирать по мостам
            ///     - при переборе по мостам так же запрос являеться шаблоном
            ///         используй string.format([запрос], idBR);
            ///     - если строка отсутствует то перебирать внутри 
            ///         таблицы по мостам не надо а просто взять запрос Select
            ///  сформированный запрос модернизируется в 
            ///     insert into BMEXPORT.[tablename] [запрос] 
            /// при все этом учитаваем вызовы обратной связи 
            ///  - OnExecute после кахдой таблицы
            ///  - передавать в args кол-во таблиц и номер текущей (для прогресс бара)
            ///  - проверять Running перед каждой итерацией и если false прекращать работу

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
                    QueryExecOracle q=new QueryExecOracle();
                    string select = info.sqlText[TableInfo.QryType.SelectBM];
                    List<string> sel = new List<string>();
                    if (select.Contains("{0}"))
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
                    foreach (string s in ins)
                    {
                        if(q.Execute(s))
                        {
                            Loging.Loging.WriteLog("OK: " + s, false, false);
                        }
                        else Loging.Loging.WriteLog("Error: " + s, true, false);

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
