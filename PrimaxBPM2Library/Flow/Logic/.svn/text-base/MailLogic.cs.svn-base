using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrimaxBPM2Library.Flow.Entity;
using Primax.Core.Data;
using Primax.Core.Data.Extensions;
using System.Data.Common;


namespace PrimaxBPM2Library.Flow.Logic
{
    public enum EnumMailRole
    {
        /// <summary>
        /// 填寫人
        /// </summary>
        EditUser,

        /// <summary>
        /// 申請人
        /// </summary>
        ApplyUser,

        /// <summary>
        /// 工作代理人
        /// </summary>
        AgentUser,

        /// <summary>
        /// 簽核人員
        /// </summary>
        SignUser,

        /// <summary>
        /// HR 人員
        /// </summary>
        HRUser,

        /// <summary>
        /// General User
        /// </summary>
        GeneralListUser

    }

    public class MailLogic
    {
        public bool InserMailLTemplate()
        {
            List<MailTemplateEntity> list = new List<MailTemplateEntity>() { 
                //彈性工時
                new MailTemplateEntity(){ Name="彈性工時申請單簽核通知", Subject="#APPLICANT#彈性工時申請單簽核通知:#FLEX_TIME#", Body=GetFlexTimeAlertBody(), Description=""},
                new MailTemplateEntity(){ Name="彈性工時申請單退回通知", Subject="#APPLICANT#彈性工時申請單退回通知:#FLEX_TIME#", Body=GetFlexTimeRejectBody(), Description=""},
                new MailTemplateEntity(){ Name="彈性工時申請單主管逾期未簽核通知", Subject="#APPLICANT#彈性工時申請單主管逾期未簽核通知:#FLEX_TIME#", Body=GetFlexTimeOverDueBody(), Description=""},
                new MailTemplateEntity(){ Name="彈性工時申請單已核准通知", Subject="#APPLICANT#彈性工時申請單已核准通知:#FLEX_TIME#", Body=GetFlexTimeApproveBody(), Description=""},

                //年度休假計畫
                new MailTemplateEntity(){ Name="年度休假計畫申請單簽核通知", Subject="#APPLICANT#年度休假計畫申請單簽核通知", Body=GetVacationAlertBody(), Description=""},
                new MailTemplateEntity(){ Name="年度休假計畫申請單退回通知", Subject="#APPLICANT#年度休假計畫申請單退回通知", Body=GetVacationRejectBody(), Description=""},
                new MailTemplateEntity(){ Name="年度休假計畫申請單主管逾期未簽核通知", Subject="#APPLICANT#年度休假計畫申請單主管逾期未簽核通知", Body=GetVacationOverDueBody(), Description=""},
                new MailTemplateEntity(){ Name="年度休假計畫申請單已核准通知", Subject="#APPLICANT#年度休假計畫申請單已核准通知", Body=GetVacationApproveBody(), Description=""},

                //加班申請
                new MailTemplateEntity(){ Name="加班申請單簽核通知", Subject="#APPLICANT#加班申請單簽核通知:#OVERTIME_DATA#", Body=GetOverTimeAlertBody(), Description=""},
                new MailTemplateEntity(){ Name="加班申請單退回通知", Subject="#APPLICANT#加班申請單退回通知:#OVERTIME_DATA#", Body=GetOverTimeRejectBody(), Description=""},
                new MailTemplateEntity(){ Name="加班申請單主管逾期未簽核通知", Subject="#APPLICANT#加班申請單主管逾期未簽核通知:#OVERTIME_DATA#", Body=GetOverTimeOverDueBody(), Description=""},
                new MailTemplateEntity(){ Name="加班申請單已核准通知", Subject="#APPLICANT#加班申請單已核准通知:#OVERTIME_DATA#", Body=GetOverTimeApproveBody(), Description=""},
                new MailTemplateEntity(){ Name="當月累計加班時數超過46小時", Subject="#APPLICANT#當月累計加班時數超過46小時(包含加班費+轉換調休)", Body=GetOverTime46HoursBody(), Description=""},

                //延休申請
                new MailTemplateEntity(){ Name="延休申請單簽核通知", Subject="延休申請單簽核通知", Body=GetExtendLeaveAlertBody(), Description=""},
                new MailTemplateEntity(){ Name="延休申請單退回通知", Subject="#APPLICANT#延休申請單退回通知#", Body=GetExtendLeaveRejectBody(), Description=""},
                new MailTemplateEntity(){ Name="延休申請單主管逾期未簽核通知", Subject="#APPLICANT#延休申請單主管逾期未簽核通知", Body=GetExtendLeaveOverDueBody(), Description=""},
                new MailTemplateEntity(){ Name="延休申請單已核准通知", Subject="延休申請單已核准通知", Body=GetExtendLeaveApproveBody(), Description=""},

                //請假取消
                new MailTemplateEntity(){ Name="請假取消申請單簽核通知", Subject="#APPLICANT#請假取消申請單簽核通知", Body=GetLeaveCancelAlertBody(), Description=""},
                new MailTemplateEntity(){ Name="請假取消申請單退回通知", Subject="#APPLICANT#請假取消申請單退回通知#", Body=GetLeaveCancelRejectBody(), Description=""},
                new MailTemplateEntity(){ Name="請假取消申請單主管逾期未簽核通知", Subject="#APPLICANT#請假取消申請單主管逾期未簽核通知", Body=GetLeaveCancelOverDueBody(), Description=""},
                new MailTemplateEntity(){ Name="請假取消申請單已核准通知", Subject="#APPLICANT#請假取消申請單已核准通知:代理人#WORK_AGENT_NAME#", Body=GetLeaveCancelApproveBody(), Description=""},

                //請假申請
                new MailTemplateEntity(){ Name="請假申請單簽核通知", Subject="#APPLICANT#請假申請單簽核通知", Body=GetLeaveAlertBody(), Description=""},
                new MailTemplateEntity(){ Name="請假申請單退回通知", Subject="#APPLICANT#請假申請單退回通知#", Body=GetLeaveRejectBody(), Description=""},
                new MailTemplateEntity(){ Name="請假申請單主管逾期未簽核通知", Subject="#APPLICANT#請假申請單主管逾期未簽核通知", Body=GetLeaveOverDueBody(), Description=""},
                new MailTemplateEntity(){ Name="請假申請單已核准通知", Subject="#APPLICANT#請假申請單已核准通知:代理人#WORK_AGENT_NAME#", Body=GetLeaveApproveBody(), Description=""},
                new MailTemplateEntity(){ Name="請假申請單事假超休通知", Subject="#APPLICANT#請假申請單事假超過14天/年", Body=GetLeaveBussinessOverBody(), Description=""},
                new MailTemplateEntity(){ Name="請假申請單病假超休通知", Subject="#APPLICANT#請假申請單病假超過30天/年", Body=GetLeaveSickOverBody(), Description=""}

            };

            DataContext context = new DataContext();

            List<DbCommand> commList = new List<DbCommand>();

            //string sql = "delete MAIL_TEMPLATE where TEMPLATE_NAME like 'HR_%'";
            //DbCommand comm = context.DBase.GetSqlStringCommand(sql);
            //commList.Add(comm);

            list.ForEach(p => {

                DbCommand comm = p.GetDBCommand<MailTemplateEntity>(context.DBase, MailTemplateEntity.Insert);

                commList.Add(comm);

            });


            return context.SaveChange(commList);
        }

