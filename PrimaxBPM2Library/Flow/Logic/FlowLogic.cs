using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrimaxBPM2Library.Flow.Entity;
using Primax.Core.Data;
using Primax.Core.Data.Extensions;
using System.Data.Common;
using System.Data;
using PrimaxBPM2Library.Config;

namespace PrimaxBPM2Library.Flow.Logic
{
    public class FlowLogic
    {


        public FlowLogic()
        {
            this.Environment = "Test";
        }

        public FlowLogic(string env)
        {
            this.Environment = env;
        }

        public string Environment { get; set; }

        //public string GetAgilePointBasreDefIDFromDefName(string defName)
        //{
        //    DataContext context = new DataContext("BPM");

        //    string sql = "select BASE_DEF_ID from dbo.WF_PROC_DEFS where STATUS='Released' and DEF_NAME='{0}'";

        //    DataTable dt = context.QuerySelect(sql, defName);

        //    if (dt.Rows.Count == 0)
        //    {
        //        throw new Exception(String.Format("無法取得{0}流程的BaseDefID", defName));
        //    }

        //    return dt.Rows[0]["BASE_DEF_ID"].ToString();
        //}

        public string GetProcessIDFromWebConfig(string code)
        {
            return Environment.GetProcessList()[code].ToString();
        }

        public string DBKey()
        {
            return Environment.GetPortalDB();
        }

        /// <summary>
        /// 新增BaseProcessFlow
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool InsertBaseFlow(BaseProcessEntity obj)
        {
            DataContext context = new DataContext(DBKey());

            DbCommand comm = obj.GetDBCommand<BaseProcessEntity>(context.DBase, BaseProcessEntity.Insert);

            return context.SaveChange(comm);

        }

        /// <summary>
        /// 取得BaseProcess資料
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private BaseProcessEntity QueryBaseFlowProcess(string code)
        {
            BaseProcessEntity obj = null;

            DataContext context = new DataContext(DBKey());

            string sql = "select * from WF_BASE_PROCESS where WF_BASE_PROCESS_CODE='{0}'";

            List<BaseProcessEntity> list = context.QuerySelect<BaseProcessEntity>(sql, BaseProcessEntity.Query, code);

            if (list.Count > 0)
            {
                obj = list[0];
            }

            return obj;
        }

        /// <summary>
        /// Update Base Process Flow
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool UpdateBaseFlow(BaseProcessEntity obj)
        {
            DataContext context = new DataContext(DBKey());

            DbCommand comm = obj.GetDBCommand<BaseProcessEntity>(context.DBase, BaseProcessEntity.Update);

            return context.SaveChange(comm);

        }

        /// <summary>
        /// Save Chanage
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public BaseProcessEntity SaveChangeBaseProcess(BaseProcessEntity obj)
        {
            BaseProcessEntity objValue = QueryBaseFlowProcess(obj.Code);

            //判斷資料是否存在
            if (objValue != null)
            {
                //存在
                if (!UpdateBaseFlow(obj))
                {
                    throw new Exception("無法更新Base process Flow");
                }
            }
            else
            {
                //不存在
                if (!InsertBaseFlow(obj))
                {
                    throw new Exception("無法新增Base process Flow");
                }
            }

            return QueryBaseFlowProcess(obj.Code);

        }


