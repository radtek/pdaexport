using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using DAO.Bridges;

namespace Logic
{
    public class ActionClearOracleBr:AbstractAction
    {
        private List<BridgeData> bridges = null;
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
            throw new NotImplementedException();
        }
    }
}
