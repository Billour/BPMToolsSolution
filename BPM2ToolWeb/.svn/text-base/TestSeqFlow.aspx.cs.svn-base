using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Primax.Portal.BusinessLayer;
using Primax.Foundation.Components.Workflow;
using System.Collections.Generic;
using Primax.Foundation;
using System.Data;
using System.Reflection;
using System.Xml;
using Primax.Foundation.Components.RuleEngine;
using System.Collections;
using Primax.Foundation.Components;
using PrimaxBPM2Library.Flow.Entity;
using PrimaxBPM2Library.Flow.Logic;

namespace BPM2ToolWeb
{
    public partial class TestSeqFlow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 產生流程的人員列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClick_Click(object sender, EventArgs e)
        {
            string accountId = tbPersonId.Text;

            string policyName = tbPolicy.Text;

            WorkFlowLogic logic=new WorkFlowLogic();

            List<FlowPersonEntity> list = logic.GetSeqFlow(accountId, policyName);

            GridView1.DataSource = list;
            GridView1.DataBind();
        }
    }
}
