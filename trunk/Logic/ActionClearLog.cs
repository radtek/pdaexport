using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Очитска таблиц лога BrLog и BrLogDet в PDA базе
    /// </summary>
    public class ActionClearLog:AbstractAction
    {
        public override string Name()
        {
            return "Очистка лога";
        }

        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
}
