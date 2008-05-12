using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    /// <summary>
    /// Класс изменяте состояние пользователей в таблице на выключенных и уничтожает все соединения с базой.
    /// Предыдущее состояние сохраняеться через интерфейс класса FinallyStack
    /// </summary>
    public class ActionToggleUsersOff:AbstractAction
    {
        public override string Name()
        {
            return "Выключение пользователей";
        }
        /// <summary>
        /// Класс который хранит инфу по пользователям
        /// </summary>
        class UserInfo
        {
            public int idGU;
            public int offGU;
            public string offText;
        }
        public override void Run()
        {
            /// это пример использования
            /// Считали данные из таблицы
            /// Форомируем для каждого изменения соответствующую  отмену
            UserInfo userInfo = new UserInfo();
            // заполняем
            FinallyStack.Add(RestoreUser, userInfo); // пример
        }

        private static void RestoreUser(object InData)
        {
            UserInfo userInfo = (UserInfo) InData;
            // Восстонавливаем данные
        }
    }
}
