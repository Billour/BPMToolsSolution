using System;
using System.Collections.Generic;
using System.Text;

namespace Primax.Core.DB
{
    public class TableDoc
    {
        private int _Seq=0;
        private string _name;
        
        private string _description;
        private string _fileName;
        private string _CreatedDate="";
        public List<TableColumnDoc> _tc = new List<TableColumnDoc>();

        public TableDoc()
        { }

        public int Seq
        {
            set{_Seq=value;}
            get{return _Seq;}
        }

        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        

        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }

        public string FileName
        {
            set { _fileName = value; }
            get { return _fileName; }
        }

        public string CreatedDate
        {
            set{_CreatedDate=value;}
            get{return _CreatedDate;}
        }

        public List<TableColumnDoc> TableColumns
        {
            set { _tc = value; }
            get { return _tc; }
        }


    }
}
