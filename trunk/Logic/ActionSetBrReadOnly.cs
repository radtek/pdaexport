using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Устанавливает мосты в реижим "для чтения"
    /// </summary>
    public class ActionSetBrReadOnly:AbstractAction
    {
        public ActionSetBrReadOnly(List<int> IDBR)
        {
            
        }
        public override string Name()
        {
            return "Запись в базу Oracle даных о переносе";
        }

        public override void Run()
        {
            
        }
        public override void Cancel()
        {
            // нельзя отменить - должно дойти до конца
        }
    }
}
