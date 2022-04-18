using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Primax.Core.Data.Attributes;
using Primax.Core.Data;

namespace PrimaxBPM2Library.Flow.Entity
{
    public class ActivityEntity
    {
        public const string Query = "Query";
        public const string Insert = "Insert";
        public const string Update = "Update";

        //所涉及之資料表
        public const string Table = "WF_ACTIVITY";

        [DataContextMap(MapKey = Query, SQLContextType = EnumSQLContext.SQLString)]
        [DataContextMap(MapKey = Insert, PKNameOrTableName = Table, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Insert)]
        [DataContextMap(MapKey = Update, PKNameOrTableName = Table, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Update, WhereSQL = " where WF_PROCESS_ID='{0}' and WF_ACTIVITY_CODE='{1}'", Parameters = new object[] { "AgilePointBaseDefintionID", "Code" })]
        public ActivityEntity()
        {
            this.CreateUser = "System";
            this.CreatedDate = DateTime.Now;
            this.ModifyUser = "System";
            this.ModifyDate = DateTime.Now;
        }

        
        [XmlElement(ElementName = "CommandProperty")]
        public List<ActivityCommandEntity> CommandList { get; set; }

        [DataContextColumn(MapKey = Query, ColumnName = "WF_ACTIVITY_ID")]
        public int ID { get; set; }

        [DataContextColumn(MapKey = Query, ColumnName = "WF_PROCESS_ID")]
        [DataContextColumn(MapKey = Insert, ColumnName = "WF_PROCESS_ID")]
        public string AgilePointBaseDefintionID { get; set; }

        [DataContextColumn(MapKey = Query, ColumnName = "WF_ACTIVITY_CODE")]
        [DataContextColumn(MapKey = Insert, ColumnName = "WF_ACTIVITY_CODE")]
        [XmlElement(ElementName = "Code")]
        public string Code { get; set; }

        [DataContextColumn(MapKey = Query, ColumnName = "WF_ACTIVITY_NAME")]
        [DataContextColumn(MapKey = Insert, ColumnName = "WF_ACTIVITY_NAME")]
        [DataContextColumn(MapKey = Update, ColumnName = "WF_ACTIVITY_NAME")]
        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "Type")]
        [DataContextColumn(MapKey = Query, ColumnName = "ACTIVITY_TYPE")]
        [DataContextColumn(MapKey = Insert, ColumnName = "ACTIVITY_TYPE")]
        [DataContextColumn(MapKey = Update, ColumnName = "ACTIVITY_TYPE")]
        public string ActivityType { get; set; }

        [XmlElement(ElementName = "Parameters")]
        [DataContextColumn(MapKey = Query, ColumnName = "PARAMETERS")]
        [DataContextColumn(MapKey = Insert, ColumnName = "PARAMETERS")]
        [DataContextColumn(MapKey = Update, ColumnName = "PARAMETERS")]
        public string Parameters { get; set; }

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
