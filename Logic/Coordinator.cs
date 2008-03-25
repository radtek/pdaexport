using System.Collections.Generic;
using System.Threading;

namespace Logic
{
    /// <summary>
    /// Координатор - класс который выполняет дейстия в определенном порядке
    /// и выдает в вызвавшую форму поэтапный отчет о выполненных работах
    /// </summary>
    public class Coordinator
    {
        public event ExecuteDelegate OnExecute;
        public event ExecutionActionFinishDelegate OnEndAction;
        public delegate void ExecuteDelegate(Coordinator coordinator, ExecuteDelegateArgs args);
        public delegate void ExecutionActionFinishDelegate(Coordinator coordinator, ExecutionActionFinishDelegateArgs args);

        public struct ExecutionActionFinishDelegateArgs
        {
            public bool Last;
        }
        public struct ExecuteDelegateArgs
        {
            public string Name;
            public int Pos;
            public int Maximum;
            public AbstractAction runningAction;
        }
        public readonly List<AbstractAction>  runningActions = new List<AbstractAction>();
        public bool Canceled = false;

        public void AddAction(AbstractAction newAction)
        {
            runningActions.Add(newAction);
            newAction.OnExecute += newAction_OnExecute;
        }

        private void newAction_OnExecute(AbstractAction action, ExecuteDelegateArgs args)
        {
            if(OnExecute!=null)
            {
                args.runningAction = action;
                OnExecute(this, args);
            }
        }

        public AbstractAction currAction = null;
        public void Run()
        {
            Canceled = false;
            int CurrN = 0;
            foreach (AbstractAction runningAction in runningActions)
            {
                if (!Canceled)
                {
                    CurrN++;
                    currAction = runningAction;
                    runningAction.Run();
                    //окончание
                    if (!Canceled)
                    {
                        // сообщение об окончании
                        if (OnEndAction != null)
                        {
                            ExecutionActionFinishDelegateArgs args = new ExecutionActionFinishDelegateArgs();
                            args.Last = CurrN >= runningActions.Count;
                            OnEndAction(this, args);
                        }
                    }
                 }
           }
           
        }

        public void Cancel()
        {
            Canceled = true;
            if(currAction!=null)
                currAction.Cancel();
        }

        public string[] GetActions()
        {
            string[] retStrings = new string[runningActions.Count];
            int i = 0;
            foreach (AbstractAction action in runningActions)
            {
                retStrings[i] = action.Name();
                i++;
            }
            return retStrings;
        }


    }
}
 
