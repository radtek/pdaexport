using System;

namespace DataBaseWork
{
    public abstract class QueryExec
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
        public static QueryExec Create(BaseType baseType)
        {
            switch (baseType)
            {
                case BaseType.PDA:
                    return new QueryExecPDA();
                case BaseType.Oracle:
                    return new QueryExecOracle();
            }
            throw new ArgumentException("Base not implemented");
        } 
        public abstract bool Execute(string SQL);
    }
}