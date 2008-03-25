using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using DataBaseWork;

namespace Logic
{
    public class ActionSwitchTriggers:AbstractAction
    {
        string Title = "";
        bool On = false;
        public ActionSwitchTriggers(bool On, string title)
        {
            Title = title;
            this.On = On;
        }
        public override string Name()
        {
            return Title;
        }

        public override void Run()
        {
            /// Алгоритм
            /// На основании данных таблицы КПК DisTriggers Включать/Выключать (зависит от On)
            /// тригерра (учитвать порядок - ord)
            ///  -   не забыть лог
            ///  -   не забыть Running  

            if(Running)
            {
                string tr = "select * from DisTriggers order by ord";
                string tri="Alter trigger {0} ";
                if(On)
                     tri+= "Enable";
                else tri += "Disable";
                QuerySelectPDA q=new QuerySelectPDA();
                QueryExecOracle qu = new QueryExecOracle();
                if(!q.Select(tr))
                {
                    Loging.Loging.WriteLog("Error: " + tr, true, true);
                }
                else
                {
                    Loging.Loging.WriteLog("OK: " + tr, false, false);
                }
                List<DataRows> dr;
                dr = q.GetRows();
                foreach (DataRows rows in dr)
                {
                    string TrName = rows.FieldByName("triggerName");
                   
                        if(!qu.Execute(String.Format(tri,TrName)))
                            Loging.Loging.WriteLog("Error: " + String.Format(tri, TrName), true, true);
                        else  
                                Loging.Loging.WriteLog("OK: " + String.Format(tri, TrName), false, false);
                    
                }
            }

        }
    }
}
