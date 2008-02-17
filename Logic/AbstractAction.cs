namespace Logic
{
    /// <summary>
    /// Интерфейс для обработки части логики.
    /// Должен поддерживать отмену. Система считает что после вызова Cancel()
    /// далее обработка не идет (вполне можно хранить внутренний флаг)
    /// </summary>
    public abstract class AbstractAction
    {
        protected bool Running = true;
        public abstract string Name();
        public abstract void Run();
        public virtual void Cancel()
        {
            Running = false;
        }
        public event ExecuteDelegate OnExecute;
        public delegate void ExecuteDelegate(AbstractAction action, Coordinator.ExecuteDelegateArgs args);
    }
}
