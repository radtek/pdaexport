using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Transfer
{
    /// <summary>
    /// оболочка для работы с осноными параметрами (с таблицей MainParams)
    /// </summary>
    public class MainParams
    {
        public enum ParamName
        {
            idGu, expDate, impDate, impState, expState, isLight   
        }
        public static string GetParam(ParamName paramName)
        {
            throw new NotImplementedException();
        }
        public static void SetParam(ParamName paramName)
        {
            throw new NotImplementedException();
        }
    }
}