        private string GetLeaveSickOverBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            <tr><td><%APPLICANT%></td></tr>
                            <tr><td><%SICK_OVER_DATA%></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            <tr><td><a href=""<%BPMPORTAL_SITE%>/Portal/WFApplications/WFProcess_Form.aspx?WORK_ITEM_ID=<%WORK_ITEM_ID%>"">請點選此處進行處理</a></td></tr>
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetLeaveBussinessOverBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            <tr><td><%APPLICANT%></td></tr>
                            <tr><td><%BUSSINESS_OVER_DATA%></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            <tr><td><a href=""<%BPMPORTAL_SITE%>/Portal/WFApplications/WFProcess_Form.aspx?WORK_ITEM_ID=<%WORK_ITEM_ID%>"">請點選此處進行處理</a></td></tr>
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetLeaveApproveBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            
                            <tr><td>請假申請單已核准<br><%APPLICANT%><br>工作代理人<%WORK_AGENT_NAME%><br><%LEAVE_APPLY_DATA%></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetLeaveOverDueBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            <tr><td>此申請單需要您的審核，請盡速處理，謝謝。</td></tr>
                            <tr><td>請假申請單主管逾期未簽核<br><%APPLICANT%><br><%LEAVE_APPLY_DATA%></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            <tr><td><a href=""<%BPMPORTAL_SITE%>/Portal/WFApplications/WFProcess_Form.aspx?WORK_ITEM_ID=<%WORK_ITEM_ID%>"">請點選此處進行處理</a></td></tr>
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetLeaveRejectBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            
                            <tr><td>請假申請單不核准<br><%APPLICANT%><br><%LEAVE_APPLY_DATA%></td></tr>
                            
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetLeaveAlertBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            <tr><td>此申請單需要您的審核，請盡速處理，謝謝。</td></tr>
                            <tr><td>請假申請單簽核<br><%APPLICANT%><br><%LEAVE_APPLY_DATA%></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            <tr><td><a href=""<%BPMPORTAL_SITE%>/Portal/WFApplications/WFProcess_Form.aspx?WORK_ITEM_ID=<%WORK_ITEM_ID%>"">請點選此處進行處理</a></td></tr>
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetLeaveCancelApproveBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            
                            <tr><td>請假取消申請單已核准<br><%APPLICANT%><br>工作代理人<%WORK_AGENT_NAME%><br><%LEAVE_CANCEL_DATA%></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetLeaveCancelOverDueBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            <tr><td>此申請單需要您的審核，請盡速處理，謝謝。</td></tr>
                            <tr><td>請假取消申請單主管逾期未簽核<br><%APPLICANT%><br><%LEAVE_CANCEL_DATA%></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            <tr><td><a href=""<%BPMPORTAL_SITE%>/Portal/WFApplications/WFProcess_Form.aspx?WORK_ITEM_ID=<%WORK_ITEM_ID%>"">請點選此處進行處理</a></td></tr>
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetLeaveCancelRejectBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            
                            <tr><td>請假取消申請單不核准<br><%APPLICANT%><br><%LEAVE_CANCEL_DATA%></td></tr>
                            <tr><td>說明: <%REASON%></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetLeaveCancelAlertBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            <tr><td>此申請單需要您的審核，請盡速處理，謝謝。</td></tr>
                            <tr><td>請假取消申請單簽核<br><%APPLICANT%><br><%LEAVE_CANCEL_DATA%></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            <tr><td><a href=""<%BPMPORTAL_SITE%>/Portal/WFApplications/WFProcess_Form.aspx?WORK_ITEM_ID=<%WORK_ITEM_ID%>"">請點選此處進行處理</a></td></tr>
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetExtendLeaveAlertBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            <tr><td>此申請單需要您的審核，請盡速處理，謝謝。</td></tr>
                            <tr><td>延休申請單簽核<br><%APPLICANT%></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            <tr><td><a href=""<%BPMPORTAL_SITE%>/Portal/WFApplications/WFProcess_Form.aspx?WORK_ITEM_ID=<%WORK_ITEM_ID%>"">請點選此處進行處理</a></td></tr>
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetExtendLeaveRejectBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            
                            <tr><td>延休申請單不核准<br><%APPLICANT%></td></tr>
                            <tr><td>說明: 需為去年度工作上無法休假才能延休></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetExtendLeaveOverDueBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            <tr><td>此申請單需要您的審核，請盡速處理，謝謝。</td></tr>
                            <tr><td>延休申請單主管逾期未簽核<br><%APPLICANT%></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            <tr><td><a href=""<%BPMPORTAL_SITE%>/Portal/WFApplications/WFProcess_Form.aspx?WORK_ITEM_ID=<%WORK_ITEM_ID%>"">請點選此處進行處理</a></td></tr>
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetExtendLeaveApproveBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            
                            <tr><td>延休申請單已核准<br><%APPLICANT%><br>年度延休申請已核准, 系統已轉入</td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetOverTime46HoursBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            
                            <tr><td><%APPLICANT%>當月累計加班時數共計:<br><%OVERTIME_HOURS%>小時(包含加班費+轉換調休)</td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetOverTimeApproveBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            
                            <tr><td>加班申請單已核准<br><%APPLICANT%><br><%OVERTIME_DATA%></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetOverTimeOverDueBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            <tr><td>此申請單需要您的審核，請盡速處理，謝謝。</td></tr>
                            <tr><td>加班申請單主管逾期未簽核<br><%APPLICANT%><br><%OVERTIME_DATA%></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            <tr><td><a href=""<%BPMPORTAL_SITE%>/Portal/WFApplications/WFProcess_Form.aspx?WORK_ITEM_ID=<%WORK_ITEM_ID%>"">請點選此處進行處理</a></td></tr>
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetOverTimeRejectBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            
                            <tr><td>加班申請單不核准<br><%APPLICANT%><br><%OVERTIME_DATA%></td></tr>
                            <tr><td>說明: 時間不符, 請修改</td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetOverTimeAlertBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            <tr><td>此申請單需要您的審核，請盡速處理，謝謝。</td></tr>
                            <tr><td>加班申請單簽核<br><%APPLICANT%><br><%OVERTIME_DATA%></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            <tr><td><a href=""<%BPMPORTAL_SITE%>/Portal/WFApplications/WFProcess_Form.aspx?WORK_ITEM_ID=<%WORK_ITEM_ID%>"">請點選此處進行處理</a></td></tr>
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetVacationApproveBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            
                            <tr><td>年度休假計畫申請單已核准<br><%APPLICANT%></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetVacationOverDueBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            <tr><td>此申請單需要您的審核，請盡速處理，謝謝。</td></tr>
                            <tr><td>年度休假計畫申請單主管逾期未簽核<br><%APPLICANT%></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            <tr><td><a href=""<%BPMPORTAL_SITE%>/Portal/WFApplications/WFProcess_Form.aspx?WORK_ITEM_ID=<%WORK_ITEM_ID%>"">請點選此處進行處理</a></td></tr>
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetVacationRejectBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            
                            <tr><td>年度休假計畫申請單不核准<br><%APPLICANT%></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetVacationAlertBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            <tr><td>此申請單需要您的審核，請盡速處理，謝謝。</td></tr>
                            <tr><td>年度休假計畫申請單簽核<br><%APPLICANT%></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            <tr><td><a href=""<%BPMPORTAL_SITE%>/Portal/WFApplications/WFProcess_Form.aspx?WORK_ITEM_ID=<%WORK_ITEM_ID%>"">請點選此處進行處理</a></td></tr>
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        /// <summary>
        /// 彈性工時-簽核通知 Body內容
        /// </summary>
        /// <returns></returns>
        private string GetFlexTimeAlertBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            <tr><td>此申請單需要您的審核，請盡速處理，謝謝。</td></tr>
                            <tr><td>彈性工時申請單簽核<br><%APPLICANT%><br><%FLEX_TIME%></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            <tr><td><a href=""<%BPMPORTAL_SITE%>/Portal/WFApplications/WFProcess_Form.aspx?WORK_ITEM_ID=<%WORK_ITEM_ID%>"">請點選此處進行處理</a></td></tr>
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetFlexTimeRejectBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            
                            <tr><td>彈性工時申請單不核准<br><%APPLICANT%><br><%FLEX_TIME%></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetFlexTimeOverDueBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            <tr><td>此申請單需要您的審核，請盡速處理，謝謝。</td></tr>
                            <tr><td>彈性工時申請單主管逾期未簽核<br><%APPLICANT%><br><%FLEX_TIME%></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            <tr><td><a href=""<%BPMPORTAL_SITE%>/Portal/WFApplications/WFProcess_Form.aspx?WORK_ITEM_ID=<%WORK_ITEM_ID%>"">請點選此處進行處理</a></td></tr>
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }

