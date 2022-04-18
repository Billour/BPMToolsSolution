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
    public class BussinessNumberEntity
    {
        public const string Query = "Query";
        public const string Insert = "Insert";
        public const string Update = "Update";

        //所涉及之資料表
        public const string Table = "BUSINESS_NUMBER";

        [DataContextMap(MapKey = Query, SQLContextType = EnumSQLContext.SQLString)]
        [DataContextMap(MapKey = Insert, PKNameOrTableName = Table, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Insert)]
        [DataContextMap(MapKey = Update, PKNameOrTableName = Table, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Update, WhereSQL = " where BUSINESS_NUMBER_ID={0} ", Parameters = new object[] { "NumberID"})]
        public BussinessNumberEntity()
        {
            this.Middle = DateTime.Now.ToString("yyMM");
            this.MiddleFormat = "YYMM";
            this.Length = "6";
            this.Sequence = 0;
            //this.EffectiveDate = "2010/08/31";


            this.CreateUser = "System";
            this.CreatedDate = DateTime.Now;
            this.ModifyUser = "System";
            this.ModifyDate = DateTime.Now;
        }


        
       
        [DataContextColumn(MapKey = Query, ColumnName = "BUSINESS_NUMBER_ID")]
        public int NumberID { get; set; }

        [XmlElement(ElementName = "BUSINESS_JOB_ID")]
        [DataContextColumn(MapKey = Insert, ColumnName = "BUSINESS_JOB_ID")]
        [DataContextColumn(MapKey = Update, ColumnName = "BUSINESS_JOB_ID")]
        [DataContextColumn(MapKey = Query, ColumnName = "BUSINESS_JOB_ID")]
        public int JobID { get; set; }

        [XmlElement(ElementName = "PREFIX")]
        [DataContextColumn(MapKey = Insert, ColumnName = "PREFIX")]
        //[DataContextColumn(MapKey = Update, ColumnName = "PREFIX")]
        [DataContextColumn(MapKey = Query, ColumnName = "PREFIX")]
        public string Prefix{get;set;}

        [XmlElement(ElementName = "MIDDLE")]
        [DataContextColumn(MapKey = Insert, ColumnName = "MIDDLE")]
        //[DataContextColumn(MapKey = Update, ColumnName = "MIDDLE")]
        [DataContextColumn(MapKey = Query, ColumnName = "MIDDLE")]
        public string Middle{get;set;}

        [XmlElement(ElementName = "MIDDLE_FORMAT")]
        [DataContextColumn(MapKey = Insert, ColumnName = "MIDDLE_FORMAT")]
        //[DataContextColumn(MapKey = Update, ColumnName = "MIDDLE_FORMAT")]
        [DataContextColumn(MapKey = Query, ColumnName = "MIDDLE_FORMAT")]
        public string MiddleFormat{get;set;}

        [XmlElement(ElementName = "SUFFIX_LENGTH")]
        [DataContextColumn(MapKey = Insert, ColumnName = "SUFFIX_LENGTH")]
        //[DataContextColumn(MapKey = Update, ColumnName = "SUFFIX_LENGTH")]
        [DataContextColumn(MapKey = Query, ColumnName = "SUFFIX_LENGTH")]
        public string Length{get;set;}

        [XmlElement(ElementName = "SEQUENCE")]
        [DataContextColumn(MapKey = Insert, ColumnName = "SEQUENCE")]
        //[DataContextColumn(MapKey = Update, ColumnName = "SEQUENCE")]
        [DataContextColumn(MapKey = Query, ColumnName = "SEQUENCE")]
        public int Sequence{get;set;}

        [XmlElement(ElementName = "EFFECTIVE_DATE")]
        public string EffectiveDate{get;set;}

        private DateTime _date;

        [DataContextColumn(MapKey = Insert, ColumnName = "EFFECTIVE_DATE")]
        //[DataContextColumn(MapKey = Update, ColumnName = "EFFECTIVE_DATE")]
        [DataContextColumn(MapKey = Query, ColumnName = "EFFECTIVE_DATE")]
        public DateTime EffectiveDate2 {get { return Convert.ToDateTime(EffectiveDate); } }

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
        //[DataContextColumn(MapKey = Update, ColumnName = "MODIFIEDBY_USER")]
        public string ModifyUser { get; set; }

        /// <summary>
        /// MODIFY_TIME
        /// </summary>
        [DataContextColumn(MapKey = Query, ColumnName = "MODIFY_TIME")]
        //[DataContextColumn(MapKey = Update, ColumnName = "MODIFY_TIME")]
        public DateTime ModifyDate { get; set; }
    }
}
