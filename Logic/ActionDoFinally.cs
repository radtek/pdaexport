using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Выполняет данные из FinallyStack
    /// </summary>
    public class ActionDoFinally:AbstractAction
    {
        public override string Name()
        {
            return "Завершение работы";
        }

        public override void Run()
        {
            FinallyStack.Run();
        }
    }
}
