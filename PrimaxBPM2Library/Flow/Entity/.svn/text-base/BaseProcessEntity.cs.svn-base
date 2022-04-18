using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Primax.Core.Data.Attributes;
using Primax.Core.Data;

namespace PrimaxBPM2Library.Flow.Entity
{
    /// <summary>
    /// Base Process Entity
    /// </summary>
    public class BaseProcessEntity
    {
        public const string Query = "Query";
        public const string Insert = "Insert";
        public const string Update = "Update";

        //所涉及之資料表
        public const string Table = "WF_BASE_PROCESS";

        [DataContextMap(MapKey = Query, SQLContextType = EnumSQLContext.SQLString)]
        [DataContextMap(MapKey = Insert, PKNameOrTableName =Table, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Insert)]
        [DataContextMap(MapKey = Update, PKNameOrTableName = Table, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Update, WhereSQL = " where WF_BASE_PROCESS_CODE='{0}'", Parameters = new object[] { "Code" })]
        public BaseProcessEntity()
        {
            this.CreateUser = "System";
            this.CreatedDate = DateTime.Now;
            this.ModifyUser = "System";
            this.ModifyDate = DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataContextColumn(MapKey = Query, ColumnName = "WF_BASE_PROCESS_ID")]
        public int ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "Code")]
        [DataContextColumn(MapKey = Query, ColumnName = "WF_BASE_PROCESS_CODE")]
        [DataContextColumn(MapKey = Insert, ColumnName = "WF_BASE_PROCESS_CODE")]
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "Name")]
        [DataContextColumn(MapKey = Query, ColumnName = "WF_BASE_PROCESS_NAME")]
        [DataContextColumn(MapKey = Insert, ColumnName = "WF_BASE_PROCESS_NAME")]
        [DataContextColumn(MapKey = Update, ColumnName = "WF_BASE_PROCESS_NAME")]
        public string Name { get; set; }

        /// <summary>
        /// DESCRIPTION
        /// </summary>
        [XmlElement(ElementName = "Description")]
        [DataContextColumn(MapKey = Query, ColumnName = "DESCRIPTION")]
        [DataContextColumn(MapKey = Insert, ColumnName = "DESCRIPTION")]
        [DataContextColumn(MapKey = Update, ColumnName = "DESCRIPTION")]
        public string Description { get; set; }

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
