using System;
using System.Collections.Generic;
using System.Text;
using DataBaseWork;

namespace Logic.Transfer
{
    public class TableInfo
    {
        public static QuerySelectPDA query=new QuerySelectPDA();
        /// <summary>
        /// ��� ���������� ������� - �� ����� ������� ������ � �������
        /// </summary>
        public enum WayType
        {
            LightImport, AllImport, Export, ExportClear
        }
        /// <summary>
        /// ��� ������� - ��� ������� �������������� ������
        /// </summary>
        public enum QryType
        {
            SelectBM, SelectPDA, Delete, Clear, Insert
        }
        public int idTransferTable;
        public string tableName;
        // ������ ��� ������� �������� - � ����� ������������:)
        public string isLight;
        public string needExport;
        public Dictionary<QryType, string> sqlText=new Dictionary<QryType, string>();
        public List<FieldInfo> fields;
        /// <summary>
        /// ������� ��������� ������� �� ��������� ����.
        /// ��� LightImport - isLight == true, order by orderBM
        /// ��� Import - order by orderBM
        /// ��� Export - needExport == true, order by orderPDA
        /// </summary>
        /// <param name="wayType">��� ������ ������</param>
        /// <returns>������ ��������� ������ � ������������ ������</returns>
        public static List<TableInfo> LoadTables(WayType wayType)
        {
            List<TableInfo> lt=new List<TableInfo>();
            string sql = "select * from  Transfer2PDA order by {0}";
            switch(wayType)
            {
                case WayType.AllImport:
                case WayType.LightImport:
                    query.Select(string.Format(sql, "OrderBM"));
                    break;
                case WayType.Export:
                    query.Select(string.Format(sql, "OrderPDA"));
                    break;
                case WayType.ExportClear:
                    query.Select(string.Format(sql, "OrderPDA desc"));
                    break;

            }
            if(wayType==WayType.Export) query.Select(string.Format(sql,"OrderBM"));
            else query.Select(string.Format(sql, "OrderBM"));
            List<DataRows> rows = query.GetRows();
            TableInfo ti;
            foreach (DataRows row in rows)
            { 
                ti=new TableInfo();
                ti.idTransferTable = Convert.ToInt32(row.FieldByName("idTransferTable"));
                ti.tableName = row.FieldByName("tableName");
                ti.isLight = row.FieldByName("isLight");
                if(wayType==WayType.LightImport && ti.isLight=="0") continue;
                ti.needExport = row.FieldByName("needExport");
                if (wayType == WayType.Export && ti.needExport == "0") continue;
                string idSelectBM=row.FieldByName("idQrySelectBM");
                string idsql = "select text from QrySelect where idQrySelect={0}";
                query.Select(string.Format(idsql, idSelectBM));
                List<DataRows> idrows = query.GetRows();
                ti.sqlText[QryType.SelectBM] = idrows[0].FieldByName("text");

                string idSelectPDA = row.FieldByName("idQrySelectPDA");
                idsql = "select text from QrySelect where idQrySelect={0}";
                query.Select(string.Format(idsql, idSelectPDA));
                idrows = query.GetRows();
                ti.sqlText[QryType.SelectPDA] = idrows[0].FieldByName("text");

                string idDelete = row.FieldByName("idQryDelete");
                idsql = "select text from QryDelete where idQryDelete={0}";
                query.Select(string.Format(idsql, idDelete));
                idrows = query.GetRows();
                ti.sqlText[QryType.Delete] = idrows[0].FieldByName("text");

                string idClear = row.FieldByName("idQryClear");
                idsql = "select text from QryClear where idQryClear={0}";
                query.Select(string.Format(idsql, idClear));
                idrows = query.GetRows();
                ti.sqlText[QryType.Clear] = idrows[0].FieldByName("text");

                string idInsert = row.FieldByName("idQryInsert");
                idsql = "select text from QryInsert where idQryInsert={0}";
                query.Select(string.Format(idsql, idInsert));
                idrows = query.GetRows();
                ti.sqlText[QryType.Insert] = idrows[0].FieldByName("text");

                ti.fields = FieldInfo.LoadFields(ti.idTransferTable);
                lt.Add(ti);
                
            }
            return lt;
        }

    }
}
