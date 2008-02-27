using System.Collections.Generic;
using Logic.Transfer;

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
            // алгоритм работы
            /// Получам из таблицы MainParams данные о isLight
            /// на основании этого получает список таблиц для работы.
            /// перебирает таблицы и формирует запрос Select 
            /// проверяет есть ли в запросе строка '{0}' 
            ///     - это значит что надо перебирать по мостам
            ///     - при переборе по мостам так же запрос являеться шаблоном
            ///         используй string.format([запрос], idBR);
            ///     - если строка отсутствует то перебирать внутри 
            ///         таблицы по мотсам не надо а просто взять запрос Select
            ///  сформированный запрос модернезируеться в 
            ///     insert into BMEXPORT.[tablename] [запрос] 
            /// при все этом учитаваем вызовы обратной связи 
            ///  - OnExecute после кахдой таблицы
            ///  - передавать в args кол-во таблиц и номер текущей (для прогресс бара)
            ///  - проверять Running перед каждой итерацией и если false прекращать работу
           
    
        }
    }
}
