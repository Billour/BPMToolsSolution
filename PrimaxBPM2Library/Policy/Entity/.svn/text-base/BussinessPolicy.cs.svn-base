using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Primax.Core.Data.Attributes;
using Primax.Core.Data;

namespace PrimaxBPM2Library.Policy.Entity
{
    public class BussinessPolicy
    {
        public const string Insert = "Insert";

        public const string Table = "BUSINESS_POLICY";

        [DataContextMap(MapKey = Insert, PKNameOrTableName = Table, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Insert)]
        public BussinessPolicy()
        {
            this.CreateUser = "System";
            this.CreatedDate = DateTime.Now;
        }

        [DataContextColumn(MapKey = Insert, ColumnName = "BUSINESS_POLICY_ID")]
        public int PolicyId { get; set; }

        [DataContextColumn(MapKey = Insert, ColumnName = "BUSINESS_SYSTEM_ID")]
        public int SystemID { get; set; }

        [DataContextColumn(MapKey = Insert, ColumnName = "ORGANIZATION_ID")]
        public string OrgID { get; set; }


        [DataContextColumn(MapKey = Insert, ColumnName = "BUSINESS_POLICY_NAME")]
        public string PolicyName { get; set; }

        [DataContextColumn(MapKey = Insert, ColumnName = "BRML")]
        public string BRML { get; set; }

        //[DataContextColumn(MapKey = Insert, ColumnName = "DESCRIPTION")]
        //public string Description { get; set; }

        [DataContextColumn(MapKey = Insert, ColumnName = "MAJOR_VERSION")]
        public int MajorVersion { get; set; }

        [DataContextColumn(MapKey = Insert, ColumnName = "MINOR_VERSION")]
        public int MinorVersion { get; set; }

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

   

        //BUSINESS_POLICY_ID	int
        //	int
        //	varchar(36)
        //	SHORTNAME:nvarchar(48)
        //	ntext
        //	nvarchar(256)
        //	int
        //	int
        //CREATEDBY_USER	varchar(64)
        //CREATE_TIME	datetime
	

    }
}
