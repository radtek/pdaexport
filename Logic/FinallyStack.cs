using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    ///  Класс заведеющий хранением информации о восстановлении системы
    ///  Отвечает за полрядок и за то что процесс будет проыедн только 1 раз
    /// </summary>
    public class FinallyStack
    {
        public delegate void PostBackFunction(object InData);
        class StackData
        {
            public readonly PostBackFunction callback;
            public readonly object Data;
            public StackData(PostBackFunction callback, object param)
            {
                this.callback = callback;
                Data = param;
            }
        }
        private static readonly Stack<StackData> stackForRun = new Stack<StackData>();
        /// <summary>
        /// Adds the specified callback.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="param">The param.</param>
        public static void Add(PostBackFunction callback, object param)
        {
            stackForRun.Push(new StackData(callback, param));
        }
        /// <summary>
        /// Runs stack of calls
        /// </summary>
        public static void Run()
        {
            while(stackForRun.Count>0)
            {
                StackData s = stackForRun.Pop();
                s.callback(s.Data);
            }
        }
    }
}
