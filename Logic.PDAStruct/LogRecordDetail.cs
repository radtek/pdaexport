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
        public void Load(string id)
        { 

        }

    }
}