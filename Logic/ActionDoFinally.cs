using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DataBaseWork;

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
           DataBasePDA.Disconnect();
           File.Delete(ConnectionSettings.GetSettings().PDAConnectionString);
           FinallyStack.Run();
        }
    }
}
