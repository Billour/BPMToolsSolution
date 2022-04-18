using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;
using Primax.Core.Data.Attributes;
using Primax.Core.Data;

namespace PrimaxBPM2Library.Flow.Entity
{

    public class ActivityCommandEntity
    {
        public const string Query = "Query";
        public const string Insert = "Insert";
        public const string Update = "Update";

        //所涉及之資料表
        public const string Table = "WF_ACTIVITY_COMMAND";

        [DataContextMap(MapKey = Query, SQLContextType = EnumSQLContext.SQLString)]
        [DataContextMap(MapKey = Insert, PKNameOrTableName = Table, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Insert)]
        [DataContextMap(MapKey = Update, PKNameOrTableName = Table, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Update, WhereSQL = " where WF_ACTIVITY_ID={0} and WF_COMMAND_ID={1}", Parameters = new object[] { "ActivityID", "CommandID" })]
        public ActivityCommandEntity()
        {
            this.CreateUser = "System";
            this.CreatedDate = DateTime.Now;
            this.ModifyUser = "System";
            this.ModifyDate = DateTime.Now;
        }

        [DataContextColumn(MapKey = Query, ColumnName = "WF_ACTIVITY_COMMAND_ID")]
        public int ID { get; set; }

        [XmlElement(ElementName = "CommandID")]
        [DataContextColumn(MapKey = Query, ColumnName = "WF_COMMAND_ID")]
        [DataContextColumn(MapKey = Insert, ColumnName = "WF_COMMAND_ID")]
        public int CommandID { get; set; }

        [DataContextColumn(MapKey = Query, ColumnName = "WF_ACTIVITY_ID")]
        [DataContextColumn(MapKey = Insert, ColumnName = "WF_ACTIVITY_ID")]
        public int ActivityID { get; set; }

        [XmlElement(ElementName = "Text")]
        [DataContextColumn(MapKey = Query, ColumnName = "DISPLAY_TEXT")]
        [DataContextColumn(MapKey = Insert, ColumnName = "DISPLAY_TEXT")]
        [DataContextColumn(MapKey = Update, ColumnName = "DISPLAY_TEXT")]
        public string DisplayText { get; set; }

        /// <summary>
        /// CREATEDBY_USER
        /// </summary>
        [DataContextColumn(MapKey = Query, ColumnName = "CREATEDBY_USER")]
        [DataContextColumn(MapKey = Insert, ColumnName = "CREATEDBY_USER")]
        public string CreateUser { get; set; }

        /// <summary>
        /// CREATE_TIME
        /// </summary>
        [DataContextColumn(MapKey = Query, ColumnName = "CREATE_TIME")]
        [DataContextColumn(MapKey = Insert, ColumnName = "CREATE_TIME")]
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
