using System;
using System.Collections.Generic;
using DataBaseWork;

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
        public List<LogRecordDetail> detailRecords;// = new List<LogRecordDetail>();
        // ---
        /// <summary>
        /// Получает данные из базу. 
        /// </summary>
        public List<LogRecord> Load()
        {
            List<LogRecord> list=new List<LogRecord>();
            QuerySelectPDA q = new QuerySelectPDA();
            q.Select("select * from Brlog");
            List<DataRows> rows = q.GetRows();
            foreach (DataRows row in rows)
            {
                LogRecord lr=new LogRecord();
                lr.idBr = Int32.Parse(row.FieldByName("idbr"));
                lr.sqlText = row.FieldByName("sqltext");
                lr.runDate = row.FieldByName("rundate");
                lr.logType = (LogType)Enum.Parse(typeof(LogType),row.FieldByName("logtype"));
                lr.tableName = row.FieldByName("tablename");
                lr.tableDescr = row.FieldByName("tableDescr");
                string idlog = row.FieldByName("idlog");
                lr.detailRecords = LogRecordDetail.Load(idlog);
                list.Add(lr);
            }
            return list;
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