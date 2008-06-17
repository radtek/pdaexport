using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Устанавливает мосты в реижим "для чтения"
    /// </summary>
    public class ActionSetBrReadOnly:AbstractAction
    {
        bool ReadOnly = true;
        public ActionSetBrReadOnly(List<int> IDBR, bool ReadOnly)
        {
            this.ReadOnly = ReadOnly;    
        }
        public ActionSetBrReadOnly(List<int> IDBR)
        {

        }
        public override string Name()
        {
            return "Запись в базу Oracle данных о переносе";
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
