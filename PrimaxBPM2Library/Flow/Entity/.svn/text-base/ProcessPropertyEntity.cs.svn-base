using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Primax.Core.Data.Attributes;
using Primax.Core.Data;

namespace PrimaxBPM2Library.Flow.Entity
{
    public class ProcessPropertyEntity
    {
        public const string Insert = "Insert";

        //所涉及之資料表
        public const string Table = "WF_PROCESS_PROPERTY";

        [DataContextMap(MapKey = Insert, PKNameOrTableName = Table, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Insert)]
        public ProcessPropertyEntity()
        {
            this.CreateUser = "System";
            this.CreatedDate = DateTime.Now;
            this.ModifyUser = "System";
            this.ModifyDate = DateTime.Now;
        }

        
        public int ID { get; set; }

        [DataContextColumn(MapKey = Insert, ColumnName = "WF_PROCESS_ID")]
        public string AgilePointBaseDefintionID { get; set; }

        [XmlElement(ElementName = "Type")]
        [DataContextColumn(MapKey = Insert, ColumnName = "PROPERTY_TYPE")]
        public string ProcessType { get; set; }

        [XmlElement(ElementName = "Name")]
        [DataContextColumn(MapKey = Insert, ColumnName = "PROPERTY_NAME")]
        public string ProcessKey { get; set; }

        [XmlElement(ElementName = "Map")]
        [DataContextColumn(MapKey = Insert, ColumnName = "PROPERTY_MAP")]
        public string ProcessMap { get; set; }

        /// <summary>
        /// CREATEDBY_USER
        /// </summary>
        
        [DataContextColumn(MapKey = Insert, ColumnName = "CREATEDBY_USER")]
        public string CreateUser { get; set; }

        /// <summary>
        /// CREATE_TIME
        /// </summary>
        
        [DataContextColumn(MapKey = Insert, ColumnName = "CREATE_TIME")]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// MODIFIEDBY_USER
        /// </summary>
        
        public string ModifyUser { get; set; }

        /// <summary>
        /// MODIFY_TIME
        /// </summary>
       
        public DateTime ModifyDate { get; set; }
    }
}