        /// <summary>
        /// 存取Flow 資料
        /// </summary>
        /// <param name="flows"></param>
        public bool SaveChangeFlow(FlowsEntity flows)
        {
            string mapKey = "";
           
            
            
            List<DbCommand> commList = new List<DbCommand>();

            DataContext context = new DataContext(DBKey());

            List<ActivityEntity> activityList = new List<ActivityEntity>();

            BaseProcessEntity baseProcess = SaveChangeBaseProcess(flows.BaseProcess);

            int processBaseID = baseProcess.ID;

            string Prefix = baseProcess.Code;

            flows.FlowList.ForEach(p => {

                bool blDeleteFlag = false;
                blDeleteFlag = DeleteOldFlow(GetProcessIDFromWebConfig(baseProcess.Code), baseProcess.Code); 
                if(blDeleteFlag)
                {   
                    //存取ProcessEntity
                    
                p.Process.BaseProcessID = processBaseID;
                //取得Agile Point Name
                p.Process.AgilePointBaseDefintionID = GetProcessIDFromWebConfig(baseProcess.Code);
                p.Process.ProcessName = baseProcess.Name;

                string mpaId = "";

                if (IsProcessExist(p.Process.AgilePointBaseDefintionID))
                {
                    mpaId = ProcessEntity.Update;
                }
                else
                {
                    mpaId = ProcessEntity.Insert;
                }

                DbCommand comm = p.Process.GetDBCommand<ProcessEntity>(context.DBase, mpaId);
                commList.Add(comm);

                string GroupOrgId="";
                int No= GetNextGroupProcessNumber();
               

                //Group Process
                foreach (GroupProcessEntity g in p.Groups)
                {
                    g.AgilePointBaseDefintionID = p.Process.AgilePointBaseDefintionID;

                    mapKey = "";

                    GroupOrgId=g.OrgnizationID;

                    if (!IsOrgProcessExist(g.OrgnizationID, g.AgilePointBaseDefintionID))
                    {
                        mapKey = GroupProcessEntity.Insert;

                        g.ID = No;

                        No++;

                        comm = g.GetDBCommand<GroupProcessEntity>(context.DBase, mapKey);
                        commList.Add(comm);
                        
                    }
                   
                }

                //流程變數
                //刪除原始資料

                string deleteProcessSQL = String.Format("delete from WF_PROCESS_PROPERTY where  WF_PROCESS_ID='{0}'", p.Process.AgilePointBaseDefintionID);

                comm = context.DBase.GetSqlStringCommand(deleteProcessSQL);
                commList.Add(comm);

                p.PropertyList.ForEach(pp =>
                {

                    pp.AgilePointBaseDefintionID = p.Process.AgilePointBaseDefintionID;

                    comm = pp.GetDBCommand<ProcessPropertyEntity>(context.DBase, ProcessPropertyEntity.Insert);
                    commList.Add(comm);

                });

                //Form 基本資料
                int number = GetFormNextNumber();

                p.FormList.ForEach(pp =>
                {

                    mapKey = "";

                    pp.AgilePointBaseDefintionID = p.Process.AgilePointBaseDefintionID;

                    if (IsWebFormExist(pp.Name,pp.Title))
                    {
                        mapKey = FormPageEntity.Update;
                    }
                    else
                    {
                        mapKey = FormPageEntity.Insert;

                        number = number + 1;

                        pp.ID = number;
                    }

                    comm = pp.GetDBCommand<FormPageEntity>(context.DBase, mapKey);
                    commList.Add(comm);

                    //Process Form Relation

                    if (!IsWebFormProcessRelationExist(pp.AgilePointBaseDefintionID, pp.ID))
                    {
                        comm = pp.GetDBCommand<FormPageEntity>(context.DBase, FormPageEntity.Insert2);
                        commList.Add(comm);
                    }


                });

                //Activity
                p.ActivityList.ForEach(pp =>
                {

                    pp.AgilePointBaseDefintionID = p.Process.AgilePointBaseDefintionID;

                    pp.Parameters = pp.Parameters.Replace(";", "&");

                    mapKey = "";

                    if (IsWebActivityExist(pp.Code, pp.AgilePointBaseDefintionID))
                    {
                        mapKey = ActivityEntity.Update;

                    }
                    else
                    {
                        mapKey = ActivityEntity.Insert;
                    }

                    activityList.Add(pp);

                    comm = pp.GetDBCommand<ActivityEntity>(context.DBase, mapKey);
                    commList.Add(comm);

                });

                //Job
                mapKey = "";
                p.Job.ProcessID = p.Process.AgilePointBaseDefintionID;
                p.Job.ProcessName = p.Process.ProcessName;

                int jobNumber = GetNextJobNumber();
                foreach (GroupProcessEntity g in p.Groups)
                {
                    p.Job.OrgID = g.OrgnizationID;

                    if (!IsJobExist(p.Job.OrgID, p.Job.ProcessID))
                    {
                        p.Job.ID = jobNumber; 

                        mapKey = BussinessJobEntity.Insert;

                        comm = p.Job.GetDBCommand<BussinessJobEntity>(context.DBase, mapKey);
                        commList.Add(comm);

                        jobNumber++;

                        //Number
                        if (!IsJobNumberExist(p.Job.ID))
                        {
                            mapKey = ActivityCommandEntity.Insert;

                            p.BussinessNumber.JobID = p.Job.ID;

                            p.BussinessNumber.Prefix = Prefix;

                            p.BussinessNumber.EffectiveDate = DateTime.Now.ToString("yyyy/MM/dd");
                        }
                       

                        comm = p.BussinessNumber.GetDBCommand<BussinessNumberEntity>(context.DBase, mapKey);
                        commList.Add(comm);
                    }
                }
               

                //if (IsJobExist(p.Job.OrgID,p.Job.ProcessID))
                //{
                //    mapKey = ActivityCommandEntity.Update;
                //}
                //else
                //{
                //    //Get Next Number

                //    mapKey = ActivityCommandEntity.Insert;
                //}

               

                


                }
            }
            
            );

            bool isSuccess = context.SaveChange(commList);

            commList = new List<DbCommand>();

            bool isFlag = false;

            if (isSuccess)
            {
                activityList.ForEach(p =>
                {

                    ActivityEntity obj = QueryActivity(p.Code, p.AgilePointBaseDefintionID);

                    if (obj == null)
                    {
                        throw new Exception("無法取得Activity 資料");
                    }

                    p.CommandList.ForEach(pp =>
                    {

                        //Query Activity Data
                        pp.ActivityID = obj.ID;

                        mapKey = "";

                        if (IsActivityCommandExist(pp.CommandID, pp.ActivityID))
                        {
                            mapKey = ActivityCommandEntity.Update;
                        }
                        else
                        {
                            mapKey = ActivityCommandEntity.Insert;
                        }

                        DbCommand comm = pp.GetDBCommand<ActivityCommandEntity>(context.DBase, mapKey);
                        commList.Add(comm);

                    });

                });

                //Job


                isFlag = context.SaveChange(commList);

            }
            else
            {
                isFlag = true;
            }

            return isFlag;

        }

