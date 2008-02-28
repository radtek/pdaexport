namespace Logic
{
    /// <summary>
    /// Непосредственно перенос данных из БД Oracle в БД MSSQL Mobile
    /// (Oracle -> MSSQL Mobile)
    /// </summary>
    public class ActionOracleToPDATransfer:AbstractAction
    {
        public override string Name()
        {
            return "Перенос данных на КПК";
        }

        public override void Run()
        {
            /// алгоритм
            /// 1. Получить список таблиц (как в предыдущих)
            /// 2. для каждой таблицы считать данные из EXPORT
            ///      Oracle: select * from BMEXPORT.[tablename]
            /// 3. создать шаблон инсерта для таблицы на основании списка полей
            ///     insert into [tablename]([поле1], [поле2], .... , ) values ('{0}', '{1}' ... )
            /// 4. перебирая данные выбранные на этапе 2 последовательно формировать 
            ///     для каждой строки sql запрос на основании списка таблиц и шаблона
            ///     и выполнять его в базе КПК.
            ///     -   прогресс бар вести по таблицам.
            ///     -   не забыть лог
            ///     -   не забыть Running    
        }
    }
}
