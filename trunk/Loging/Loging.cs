using System;
using System.Collections.Generic;
using System.Text;

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
        public static Loging _instance = new Loging();
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

        }
        /// <summary>
        /// Закрывает процес ведения лога. После этого вызова добавлять 
        /// записи в лог нельзя кроме как если его перезапустить
        /// </summary>
        public void _EndLog()
        {

        }
        /// <summary>
        /// Добавляет запись в лог
        /// </summary>
        /// <param name="Message">Запись</param>
        /// <param name="IsError">if set to <c>true</c> [признак сообщения об ошибке].</param>
        /// <param name="IsReport">if set to <c>true</c> [признак того что запись должна включаться в отчет].</param>
        public void _WriteLog(string Message, bool IsError, bool IsReport)
        {

        }
        /// <summary>
        /// Возвращает ВСЕ записи лога
        /// </summary>
        /// <returns></returns>
        public string[] _GetLog()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Отображает ворму просмотра лога - в форме отображаються записи у которых isReport == true
        /// </summary>
        public void _ShowLog()
        {

        }
        /// <summary>
        /// Возвращает признак того была ли хоть одна запись с isError == true
        /// </summary>
        /// <returns></returns>
        public bool _WasError()
        {
            throw new NotImplementedException();
        }
    }
}