        /// <summary>
        /// 取得Group Process Number
        /// </summary>
        /// <returns></returns>
        private int GetNextGroupProcessNumber()
        {
            string sql = "select isnull(MAX(WF_ORGANIZATION_PROCESS_ID),0)+1 as Number from WF_ORGANIZATION_PROCESS";

            DataContext context = new DataContext(DBKey());

            DataTable dt = context.QuerySelect(sql);

            int number = 1;

            if (dt.Rows.Count > 0)
            {
                number = Convert.ToInt32(dt.Rows[0]["Number"]);
            }

            return number;
        }

        /// <summary>
        /// 取得Form Number
        /// </summary>
        /// <returns></returns>
        private int GetFormNextNumber()
        {
            string sql = "select isnull(MAX(WF_FORM_ID),0) as Number from WF_FORM";

            DataContext context = new DataContext(DBKey());

            DataTable dt = context.QuerySelect(sql);

            int number = 0;

            if (dt.Rows.Count > 0)
            {
                number = Convert.ToInt32(dt.Rows[0]["Number"]);
            }

            return number;
        }


        //public bool IsPolicyExist(int ID)
        //{
        //    string sql = "select * from BUSINESS_POLICY where BUSINESS_POLICY_ID={0}";

        //    DataContext context = new DataContext();

        //    return context.QuerySelect<BussinessPolicy>(sql, BussinessPolicy.Query, ID).Count > 0;
        //}

        /// <summary>
        /// 是否Bussiness Job 存在
        /// </summary>
        /// <param name="orgId"></param>
        /// <param name="baseProcessId"></param>
        /// <returns></returns>
        public bool IsJobExist(string orgId, string baseProcessId)
        {
            string sql = "select * from dbo.BUSINESS_JOB where ORGANIZATION_ID='{0}' and BUSINESS_JOB_CODE='{1}'";

            DataContext context = new DataContext(DBKey());

            return context.QuerySelect<BussinessJobEntity>(sql, BussinessJobEntity.Query, orgId, baseProcessId).Count > 0;
        }

