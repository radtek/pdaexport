using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Transfer
{
    public class FieldInfo
    {
        public string fieldName;
        /// <summary>
        /// Ворзвращает список полей для таблицы ( по дентификатору таблицы)
        /// </summary>
        /// <param name="idTransferTable">идентификатор таблицы</param>
        /// <returns>список полей</returns>
        public static List<FieldInfo> LoadFields(int idTransferTable)
        {
            throw new NotImplementedException();   
        }
    }
}
