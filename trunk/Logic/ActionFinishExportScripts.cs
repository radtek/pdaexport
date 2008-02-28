namespace Logic
{
    /// <summary>
    /// Заверешение переноса в БД на КПК. Установка системных заначений
    /// </summary>
    public class ActionFinishExportScripts:AbstractAction
    {
        public override string Name()
        {
            return "Завершения формирования базы КПК";
        }

        public override void Run()
        {
            /// алгоритм
            /// просто устанавливает в MainParams
            ///     -   expDate = текущая дата и время
            ///     -   expState = done если нет в логе ошибок (Logging.WasError)
            /// event в самом конце (Max = 1 Pos = 1)
            /// Running не обрабатываеться
   
        }
    }
}
