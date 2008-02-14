using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Loging
{
    /// <summary>
    /// Класс ведущий лог. В лог приходит сообщение и его тип. Класс должен приобразовать сообщение к виду 
    /// [дата - время] сообщение - для сообщение с isError == false
    /// [дата - время] Ошибка: сообщение - для сообщение с isError == true
    /// </summary>
    public class Loging
    {
        /// <summary>
        /// Определение инетерфейса для работы с логом
        /// </summary>
        public static void StartLog()
        {
            Init();
            _instance._StartLog();
        }
        
        public static void EndLog()
        {
            Init();
            _instance._EndLog();
        }
       
        public static void WriteLog(string Message, bool IsError, bool IsReport)
        {
            Init();
            _instance._WriteLog(Message, IsError, IsReport);
        }
        public static string[] GetLog()
        {
            Init();
            return _instance._GetLog();
        }
        public static void ShowLog()
        {
            Init();
            _instance._ShowLog();
        }
        public static bool WasError()
        {
            Init();
            return _instance._WasError();
        }
        /// <summary>
        /// далее реализационные методы
        /// </summary>
        public static Loging _instance = null;
        
        public bool loging = false;
        public Dictionary<string, bool[]> Log = new Dictionary<string, bool[]>();
        public bool WasErr = false;
        
        public static void Init()
        {
            if(_instance== null)
                _instance = new Loging();
        }
        /// <summary>
        /// Инициирует ведение лога - очищает если было 
        /// что уже записано и начинает лог с начала
        /// </summary>
        public void _StartLog()
        {
            ///
            /// 
            Log.Clear();
            loging = true;
            WasErr = false;
        }
        /// <summary>
        /// Закрывает процес ведения лога. После этого вызова добавлять 
        /// записи в лог нельзя кроме как если его перезапустить
        /// </summary>
        public void _EndLog()
        {
            loging = false;
        }
        /// <summary>
        /// Добавляет запись в лог
        /// </summary>
        /// <param name="Message">Запись</param>
        /// <param name="IsError">if set to <c>true</c> [признак сообщения об ошибке].</param>
        /// <param name="IsReport">if set to <c>true</c> [признак того что запись должна включаться в отчет].</param>
        public void _WriteLog(string Message, bool IsError, bool IsReport)
        {
            bool[] flag=new bool[]{IsError,IsReport};
            if(loging.Equals(true))
            {
               if(IsError.Equals(true))
               {
                   WasErr = true;
               }
                Log.Add(Message,flag);
            }

        }
        /// <summary>
        /// Возвращает ВСЕ записи лога
        /// </summary>
        /// <returns></returns>
        public string[] _GetLog()
        {
            string[] fields = new string[Log.Count];
            int i = 0;
            foreach (KeyValuePair<string, bool[]> pair in Log)
            {
                if(pair.Value[0].Equals(false))
                {
                    fields[i] = DateTime.Now+" : "+pair.Key;
                }
                else fields[i] = DateTime.Now + " Ошибка : " + pair.Key;
                i++;
            }
            return fields;
        }
        /// <summary>
        /// Отображает ворму просмотра лога - в форме отображаються записи у которых isReport == true
        /// </summary>
        public void _ShowLog()
        {
            LogView form=new LogView();
            ListBox lb = form.listBox1;
            Button btn =new Button();
            form.CancelButton = btn;
            btn.Anchor = AnchorStyles.Bottom|AnchorStyles.Right;
            btn.DialogResult = DialogResult.Cancel;
            foreach (KeyValuePair<string, bool[]> pair in Log)
            {
                if (pair.Value[1].Equals(true))
                {
                    if (pair.Value[0].Equals(false))
                    {
                        lb.Items.Add(DateTime.Now + " : " + pair.Key);
                        
                    }
                    else lb.Items.Add(DateTime.Now + " Ошибка : " + pair.Key);
                }
                
            }
            form.Controls.Add(btn);
            form.ShowDialog();
            
        }
               
        /// <summary>
        /// Возвращает признак того была ли хоть одна запись с isError == true
        /// </summary>
        /// <returns></returns>
        public bool _WasError()
        {
            return WasErr;
        }
    }
}