        public int GetNextJobNumber()
        {
            string sql = "select MAX(BUSINESS_JOB_ID)+1 as MaxNumber from dbo.BUSINESS_JOB";

            DataContext context = new DataContext(DBKey());

            DataTable dt = context.QuerySelect(sql);

            int max = 1;

            if (dt.Rows.Count > 0)
            {
                max = Convert.ToInt32(dt.Rows[0]["MaxNumber"]);
            }

            return max;
        }


        public bool IsJobNumberExist(int id)
        {
            //string sql = "select * from BUSINESS_NUMBER where PREFIX='{0}' and MIDDLE='{1}'";

            string sql="SELECT *  FROM BUSINESS_NUMBER where BUSINESS_JOB_ID={0}";

            DataContext context = new DataContext(DBKey());

            return context.QuerySelect<BussinessNumberEntity>(sql, ProcessEntity.Query,id).Count > 0;
        }

        /// <summary>
        /// 判斷Process是否存在
        /// </summary>
        /// <param name="agilePointBaseDefinitionID"></param>
        /// <returns></returns>
        private bool IsProcessExist(string agilePointBaseDefinitionID)
        {
            string sql = "select * from WF_PROCESS where WF_PROCESS_ID='{0}'";

            DataContext context = new DataContext(DBKey());

            return context.QuerySelect<ProcessEntity>(sql, ProcessEntity.Query, agilePointBaseDefinitionID).Count > 0;
        }

        /// <summary>
        /// 判斷org 資料是否存在
        /// </summary>
        /// <param name="orgId"></param>
        /// <param name="agilePointBaseDefinitionID"></param>
        /// <returns></returns>
        private bool IsOrgProcessExist(string orgId, string agilePointBaseDefinitionID)
        {
            string sql = "select * from dbo.WF_ORGANIZATION_PROCESS where ORGANIZATION_ID='{0}' and WF_PROCESS_ID='{1}'";

            DataContext context = new DataContext(DBKey());

            return context.QuerySelect<GroupProcessEntity>(sql, GroupProcessEntity.Query, orgId, agilePointBaseDefinitionID).Count > 0;
        }

        private bool IsWebFormExist(string name, string title)
        {
            string sql = "select * from WF_FORM where FORM_NAME='{0}' and TITLE='{1}'";

            DataContext context = new DataContext(DBKey());

            return context.QuerySelect<FormPageEntity>(sql, FormPageEntity.Query, name, title).Count > 0;
        }

        private bool IsWebFormProcessRelationExist(string agileProcessId, int formId)
        {
            string sql = "select * from WF_PROCESS_FORM where WF_PROCESS_ID='{0}' and WF_FORM_ID={1}";

            DataContext context = new DataContext(DBKey());

            return context.QuerySelect<FormPageEntity>(sql, FormPageEntity.Query2, agileProcessId, formId).Count > 0;
        }

        private bool IsWebActivityExist(string code, string agilePointBaseDefinitionID)
        {
            string sql = "select * from dbo.WF_ACTIVITY where WF_PROCESS_ID='{0}' and WF_ACTIVITY_CODE='{1}'";

            DataContext context = new DataContext(DBKey());

            return context.QuerySelect<ActivityEntity>(sql, FormPageEntity.Query, agilePointBaseDefinitionID, code).Count > 0;
        }

        private ActivityEntity QueryActivity(string code, string agilePointBaseDefinitionID)
        {
            string sql = "select * from dbo.WF_ACTIVITY where WF_PROCESS_ID='{0}' and WF_ACTIVITY_CODE='{1}'";

            DataContext context = new DataContext(DBKey());

            List<ActivityEntity> list = context.QuerySelect<ActivityEntity>(sql, FormPageEntity.Query, agilePointBaseDefinitionID, code);

            ActivityEntity obj = null;

            if (list.Count > 0)
            {
                obj = list[0];
            }

            return obj;
        }

        private bool IsActivityCommandExist(int commandId, int activityId)
        {
            string sql = "select * from WF_ACTIVITY_COMMAND where WF_COMMAND_ID={0} and WF_ACTIVITY_ID={1}";

            DataContext context = new DataContext(DBKey());

            return context.QuerySelect<ActivityCommandEntity>(sql, ActivityCommandEntity.Query, commandId, activityId).Count > 0;
        }

