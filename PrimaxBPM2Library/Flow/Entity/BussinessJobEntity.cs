using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Primax.Core.Data.Attributes;
using Primax.Core.Data;

namespace PrimaxBPM2Library.Flow.Entity
{
    public class BussinessJobEntity
    {
        public const string Query = "Query";
        public const string Insert = "Insert";
        public const string Update = "Update";

        //所涉及之資料表
        public const string Table = "BUSINESS_JOB";

        [DataContextMap(MapKey = Query, SQLContextType = EnumSQLContext.SQLString)]
        [DataContextMap(MapKey = Insert, PKNameOrTableName = Table, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Insert)]
        [DataContextMap(MapKey = Update, PKNameOrTableName = Table, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Update, WhereSQL = " where BUSINESS_JOB_ID={0} ", Parameters = new object[] { "ID" })]
        public BussinessJobEntity()
        {
            this.ModuleID = 1;
            this.IsCanBeDelegate = true;
        }

        
        [DataContextColumn(MapKey = Insert, ColumnName = "BUSINESS_JOB_ID")]
        [DataContextColumn(MapKey = Query, ColumnName = "BUSINESS_JOB_ID")]
        public int ID { get; set; }

        
        [DataContextColumn(MapKey = Insert, ColumnName = "BUSINESS_MODULE_ID")]
        [DataContextColumn(MapKey = Update, ColumnName = "BUSINESS_MODULE_ID")]
        [DataContextColumn(MapKey = Query, ColumnName = "BUSINESS_MODULE_ID")]
        public int ModuleID { get; set; }

        [DataContextColumn(MapKey = Insert, ColumnName = "ORGANIZATION_ID")]
        [DataContextColumn(MapKey = Update, ColumnName = "ORGANIZATION_ID")]
        [DataContextColumn(MapKey = Query, ColumnName = "ORGANIZATION_ID")]
        public string OrgID { get; set; }

        [DataContextColumn(MapKey = Insert, ColumnName = "BUSINESS_JOB_CODE")]
        [DataContextColumn(MapKey = Update, ColumnName = "BUSINESS_JOB_CODE")]
        [DataContextColumn(MapKey = Query, ColumnName = "BUSINESS_JOB_CODE")]
        public string ProcessID { get; set; }


        [DataContextColumn(MapKey = Insert, ColumnName = "BUSINESS_JOB_NAME")]
        [DataContextColumn(MapKey = Update, ColumnName = "BUSINESS_JOB_NAME")]
        [DataContextColumn(MapKey = Query, ColumnName = "BUSINESS_JOB_NAME")]
        public string ProcessName { get; set; }

        [XmlElement("CanBeDelegate")]
        [DataContextColumn(MapKey = Insert, ColumnName = "CAN_BE_DELEGATED")]
        [DataContextColumn(MapKey = Update, ColumnName = "CAN_BE_DELEGATED")]
        [DataContextColumn(MapKey = Query, ColumnName = "CAN_BE_DELEGATED")]
        public bool IsCanBeDelegate { get; set; }
        
        
    }
}
