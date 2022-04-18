using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Primax.Core.Data.Attributes;
using Primax.Core.Data;


namespace PrimaxBPM2Library.Flow.Entity
{
    public class MailTemplateEntity
    {
        public const string Query = "Query";
        public const string Insert = "Insert";
        public const string Update = "Update";

        //Table
        public const string Table = "MAIL_TEMPLATE";

        /// <summary>
        /// Constructor
        /// </summary>
        [DataContextMap(MapKey = Query, SQLContextType = EnumSQLContext.SQLString)]
        [DataContextMap(MapKey = Insert, PKNameOrTableName = Table, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Insert)]
        [DataContextMap(MapKey = Update, PKNameOrTableName = Table, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Update, WhereSQL = " where TEMPLATE_NAME='{0}'", Parameters = new object[] { "Name" })]
        public MailTemplateEntity()
        {
            this.CreatedTime = DateTime.Now;
            this.CreateUser = "System";
        }

        /// <summary>
        /// Template Name
        /// </summary>
        [DataContextColumn(MapKey = Query, ColumnName = "TEMPLATE_NAME")]
        [DataContextColumn(MapKey = Insert, ColumnName = "TEMPLATE_NAME")]
        public string Name { get; set; }

        [DataContextColumn(MapKey = Query, ColumnName = "SUBJECT")]
        [DataContextColumn(MapKey = Insert, ColumnName = "SUBJECT")]
        [DataContextColumn(MapKey = Update, ColumnName = "SUBJECT")]
        public string Subject { get; set; }

        [DataContextColumn(MapKey = Query, ColumnName = "DESCRIPTION")]
        [DataContextColumn(MapKey = Insert, ColumnName = "DESCRIPTION")]
        [DataContextColumn(MapKey = Update, ColumnName = "DESCRIPTION")]
        public string Description { get; set; }

        [DataContextColumn(MapKey = Query, ColumnName = "BODY")]
        [DataContextColumn(MapKey = Insert, ColumnName = "BODY")]
        [DataContextColumn(MapKey = Update, ColumnName = "BODY")]
        public string Body { get; set; }

        [DataContextColumn(MapKey = Query, ColumnName = "CREATEDBY_USER")]
        [DataContextColumn(MapKey = Insert, ColumnName = "CREATEDBY_USER")]
        public string CreateUser { get; set; }

        /// <summary>
        /// Create Time
        /// </summary>
        [DataContextColumn(MapKey = Query, ColumnName = "CREATE_TIME")]
        [DataContextColumn(MapKey = Insert, ColumnName = "CREATE_TIME")]
        public DateTime CreatedTime { get; set; }
    }
}