        private string GetFlexTimeApproveBody()
        {
            string body = @"<html>
                            <style type=""text/css"">
                            <!--
                            .column{background-color:#DDDDDD;border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcolumn{background-color:#DDDDDD;border-bottom:1px solid #000000}
                            .cell{border-bottom:1px solid #000000;border-right:1px solid #000000}
                            .lastcell{border-bottom:1px solid #000000}
                            -->
                            </style>
                            <body>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px"">
                            <tr><td>您好,</td></tr>
                            
                            <tr><td>彈性工時申請單已核准<br><%APPLICANT%><br><%FLEX_TIME%></td></tr>
                            <tr><td>
                            <table cellspacing=""0"" cellpadding=""4"" style=""font-size:13px;border:1px solid #000000"">
                            <tr><td class=column style=""font-weight:bold"">表單編號</td><td class=lastcell><%FORM_NO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">摘要</td><td class=lastcell><%MEMO%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">申請人</td><td class=lastcell><%APPLICANT%></td></tr>
                            <tr><td class=column style=""font-weight:bold"">填單人</td><td class=lastcell><%PREPAREDBY_USER%></td></tr>
                            </table>
                            </td></tr>
                            
                            <tr><td style=""height:20px""></td></tr>
                            <tr><td>PRIMAX BPM 2.0</td></tr>
                            </table>
                            </body>
                            </html>";

            return body;
        }
    }
}
