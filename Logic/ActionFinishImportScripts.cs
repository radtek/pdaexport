using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class ActionFinishImportScripts:AbstractAction
    {
        public override string Name()
        {
            return "Завершения переноса";
        }

        public override void Run()
        {
            /// алгоритм
            /// просто устанавливает в MainParams
            ///     -   impDate = текущая дата и время
            ///     -   impState = done если нет в логе ошибок (Logging.WasError)
            /// event в самом конце (Max = 1 Pos = 1)
            /// Running не обрабатываеться
            throw new NotImplementedException();
        }
    }
}
