using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Logic
{
    public class ActionViewLog:ActionViewSessions
    {
        private readonly Form f;
        //private readonly Control combo;
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
            foreach (Control o in f.Controls)
            {
                if (o.Name.ToUpper() == "PANEL3")
                {
                    Panel p = new Panel();
                    p = ((Panel) o);
                    foreach (Control control in p.Controls)
                    {
                        if(control.Name.ToUpper()=="COMBOBOX1")
                            ((ComboBox)control).SelectedIndex = 1;
                    }
                    
                }
            }
            if (f.ShowDialog() != DialogResult.OK)
            {
                Coordinator.Canceled = true;
            }
        }

    }
}
