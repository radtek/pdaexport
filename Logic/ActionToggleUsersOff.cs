using System;
using System.Collections.Generic;
using System.Text;
using DataBaseWork;

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
            /// Формируем для каждого изменения соответствующую  отмену
            // заполняем
            if (Running)
            {
                string predsost = "select idGU, offGU, offText from UserBM";
                QuerySelectOracle q = new QuerySelectOracle();
                QueryExecOracle qe = new QueryExecOracle();
                q.Select(predsost);
                List<DataRows> lst = q.GetRows();
                foreach (DataRows rows in lst)
                {
                    UserInfo userInfo = new UserInfo();
                    userInfo.idGU = int.Parse(rows.FieldByName("idGU"));
                    userInfo.offGU = int.Parse(rows.FieldByName("offGu"));
                    userInfo.offText = rows.FieldByName("offText");
                    FinallyStack.Add(RestoreUser, userInfo);
                }
                string running = "update UserBM set offGU=1, offText='Идет импорт'";
                qe.Execute(running);
                // Удалять все сеансы кроме SYSTEM
                string showsessions = "SELECT s.sid,s.serial#,s.osuser,s.program FROM v$session s";
                q.Select(showsessions);
                lst = q.GetRows();
                foreach (DataRows rows in lst)
                {
                    if(rows.FieldByName("osuser")!="SYSTEM")
                    {
                        string kill = "ALTER SYSTEM KILL SESSION '"+rows.FieldByName("sid")+","+rows.FieldByName("serial#")+"' IMMEDIATE";
                        qe.Execute(kill);
                    }
                }
                //Реконнект
                DataBaseOracle.Disconnect();
                DataBaseOracle.Get();
            }
        }

        private static void RestoreUser(object InData)
        {
            UserInfo userInfo = (UserInfo) InData;
            // Восстанавливаем данные
            QueryExecOracle q=new QueryExecOracle();
            string restore = "update UserBM set offGU="+userInfo.offGU+", offText='"+userInfo.offText+"' where idGU="+userInfo.idGU;
            q.Execute(restore);
        }
    }
}
