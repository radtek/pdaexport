namespace Logic
{
    /// <summary>
    /// ��������� ��� ��������� ����� ������.
    /// ������ ������������ ������. ������� ������� ��� ����� ������ Cancel()
    /// ����� ��������� �� ���� (������ ����� ������� ���������� ����)
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
