using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrimaxBPM2Library.Flow.Entity;
using Primax.Core.Data.Attributes;
using Primax.Core.Data;

namespace PrimaxBPM2Library.Flow.Entity
{
    public class FlowPersonEntity
    {
        public const string Query = "Query";

        [DataContextMap(MapKey = Query, SQLContextType = EnumSQLContext.SQLString)]
        public FlowPersonEntity()
        { }

        /// <summary>
        /// PersonId
        /// </summary>
        [DataContextColumn(MapKey = Query, ColumnName = "PERSON_ID")]
        public string PersonId { get; set; }

        /// <summary>
        /// Account ID
        /// </summary>
        [DataContextColumn(MapKey = Query, ColumnName = "ACCOUNT")]
        public string AccountId { get; set; }

        /// <summary>
        /// Org Id
        /// </summary>
        [DataContextColumn(MapKey = Query, ColumnName = "ORGANIZATION_ID")]
        public string OrganizationId { get; set; }

        /// <summary>
        /// Org Name
        /// </summary>
        [DataContextColumn(MapKey = Query, ColumnName = "ORGANIZATION_NAME")]
        public string OrganizationName { get; set; }

        /// <summary>
        /// 職缺
        /// </summary>
        [DataContextColumn(MapKey = Query, ColumnName = "RANK")]
        public string Rank { get; set; }

        /// <summary>
        /// Unit ID
        /// </summary>
        [DataContextColumn(MapKey = Query, ColumnName = "ORGANIZATIONAL_UNIT_ID")]
        public string OrganzationUnitID { get; set; }

        /// <summary>
        /// Unit Name
        /// </summary>
        [DataContextColumn(MapKey = Query, ColumnName = "ORGANIZATIONAL_UNIT_NAME")]
        public string OrganzationUnitName { get; set; }
    }
}
