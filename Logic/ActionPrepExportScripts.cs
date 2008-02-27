namespace Logic
{
    /// <summary>
    /// ѕодготавливает временную схему дл прин€ти€ мостов - очищает таблицы
    /// </summary>
    public class ActionPrepExportScripts:AbstractAction
    {
        public override string Name()
        {
            return "ѕодготовка базы дл€ переноса";
        }

        public override void Run()
        {
            /// алгоритм
            /// ѕолучам из таблицы MainParams данные о isLight
            /// на основании этого получает список таблиц дл€ работы.
            /// перебирает таблицы и выполн€ет запрос 
            /// delete from BMEXPORT.[tableName] - ¬ Oracle
            /// delete from [tableName] - PDA 
            /// при все этом учитаваем вызовы обратной св€зи 
            ///  - OnExecute после кахдой таблицы
            ///  - передавать в args кол-во таблиц и номер текущей (дл€ прогресс бара)
            ///  - провер€ть Running перед каждой итерацией и если false прекращать работу
        }
    }
}