        public bool DeleteOldFlow(string strWfProcessId, string strProcessCode)
        {
            List<DbCommand> commList = new List<DbCommand>();
            bool blResult = false;
            string strSql = string.Empty;
            DataContext context = new DataContext(DBKey());
            DataTable table1 = new DataTable();

            strSql = @"SELECT BUSINESS_JOB_ID
                    FROM BUSINESS_JOB
                    WHERE BUSINESS_JOB_CODE ='{0}'";
            table1 = context.QuerySelect(strSql, strWfProcessId);
            if (table1.Rows.Count > 0)
            {
                foreach (DataRow dr in table1.Rows)
                {
                    strSql = @"DELETE FROM
                    BUSINESS_NUMBER
                    WHERE BUSINESS_JOB_ID =" + dr["BUSINESS_JOB_ID"].ToString();
                    DbCommand comm = context.DBase.GetSqlStringCommand(strSql);
                    commList.Add(comm);
                }
            }

            strSql = @"DELETE FROM
                        BUSINESS_JOB
                        WHERE BUSINESS_JOB_CODE ='" + strWfProcessId + "'";
            DbCommand comm1 = context.DBase.GetSqlStringCommand(strSql);
            commList.Add(comm1);

            table1.Clear();
            strSql = @"SELECT WF_ACTIVITY_ID
                        FROM WF_ACTIVITY
                        WHERE WF_PROCESS_ID='{0}'";
            table1 = context.QuerySelect(strSql, strWfProcessId);
            if (table1.Rows.Count > 0)
            {
                foreach (DataRow dr in table1.Rows)
                {
                    strSql = @"DELETE FROM
                    WF_ACTIVITY_COMMAND
                    WHERE WF_ACTIVITY_ID='" + dr["WF_ACTIVITY_ID"].ToString() + "'";
                    DbCommand comm2 = context.DBase.GetSqlStringCommand(strSql);
                    commList.Add(comm2);
                }
            }

            strSql = @"DELETE FROM
                        WF_ACTIVITY
                        WHERE WF_PROCESS_ID='" + strWfProcessId + "'";
            DbCommand comm3 = context.DBase.GetSqlStringCommand(strSql);
            commList.Add(comm3);

//            strSql = @"DELETE FROM
//                        WF_BASE_PROCESS
//                        WHERE WF_BASE_PROCESS_CODE ='" + strProcessCode + "'";
//            DbCommand comm4 = context.DBase.GetSqlStringCommand(strSql);
//            commList.Add(comm4);


            table1.Clear();
            strSql = @"SELECT WF_FORM_ID
                        FROM WF_PROCESS_FORM
                        WHERE WF_PROCESS_ID='{0}'";
            table1 = context.QuerySelect(strSql, strWfProcessId);
            if (table1.Rows.Count > 0)
            {
                foreach (DataRow dr in table1.Rows)
                {
                    strSql = @"DELETE FROM
                                WF_FORM
                                WHERE WF_FORM_ID='" + dr["WF_FORM_ID"].ToString() + "'";
                    DbCommand comm5 = context.DBase.GetSqlStringCommand(strSql);
                    commList.Add(comm5);
                }
            }
            strSql = @"DELETE FROM
                        WF_PROCESS_FORM
                        WHERE WF_PROCESS_ID='" + strWfProcessId + "'";
            DbCommand comm6 = context.DBase.GetSqlStringCommand(strSql);
            commList.Add(comm6);

            strSql = @"DELETE FROM
                        WF_PROCESS_PROPERTY
                        WHERE WF_PROCESS_ID='" + strWfProcessId + "'";
            DbCommand comm7 = context.DBase.GetSqlStringCommand(strSql);
            commList.Add(comm7);

            strSql = @"DELETE FROM
                        WF_ORGANIZATION_PROCESS
                        WHERE WF_PROCESS_ID='" + strWfProcessId + "'";
            DbCommand comm8 = context.DBase.GetSqlStringCommand(strSql);
            commList.Add(comm8);

            strSql = @"DELETE FROM
                        WF_PROCESS
                        WHERE WF_PROCESS_ID='" + strWfProcessId + "'";
            DbCommand comm9 = context.DBase.GetSqlStringCommand(strSql);
            commList.Add(comm9);

            blResult = context.SaveChange(commList);
            return blResult;
        }
    }
}
