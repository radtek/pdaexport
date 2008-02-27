using System;
using System.Collections.Generic;
using System.Text;
using DataBaseWork;

namespace Logic.Transfer
{
    /// <summary>
    /// �������� ��� ������ � �������� ����������� (� �������� MainParams)
    /// </summary>
    public class MainParams
    {
        public enum ParamName
        {
            idGu, expDate, impDate, impState, expState, isLight   
        }
        public static string GetParam(ParamName paramName)
        {
            QuerySelectPDA q=new QuerySelectPDA();
            string sql = "select {0} from MainParams";
            string name="*";
            switch(paramName)
            {
                case ParamName.idGu: name="idGU";
                    break;
                case ParamName.expDate:name="expDate";
                    break;
                case ParamName.impDate: name="impDate";
                    break;
                case ParamName.impState: name="impState";
                    break;
                case ParamName.expState: name="expState";
                    break;
                case ParamName.isLight: name="isLight";
                    break;
            }
            q.Select(string.Format(sql, name));
            List<DataRows> rows = q.GetRows();
            return rows[0].FieldByName(name);
        }
        public static void SetParam(ParamName paramName)
        {
            QueryExecPDA q = new QueryExecPDA();
            string sql = "update MainParams set {0}=null";
            string name = "*";
            switch (paramName)
            {
                case ParamName.idGu: name = "idGU";
                    break;
                case ParamName.expDate: name = "expDate";
                    break;
                case ParamName.impDate: name = "impDate";
                    break;
                case ParamName.impState: name = "impState";
                    break;
                case ParamName.expState: name = "expState";
                    break;
                case ParamName.isLight: name = "isLight";
                    break;
            }
            q.Execute(string.Format(sql, name));
        }
    }
}
