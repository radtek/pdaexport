namespace Logic
{
    public class ActionDeploy:AbstractAction
    {
        /// <summary>
        ///  Копирование базы на КПК
        /// </summary>
        /// <returns></returns>
        public override string Name()
        {
            return "Установка базы на КПК";
        }

        public override void Run()
        {
            /// алгоритм
            /// Disconnect от КПК базы
            /// на основании ConnectionSettings скопировать 
            /// базу с винчейстера на КПК
            /// event в самом конце (Max = 1 Pos = 1)
            /// Running не обрабатываеться    
        }
    }
}
