using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Logic
{
    /// <summary>
    ///  Отображает диалог dlgSessions. Если в диалоге нажали отмену 
    ///  то дальше процесс не идет (срабатывает отмена для всего процесса)
    /// </summary>
    public class ActionViewSessions:AbstractAction
    {
        Form f;
        public ActionViewSessions(Form sessions)
        {
            f = sessions;
        }

        public override string Name()
        {
            return "Список подключениний к базе (сессий)";
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
