using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

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
               
           }
        }
    }
}
