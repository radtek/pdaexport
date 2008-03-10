using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace Logic
{
    public class ActionPDAToOracleTransfer:AbstractAction
    {
        public override string Name()
        {
            return "Перенос даных";
        }
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
            throw new NotImplementedException();
        }
    }
}
