using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Logic
{
    /// <summary>
    ///  Отображает диалог dlgSessions. Если в диалоге нажали отмену 
    ///  то дальше процесс не идет (срабоатывает отмена для всего поцесса)
    /// </summary>
    public class ActionViewSessions:AbstractAction
    {
        public ActionViewSessions(Form sessions)
        {
            throw new NotImplementedException();
        }

        public override string Name()
        {
            return "Список подключениний к базе (сессий)";
        }

        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
}
