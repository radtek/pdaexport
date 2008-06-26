using System;
using System.Collections.Generic;
using System.Text;

namespace ShowLog
{
    public class BrLogDet
    {
        private string _FieldName;

        public string FieldName
        {
            get { return _FieldName; }
            set { _FieldName = value; }
        }
        private string _FieldDescr;

        public string FieldDescr
        {
            get { return _FieldDescr; }
            set { _FieldDescr = value; }
        }
        private string _ValueOld;

        public string ValueOld
        {
            get { return _ValueOld; }
            set { _ValueOld = value; }
        }
        private string _ValueNew;

        public string ValueNew
        {
            get { return _ValueNew; }
            set { _ValueNew = value; }
        }
	
        //public string FieldName;
        //public string FieldDescr;
        //public string ValueOld;
        //public string ValueNew;
    }
}
