using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Primax.Core.Data.Attributes;
using Primax.Core.Data;

namespace PrimaxBPM2Library.Flow.Entity
{
    public class FormPageEntity
    {
        public const string Query = "Query";
        public const string Insert = "Insert";
        public const string Update = "Update";

        public const string Table = "WF_FORM";

        public const string Query2 = "Query2";
        public const string Insert2 = "Insert2";
        

        public const string Table2 = "WF_PROCESS_FORM";

        [DataContextMap(MapKey = Query, SQLContextType = EnumSQLContext.SQLString)]
        [DataContextMap(MapKey = Insert, PKNameOrTableName = Table, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Insert)]
        [DataContextMap(MapKey = Update, PKNameOrTableName = Table, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Update, WhereSQL = " where WF_FORM_ID={0}", Parameters = new object[] { "ID" })]

        [DataContextMap(MapKey = Query2, SQLContextType = EnumSQLContext.SQLString)]
        [DataContextMap(MapKey = Insert2, PKNameOrTableName = Table2, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Insert)]
        public FormPageEntity()
        {
            this.CreateUser = "System";
            this.CreatedDate = DateTime.Now;
            this.ModifyUser = "System";
            this.ModifyDate = DateTime.Now;
        }

        [XmlElement(ElementName = "ID")]
        [DataContextColumn(MapKey = Query, ColumnName = "WF_FORM_ID")]
        [DataContextColumn(MapKey = Insert, ColumnName = "WF_FORM_ID")]

        [DataContextColumn(MapKey = Query2, ColumnName = "WF_FORM_ID")]
        [DataContextColumn(MapKey = Insert2, ColumnName = "WF_FORM_ID")]
        public int ID { get; set; }

        [DataContextColumn(MapKey = Query2, ColumnName = "WF_PROCESS_ID")]
        [DataContextColumn(MapKey = Insert2, ColumnName = "WF_PROCESS_ID")]
        public string AgilePointBaseDefintionID { get; set; }

        [XmlElement(ElementName = "Name")]
        [DataContextColumn(MapKey = Query, ColumnName = "FORM_NAME")]
        [DataContextColumn(MapKey = Insert, ColumnName = "FORM_NAME")]
        [DataContextColumn(MapKey = Update, ColumnName = "FORM_NAME")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Title")]
        [DataContextColumn(MapKey = Query, ColumnName = "TITLE")]
        [DataContextColumn(MapKey = Insert, ColumnName = "TITLE")]
        [DataContextColumn(MapKey = Update, ColumnName = "TITLE")]
        public string Title { get; set; }

        [XmlElement(ElementName = "WebPath")]
        [DataContextColumn(MapKey = Query, ColumnName = "PATH")]
        [DataContextColumn(MapKey = Insert, ColumnName = "PATH")]
        [DataContextColumn(MapKey = Update, ColumnName = "PATH")]
        public string Path { get; set; }

        [XmlElement(ElementName = "IsInitialForm")]
        [DataContextColumn(MapKey = Query, ColumnName = "IS_START_FORM")]
        [DataContextColumn(MapKey = Insert, ColumnName = "IS_START_FORM")]
        [DataContextColumn(MapKey = Update, ColumnName = "IS_START_FORM")]
        public bool IsStartForm { get; set; }

        /// <summary>
        /// CREATEDBY_USER
        /// </summary>
        [DataContextColumn(MapKey = Query, ColumnName = "CREATEDBY_USER")]
        [DataContextColumn(MapKey = Insert, ColumnName = "CREATEDBY_USER")]
        [DataContextColumn(MapKey = Query2, ColumnName = "CREATEDBY_USER")]
        [DataContextColumn(MapKey = Insert2, ColumnName = "CREATEDBY_USER")]
        public string CreateUser { get; set; }

        /// <summary>
        /// CREATE_TIME
        /// </summary>
        [DataContextColumn(MapKey = Query, ColumnName = "CREATE_TIME")]
        [DataContextColumn(MapKey = Insert, ColumnName = "CREATE_TIME")]
        [DataContextColumn(MapKey = Query2, ColumnName = "CREATE_TIME")]
        [DataContextColumn(MapKey = Insert2, ColumnName = "CREATE_TIME")]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// MODIFIEDBY_USER
        /// </summary>
        [DataContextColumn(MapKey = Query, ColumnName = "MODIFIEDBY_USER")]
        [DataContextColumn(MapKey = Update, ColumnName = "MODIFIEDBY_USER")]
        public string ModifyUser { get; set; }

        /// <summary>
        /// MODIFY_TIME
        /// </summary>
        [DataContextColumn(MapKey = Query, ColumnName = "MODIFY_TIME")]
        [DataContextColumn(MapKey = Update, ColumnName = "MODIFY_TIME")]
        public DateTime ModifyDate { get; set; }

    }
}
