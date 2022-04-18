using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PrimaxBPM2Library.Flow.Entity;
using Primax.Core.Data.Attributes;
using Primax.Core.Data;

namespace PrimaxBPM2Library.Flow.Entity
{
    public class OrgRefEntity
    {
        public const string Query = "Query";

        [DataContextMap(MapKey = Query, SQLContextType = EnumSQLContext.SQLString)]
        public OrgRefEntity()
        { }
        
        [DataContextColumn(MapKey = Query, ColumnName = "PRIMARY_ORGANIZATIONAL_UNIT_ID")]
        public string OrgUnitID { get; set; }

        [DataContextColumn(MapKey = Query, ColumnName = "RELATIONSHIP_TYPE_ID")]
        public string RefID { get; set; }
    }
}
