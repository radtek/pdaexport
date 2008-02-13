using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace DataBaseWork
{
    public class QuerySelectOracle:QuerySelect
    {
        public override bool Select(string SQL)
        {
            return true;
        }
    }
}
