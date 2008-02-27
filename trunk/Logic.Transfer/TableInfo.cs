using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Transfer
{
    public class TableInfo
    {
        /// <summary>
        /// ��� ���������� ������� - �� ����� ������� ������ � �������
        /// </summary>
        public enum WayType
        {
            LightImport, AllImport, Export
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
        public bool isLight;
        public int needExport;
        public Dictionary<QryType, string> sqlText;
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
            throw new NotImplementedException();
        }

    }
}
