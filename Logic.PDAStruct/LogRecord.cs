using System;
using System.Collections.Generic;

namespace Logic.PDAStruct
{
    public class LogRecord
    {
        public enum LogType
        {
            Insert,
            Update,
            Delete,
            BrDefUpdate,
            BrElmInser,
            BrElmDelete
        }
        // -- поля для мапинга в базу
        public LogType logType;
        public string sqlText;
        public int idBr;
        public string tableName;
        public string tableDescr;
        public string runDate;
        public List<LogRecordDetail> detailRecords = new List<LogRecordDetail>();
        // ---
        /// <summary>
        /// Получает данные из базу. 
        /// </summary>
        public void Load()
        {

        }


        /// <summary>
        /// Устанавливает runDate в текущую дату
        /// </summary>
        public void SetCurrRunDate()
        {
            runDate = DateTime.Now.ToString();
        }

    }
}