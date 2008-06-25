using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Logic
{
    public class ActionViewLog:ActionViewSessions
    {
        private readonly Form f;
        public ActionViewLog(Form dlgLog):base(dlgLog)
        {
            f = dlgLog;
        }

        public override string Name()
        {
            return "Просмотр изменений";
        }
        public override void Run()
        {
            if (f.ShowDialog() != DialogResult.OK)
            {
                Coordinator.Canceled = true;
            }
        }

    }
}
