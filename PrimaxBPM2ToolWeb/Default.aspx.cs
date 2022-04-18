using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Primax.Core.Helper;
using PrimaxBPM2Library.Flow.Entity;
using PrimaxBPM2Library.Flow.Logic;
using PrimaxBPM2Library.Policy.Entity;
using System.Web.Services;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
using Primax.Core.Data;
using System.Data.Common;

namespace PrimaxBPM2ToolWeb
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                BindInitControl();

                BindInitControl2();
            }
        }

       

        protected void btnFlowClick_Click(object sender, EventArgs e)
        {
            if (ddlFlowList.SelectedValue != "")
            {
                string path = Server.MapPath("~/xml") + "\\" + ddlFlowList.SelectedValue;

                FlowsEntity flows = path.XMLFileToClass<FlowsEntity>();

                FlowLogic logic = new FlowLogic();

                string msg = ddlFlowList.SelectedItem.Text;

                if (logic.SaveChangeFlow(flows))
                {
                    msg += "建立";
                }
                else
                {
                    msg += "失敗";
                }

                lbFlowMsg.Text = msg;
            }
            else
            {
                lbFlowMsg.Text = "請選擇流程資料";
            }
        }

        private void BindInitControl()
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

            string path = Server.MapPath("~/xml");

            foreach (string s in Directory.GetFiles(path, "*.xml"))
            {
                string fileName = Path.GetFileName(s);

                list.Add(new KeyValuePair<string, string>(fileName, fileName));
            }

            ddlFlowList.DataSource = list;
            ddlFlowList.DataTextField = "Key";
            ddlFlowList.DataValueField = "Value";
            ddlFlowList.DataBind();

            ddlFlowList.Items.Insert(0, new ListItem("------", ""));
        }

        private void BindInitControl2()
        {
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();

            string path = Server.MapPath("~/xml2");

            foreach (string s in Directory.GetFiles(path, "*.xml"))
            {
                string fileName = Path.GetFileName(s);

                list.Add(new KeyValuePair<string, string>(fileName, fileName));
            }
            
            ddlFlowList2.DataSource = list;
            ddlFlowList2.DataTextField = "Key";
            ddlFlowList2.DataValueField = "Value";
            ddlFlowList2.DataBind();

            ddlFlowList.Items.Insert(0, new ListItem("------", ""));
        }

        protected void btnFlow2_Click(object sender, EventArgs e)
        {
            if (ddlFlowList.SelectedValue != "")
            {
                string path = Server.MapPath("~/xml2") + "\\" + ddlFlowList2.SelectedValue;

                FlowsEntity flows = path.XMLFileToClass<FlowsEntity>();

                FlowLogic logic = new FlowLogic();

                string msg = ddlFlowList.SelectedItem.Text;

                if (logic.SaveChangeFlow(flows))
                {
                    msg += "建立";
                }
                else
                {
                    msg += "失敗";
                }

                lbMsg2.Text = msg;
            }
            else
            {
                lbMsg2.Text = "請選擇流程資料";
            }
        }

      

       

        
    }

  

}
