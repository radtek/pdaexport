using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;

namespace DataBaseWork
{
    public abstract class QuerySelect
    {
        protected int pErrorCode = -1;
        /// <summary>
        /// Gets the error code.
        /// </summary>
        /// <value>The error code.</value>
        public int ErrorCode
        {
            get { return pErrorCode; }
        }

        protected string pErrorMsg = "No error";
        /// <summary>
        /// Gets the error Message.
        /// </summary>
        /// <value>The error Message.</value>
        public string ErrorMsg
        {
            get { return pErrorMsg; }
        }

        protected List<DataRows> Rows = null;
        public List<DataRows> GetRows()
        {
            return Rows;
        }

        public abstract bool Select(string SQL);
        public static QuerySelect Create(BaseType baseType)
        {
            switch(baseType)
            {
                case BaseType.PDA:
                    return new QuerySelectPDA();
                case BaseType.Oracle:
                    return new QuerySelectOracle();
            }
            throw new ArgumentException("Base not implemented");
        }
    }
}