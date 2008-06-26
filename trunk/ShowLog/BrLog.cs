using System;
using System.Collections.Generic;
using System.Text;

namespace ShowLog
{
    public class BrLog
    {
        private string  _LogType;

        public string LogType
        {
            get { return _LogType; }
            set { _LogType = value; }
        }
        private string _TableName;

        public string TableName
        {
            get { return _TableName; }
            set { _TableName = value; }
        }
        private string _TableDescr;

        public string TableDescr
        {
            get { return _TableDescr; }
            set { _TableDescr = value; }
        }
        private string _RunDate;

        public string RunDate
        {
            get { return _RunDate; }
            set { _RunDate = value; }
        }
        private string _IdLog;

        public string IdLog
        {
            get { return _IdLog; }
            set { _IdLog = value; }
        }
	
        //public string LogType;
        //public string TableName;
        //public string TableDescr;
        //public string RunDate;
        //public string IdLog;
    }
}
