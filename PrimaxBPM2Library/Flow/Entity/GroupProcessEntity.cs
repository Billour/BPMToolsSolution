using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Primax.Core.Data.Attributes;
using Primax.Core.Data;

namespace PrimaxBPM2Library.Flow.Entity
{
    public class GroupProcessEntity
    {
        public const string Query = "Query";
        public const string Insert = "Insert";
        public const string Update = "Update";

        public const string Table = "WF_ORGANIZATION_PROCESS";

        [DataContextMap(MapKey = Query, SQLContextType = EnumSQLContext.SQLString)]
        [DataContextMap(MapKey = Insert, PKNameOrTableName = Table, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Insert)]
        [DataContextMap(MapKey = Update, PKNameOrTableName = Table, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Update, WhereSQL = " where ORGANIZATION_ID='{0}' and WF_PROCESS_ID='{1}'", Parameters = new object[] { "OrgnizationID", "AgilePointBaseDefintionID"})]
        public GroupProcessEntity()
        { 
            
        }

        /// <summary>
        /// ID
        /// </summary>
        [XmlElement("ID")]
        [DataContextColumn(MapKey = Query, ColumnName = "WF_ORGANIZATION_PROCESS_ID")]
        [DataContextColumn(MapKey = Insert, ColumnName = "WF_ORGANIZATION_PROCESS_ID")]
        [DataContextColumn(MapKey = Update, ColumnName = "WF_ORGANIZATION_PROCESS_ID")]
        public int ID { get; set; }

        /// <summary>
        /// 組織ID
        /// </summary>
        [XmlElement("Company")]
        [DataContextColumn(MapKey = Query, ColumnName = "ORGANIZATION_ID")]
        [DataContextColumn(MapKey = Insert, ColumnName = "ORGANIZATION_ID")]
        public string OrgnizationID { get; set; }

        
        /// <summary>
        /// Agile Point WF ID
        /// </summary>
        [DataContextColumn(MapKey = Query, ColumnName = "WF_PROCESS_ID")]
        [DataContextColumn(MapKey = Insert, ColumnName = "WF_PROCESS_ID")]
        public string AgilePointBaseDefintionID { get; set; }
    }
}
