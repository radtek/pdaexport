using System;
using System.Collections.Generic;
using System.Text;
using DataBaseWork;

namespace Logic.Transfer
{
    public class FieldInfo
    {
        public string fieldName;
        public  static QuerySelectPDA query=new QuerySelectPDA();
        public static string sql = "select fieldname from TransferFields where idTransferTable={0}";
        /// <summary>
        /// ����������� ������ ����� ��� ������� ( �� �������������� �������)
        /// </summary>
        /// <param name="idTransferTable">������������� �������</param>
        /// <returns>������ �����</returns>
        public static List<FieldInfo> LoadFields(int idTransferTable)
        {
            List<FieldInfo> lf=new List<FieldInfo>();
            query.Select(String.Format(sql, idTransferTable));
            List<DataRows> rows = query.GetRows();
            FieldInfo fi;
            foreach (DataRows row in rows)
            {
                fi = new FieldInfo();
                fi.fieldName = row.FieldByName("fieldname");
                lf.Add(fi);
            }
            return lf;
        }
    }
}
