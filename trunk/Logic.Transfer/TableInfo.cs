using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Transfer
{
    public class TableInfo
    {
        /// <summary>
        /// Тип выбираемых записей - от этого зависит фильтр и порядок
        /// </summary>
        public enum WayType
        {
            LightImport, AllImport, Export
        }
        /// <summary>
        /// Тип запроса - для индекса ассоциативного списка
        /// </summary>
        public enum QryType
        {
            SelectBM, SelectPDA, Delete, Clear, Insert
        }
        public int idTransferTable;
        public string tableName;
        // только для полного маппинга - а вдруг понадобяться:)
        public bool isLight;
        public int needExport;
        public Dictionary<QryType, string> sqlText;
        public List<FieldInfo> fields;
        /// <summary>
        /// Функция считавает таблицы на основании типа.
        /// При LightImport - isLight == true, order by orderBM
        /// При Import - order by orderBM
        /// При Export - needExport == true, order by orderPDA
        /// </summary>
        /// <param name="wayType">тип выбора таблиц</param>
        /// <returns>список выбранных таблиц с заполненными полями</returns>
        public static List<TableInfo> LoadTables(WayType wayType)
        {
            throw new NotImplementedException();
        }

    }
}
