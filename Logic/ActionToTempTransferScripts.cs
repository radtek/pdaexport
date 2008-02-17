using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Перенос данных по выбранным мостам ( плюс классификаторы) 
    /// из клиентской схемы в схему импорта (Oracle -> Oracle).
    /// </summary>
    public class ActionToTempTransferScripts:AbstractAction
    {
        public ActionToTempTransferScripts(List<int> IDBR)
        {
            
        }
        public override string Name()
        {
            return "Подготока мостов для переноса";
        }

        public override void Run()
        {
            
        }
    }
}
