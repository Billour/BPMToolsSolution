using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text;
using System.Xml.Serialization;
using Primax.Core.Data.Attributes;
using Primax.Core.Data;

namespace PrimaxBPM2Library.Flow.Entity
{
    public class BussinessPolicy
    {
         public const string Query = "Query";
        public const string Insert = "Insert";
        public const string Update = "Update";

        //所涉及之資料表
        public const string Table = "BUSINESS_POLICY";

        [DataContextMap(MapKey = Query, SQLContextType = EnumSQLContext.SQLString)]
        [DataContextMap(MapKey = Insert, PKNameOrTableName = Table, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Insert)]
        [DataContextMap(MapKey = Update, PKNameOrTableName = Table, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Update, WhereSQL = " where BUSINESS_POLICY_ID={0} ", Parameters = new object[] { "PolicyID" })]
        public BussinessPolicy()
        {
            this.CreateUser = "System";
            this.CreatedDate = DateTime.Now;
            this.ModifyUser = "System";
            this.ModifyDate = DateTime.Now;
        }

        [XmlElement("BUSINESS_POLICY_ID")]
        [DataContextColumn(MapKey = Insert, ColumnName = "BUSINESS_POLICY_ID")]
        [DataContextColumn(MapKey = Query, ColumnName = "BUSINESS_POLICY_ID")]
        public int PolicyID { get; set; }

        [XmlElement("BUSINESS_SYSTEM_ID")]
        [DataContextColumn(MapKey = Insert, ColumnName = "BUSINESS_SYSTEM_ID")]
        [DataContextColumn(MapKey = Update, ColumnName = "BUSINESS_SYSTEM_ID")]
        [DataContextColumn(MapKey = Query, ColumnName = "BUSINESS_SYSTEM_ID")]
        public int SystemID { get; set; }

        [XmlElement("ORGANIZATION_ID")]
        [DataContextColumn(MapKey = Insert, ColumnName = "ORGANIZATION_ID")]
        [DataContextColumn(MapKey = Update, ColumnName = "ORGANIZATION_ID")]
        [DataContextColumn(MapKey = Query, ColumnName = "ORGANIZATION_ID")]
        public string OrgID { get; set; }

        [XmlElement("BUSINESS_POLICY_NAME")]
        [DataContextColumn(MapKey = Insert, ColumnName = "BUSINESS_POLICY_NAME")]
        [DataContextColumn(MapKey = Update, ColumnName = "BUSINESS_POLICY_NAME")]
        [DataContextColumn(MapKey = Query, ColumnName = "BUSINESS_POLICY_NAME")]
        public string PolicyName { get; set; }

        [DataContextColumn(MapKey = Insert, ColumnName = "BRML")]
        [DataContextColumn(MapKey = Update, ColumnName = "BRML")]
        [DataContextColumn(MapKey = Query, ColumnName = "BRML")]
        public string BusinessRuleXml { get; set; }

        [XmlElement("DESCRIPTION")]
        [DataContextColumn(MapKey = Insert, ColumnName = "DESCRIPTION")]
        [DataContextColumn(MapKey = Update, ColumnName = "DESCRIPTION")]
        [DataContextColumn(MapKey = Query, ColumnName = "DESCRIPTION")]
        public string Description { get; set; }

        [XmlElement("MAJOR_VERSION")]
        [DataContextColumn(MapKey = Insert, ColumnName = "MAJOR_VERSION")]
        [DataContextColumn(MapKey = Update, ColumnName = "MAJOR_VERSION")]
        [DataContextColumn(MapKey = Query, ColumnName = "MAJOR_VERSION")]
        public int Major { get; set; }

        [XmlElement("MINOR_VERSION")]
        [DataContextColumn(MapKey = Insert, ColumnName = "MINOR_VERSION")]
        [DataContextColumn(MapKey = Update, ColumnName = "MINOR_VERSION")]
        [DataContextColumn(MapKey = Query, ColumnName = "MINOR_VERSION")]
        public int Minor { get; set; }
       

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
