using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Primax.Core.Data.Attributes;
using Primax.Core.Data;


namespace PrimaxBPM2Library.Flow.Entity
{
    public class ProcessEntity
    {
        public const string Query = "Query";
        public const string Insert = "Insert";
        public const string Update = "Update";

        //所涉及之資料表
        public const string Table = "WF_PROCESS";

        /// <summary>
        /// Constructor
        /// </summary>
        [DataContextMap(MapKey = Query, SQLContextType = EnumSQLContext.SQLString)]
        [DataContextMap(MapKey = Insert, PKNameOrTableName = Table, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Insert)]
        [DataContextMap(MapKey = Update, PKNameOrTableName = Table, SQLContextType = EnumSQLContext.SQLString, SQLCommand = EnumSQLCommand.Update, WhereSQL = " where WF_PROCESS_ID='{0}'", Parameters = new object[] { "AgilePointBaseDefintionID" })]
        public ProcessEntity()
        {
            this.AllowDelegate = true;
            this.IsImpersonate = false;
            this.ProcessType = 1;
            this.Description = "HR系統";

            this.CreateUser = "System";
            this.CreatedDate = DateTime.Now;
            this.ModifyUser = "System";
            this.ModifyDate = DateTime.Now;

            this.Attachment = 0;
            this.WFEngineID = 1;
            this.FormPath = "WFApplications/WFProcess_Form.aspx";
        }

        /// <summary>
        /// Table :Agile Point Server.WF_PROC_DEFS.BASE_DEF_ID
        /// </summary>
        [XmlElement("ID")]
        [DataContextColumn(MapKey = Query, ColumnName = "WF_PROCESS_ID")]
        [DataContextColumn(MapKey = Insert, ColumnName = "WF_PROCESS_ID")]
        public string AgilePointBaseDefintionID { get; set; }

        /// <summary>
        /// Table：Portal.WF_BASE_PROCESS.WF_BASE_PROCESS_ID
        /// </summary>
        [DataContextColumn(MapKey = Query, ColumnName = "WF_BASE_PROCESS_ID")]
        [DataContextColumn(MapKey = Insert, ColumnName = "WF_BASE_PROCESS_ID")]
        [DataContextColumn(MapKey =Update, ColumnName = "WF_BASE_PROCESS_ID")]
        public int BaseProcessID { get; set; }

        /// <summary>
        /// 流程名稱
        /// xml:BaseProcess.Name
        /// </summary>
        [XmlElement("Name")]
        [DataContextColumn(MapKey = Query, ColumnName = "WF_PROCESS_NAME")]
        [DataContextColumn(MapKey = Insert, ColumnName = "WF_PROCESS_NAME")]
        [DataContextColumn(MapKey = Update, ColumnName = "WF_PROCESS_NAME")]
        public string ProcessName { get; set; }

        /// <summary>
        /// 這是定義前端的擷取資料用途
        /// 包括xml 與DataService
        /// </summary>
        [XmlElement("Path")]
        [DataContextColumn(MapKey = Query, ColumnName = "PATH")]
        [DataContextColumn(MapKey = Insert, ColumnName = "PATH")]
        [DataContextColumn(MapKey =Update, ColumnName = "PATH")]
        public string Path { get; set; }

        /// <summary>
        /// 允許代理
        /// </summary>
        [XmlElement("AllowDelegate")]
        [DataContextColumn(MapKey = Query, ColumnName = "ALLOW_DELEGATE")]
        [DataContextColumn(MapKey = Insert, ColumnName = "ALLOW_DELEGATE")]
        [DataContextColumn(MapKey = Update, ColumnName = "ALLOW_DELEGATE")]
        public bool AllowDelegate { get; set; }

        /// <summary>
        /// 模擬身份
        /// </summary>
        [XmlElement("Impersonate")]
        [DataContextColumn(MapKey = Query, ColumnName = "IMPERSONATE")]
        [DataContextColumn(MapKey = Insert, ColumnName = "IMPERSONATE")]
        [DataContextColumn(MapKey = Update, ColumnName = "IMPERSONATE")]
        public bool IsImpersonate { get; set; }

        /// <summary>
        /// 流程種類
        /// 1=主流程,2=子流程
        /// </summary>
        [XmlElement("FlowType")]
        [DataContextColumn(MapKey = Query, ColumnName = "PROCESS_TYPE_ID")]
        [DataContextColumn(MapKey = Insert, ColumnName = "PROCESS_TYPE_ID")]
        [DataContextColumn(MapKey = Update, ColumnName = "PROCESS_TYPE_ID")]
        public int ProcessType { get; set; }

        /// <summary>
        /// 是否附件
        /// </summary>
        [DataContextColumn(MapKey = Query, ColumnName = "ATTACHMENT")]
        [DataContextColumn(MapKey = Insert, ColumnName = "ATTACHMENT")]
        [DataContextColumn(MapKey = Update, ColumnName = "ATTACHMENT")]
        public int Attachment { get; set; }

        /// <summary>
        /// 引擎ID WF_ENGINE_ID
        /// </summary>
        [DataContextColumn(MapKey = Query, ColumnName = "WF_ENGINE_ID")]
        [DataContextColumn(MapKey = Insert, ColumnName = "WF_ENGINE_ID")]
        [DataContextColumn(MapKey = Update, ColumnName = "WF_ENGINE_ID")]
        public int WFEngineID { get; set; }

        /// <summary>
        /// FORM_PATH
        /// </summary>
        [DataContextColumn(MapKey = Query, ColumnName = "FORM_PATH")]
        [DataContextColumn(MapKey = Insert, ColumnName = "FORM_PATH")]
        [DataContextColumn(MapKey = Update, ColumnName = "FORM_PATH")]
        public string FormPath { get; set; }

        /// <summary>
        /// 說明
        /// </summary>
        [XmlElement("Description")]
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
