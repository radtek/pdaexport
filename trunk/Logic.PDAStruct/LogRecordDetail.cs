using System.Collections.Generic;
using DataBaseWork;

namespace Logic.PDAStruct
{
    public class LogRecordDetail
    {
        // -- поля для мапинга
        public string fieldName;
        public string fieldDescr;
        public string valueOld;
        public string valueNew;
        // --
        /// <summary>
        /// Сохраняет запись в таблицу BrLogDet
        /// </summary>
        /// <param name="id">Идентификатор FK на BrLog</param>
        public static List<LogRecordDetail> Load(string id)
        { 
            QuerySelectPDA q=new QuerySelectPDA();
            List<LogRecordDetail> list=new List<LogRecordDetail>();
            q.Select("select * from LogRecordDetail where idlog=" + id);
            List<DataRows> rows = q.GetRows();
            foreach (DataRows row in rows)
            {
                LogRecordDetail lrd=new LogRecordDetail();
                lrd.fieldName = row.FieldByName("fieldName");
                lrd.fieldDescr = row.FieldByName("fieldDescr");
                lrd.valueOld = row.FieldByName("valueOld");
                lrd.valueNew = row.FieldByName("valueNew");
                list.Add(lrd);
            }
            return list;
        }

    }
}