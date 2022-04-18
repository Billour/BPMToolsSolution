using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Primax.Core.Data;
using Primax.Core.Data.Extensions;
using System.Data.Common;
using PrimaxBPM2Library.Flow.Entity;
using Primax.Portal.BusinessLayer;


namespace PrimaxBPM2Library.Flow.Logic
{
    public class WorkFlowLogic
    {
        public DataTable GetStartForm()
        {
            string sql = @"SELECT B.WF_PROCESS_ID, B.WF_PROCESS_NAME, D.WF_FORM_ID, D.FORM_NAME, D.TITLE, D.PATH, D.IS_START_FORM, D.CREATEDBY_USER, 
                                   D.CREATE_TIME, D.MODIFIEDBY_USER, D.MODIFY_TIME
                                FROM  dbo.WF_BASE_PROCESS AS A INNER JOIN
                                               dbo.WF_PROCESS AS B ON A.WF_BASE_PROCESS_ID = B.WF_BASE_PROCESS_ID INNER JOIN
                                               dbo.WF_ORGANIZATION_PROCESS AS E ON B.WF_PROCESS_ID = E.WF_PROCESS_ID INNER JOIN
                                               dbo.WF_PROCESS_FORM AS C ON B.WF_PROCESS_ID = C.WF_PROCESS_ID INNER JOIN
                                               dbo.WF_FORM AS D ON C.WF_FORM_ID = D.WF_FORM_ID
                                WHERE (A.WF_BASE_PROCESS_CODE = 'LE') AND (E.ORGANIZATION_ID = 'UDT3')";

            DataContext context = new DataContext();

            return context.QuerySelect(sql);
        }

        /// <summary>
        /// 取得Flow
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="policyName"></param>
        /// <returns></returns>
        public List<FlowPersonEntity> GetSeqFlow(string accountId, string policyName)
        {
            Factory factory = new Factory();
            //取得人員資訊
            List<FlowPersonEntity> list = new List<FlowPersonEntity>();

            FlowPersonEntity applicant = GetApplicantPerson(accountId);

            list.Add(applicant);

            //取得的單位的主管資料
            string unitId = applicant.OrganzationUnitID;

            string orgList=GetSequentialList(unitId);

            if (orgList.Length > 0)
            {
                orgList=orgList.Substring(0, orgList.Length - 1);
            }



            List<string> seqList = factory.OrganizationManager.GetSequentialList(unitId).Result;

            return list;
        }

        private FlowPersonEntity GetApplicantPerson(string accountId)
        {
            DataContext context = new DataContext("HR");

            string sql = "select * from dbo.VW_PERSON where upper(ACCOUNT)=upper('{0}')";

            List<FlowPersonEntity> list= context.QuerySelect<FlowPersonEntity>(sql, FlowPersonEntity.Query, accountId);

            if (list.Count > 0)
            {
                return list[0];
            }

            return null;
        }

        /// <summary>
        /// 使用Person ID取得user 資料
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        private FlowPersonEntity GetApplicantPersonById(string personId)
        {
            DataContext context = new DataContext("HR");

            string sql = "select * from dbo.VW_PERSON where upper(PERSON_ID)=upper('{0}')";

            List<FlowPersonEntity> list = context.QuerySelect<FlowPersonEntity>(sql, FlowPersonEntity.Query, personId);

            if (list.Count > 0)
            {
                return list[0];
            }

            return null;
        }

        private string GetSequentialList(string orgUnitId)
        {
            string orgList = orgUnitId+",";

            DataContext context=new DataContext("HR");

            string sql = "SELECT PRIMARY_ORGANIZATIONAL_UNIT_ID, RELATIONSHIP_TYPE_ID  FROM VW_VALID_ORGANIZATIONAL_UNIT_RELATION WHERE RELATED_ORGANIZATIONAL_UNIT_ID ='{0}'";

            List<OrgRefEntity> list = context.QuerySelect<OrgRefEntity>(sql, OrgRefEntity.Query, orgUnitId);

            if (list.Count > 0)
            {
                OrgRefEntity org = list[0];

                if (org.RefID == "1" || org.RefID == "2")
                {
                    string parent = org.OrgUnitID;

                    orgList += GetSequentialList(parent); 
                }
            }


            return orgList;
        }
        
    }
}
