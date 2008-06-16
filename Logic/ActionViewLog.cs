using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Logic
{
    public class ActionViewLog:ActionViewSessions
    {
        public ActionViewLog(Form dlgLog):base(dlgLog)
        {
            
        }

        public override string Name()
        {
            return "Просмотр изменений";
        }

    }
}
