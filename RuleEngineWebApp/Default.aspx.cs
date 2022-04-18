using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Primax.Foundation.Components.RuleEngine;
using System.Xml;


namespace RuleEngineWebApp
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int x = 2;
            int y = 3;

        }

        public Func<int, int, int> Opp;



        /// <summary>
        /// 測試核決權限表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClick_Click(object sender, EventArgs e)
        {
            //SqlRuleStore store = new SqlRuleStore();
            //RuleSet ruleset = null;
            //Primax.Foundation.Components.RuleEngine.RuleEngine engine = null;
            //ruleset = store.GetRuleSet("PCH2", "職級休假天數權限檢核");

            //decimal num3 = Convert.ToDecimal(tbDays.Text);
            //decimal num4 = 0M;

            //string name = "LEAVE_DAYS";


            //if (ruleset != null)
            //{
            //    engine = new Primax.Foundation.Components.RuleEngine.RuleEngine(ruleset);
            //    foreach (XmlNode node in engine.RuleSet.Rules.SelectNodes("//PARAMETERS/PARAMETER"))
            //    {
            //        if (node.Attributes["BINDING"].Value != "")
            //        {
            //            if (node.Attributes["BINDING"].Value.IndexOf(".") > 0)
            //            {
            //                string[] strArray2 = node.Attributes["BINDING"].Value.Split(".".ToCharArray());

            //                if (strArray2[0].ToUpper() == "USER")
            //                {

            //                    node.Attributes["VALUE"].Value = tbRank.Text;
            //                }
            //            }
            //            else if (node.Attributes["BINDING"].Value.StartsWith("$"))
            //            {


            //                node.Attributes["VALUE"].Value = tbApplicantRank.Text;

            //            }
            //        }
            //    }

            //    engine.Execute();

            //    object vv = engine.RuleSet.Rules.SelectSingleNode("//PARAMETERS/PARAMETER[@ID='" + name + "']").Attributes["VALUE"].Value;

            //    lbResultMsg.Text = "BBB=" + vv.ToString();



            //}

        }

        /// <summary>
        /// 測試大陸加班的核決權限表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnChcek_Click(object sender, EventArgs e)
        {
            //SqlRuleStore store = new SqlRuleStore();
            //RuleSet ruleset = null;
            //Primax.Foundation.Components.RuleEngine.RuleEngine engine = null;
            //switch (Convert.ToInt16(rdlZone.SelectedValue))
            //{
            //    case 1: //北京
            //        ruleset = store.GetRuleSet("UTD3", "職級加班天數權限檢核");
            //        break;
            //    case 2: //廣州
            //        ruleset = store.GetRuleSet("PCH2", "廣州職級加班天數權限檢核");
            //        break;
            //    case 3: //東聚
            //        ruleset = store.GetRuleSet("PCH2", "職級加班天數權限檢核");
            //        break;
            //    case 4: //昆山
            //        ruleset = store.GetRuleSet("PKS1", "職級加班天數權限檢核");
            //        break;
            //}



            //string name = "COMPARED_VALUE";


            //if (ruleset != null)
            //{
            //    engine = new Primax.Foundation.Components.RuleEngine.RuleEngine(ruleset);
            //    foreach (XmlNode node in engine.RuleSet.Rules.SelectNodes("//PARAMETERS/PARAMETER"))
            //    {
            //        if (node.Attributes["BINDING"].Value != "")
            //        {
            //            if (node.Attributes["BINDING"].Value.IndexOf(".") > 0)
            //            {
            //                string[] strArray2 = node.Attributes["BINDING"].Value.Split(".".ToCharArray());

            //                if (strArray2[0].ToUpper() == "USER")
            //                {

            //                    node.Attributes["VALUE"].Value = tbRankText.Text;
            //                }
            //            }
            //            else if (node.Attributes["BINDING"].Value.StartsWith("$"))
            //            {

            //                //加上權限
            //                node.Attributes["VALUE"].Value = rdlOverTimeType.SelectedValue;

            //            }
            //        }
            //    }

            //    engine.Execute();

            //    object vv = engine.RuleSet.Rules.SelectSingleNode("//PARAMETERS/PARAMETER[@ID='" + name + "']").Attributes["VALUE"].Value;

            //    lbCNMsg.Text = "Value=" + vv.ToString();
            //}
        }

        protected void btnLeaveDays_Click(object sender, EventArgs e)
        {
            //Dictionary<string, string> dicList = new Dictionary<string, string>();

            ////dicList.Add("COMPARED_VALUE", SeqIndex.Text);
            //dicList.Add("LEAVE_DAYS", LeaveDays.Text);
            //dicList.Add("APPLICANT", Applicant.Text);
            
            //dicList.Add("BU_HEAD", BUHead.Text);
            //dicList.Add("CEO", CEO.Text);
            //dicList.Add("PERSON_ID", PersonID.Text);

            //SqlRuleStore store = new SqlRuleStore();
            //RuleSet ruleset = ruleset = store.GetRuleSet("PTW2", "職級休假天數權限檢核");
            //Primax.Foundation.Components.RuleEngine.RuleEngine engine = null;

            //string name = "COMPARED_VALUE";


            //if (ruleset != null)
            //{
            //    engine = new Primax.Foundation.Components.RuleEngine.RuleEngine(ruleset);
            //    foreach (XmlNode node in engine.RuleSet.Rules.SelectNodes("//PARAMETERS/PARAMETER"))
            //    {
            //        if (node.Attributes["ID"].Value != "COMPARED_VALUE")
            //        {
            //            node.Attributes["VALUE"].Value = dicList[node.Attributes["ID"].Value];
            //        }
                    

            //        //if (node.Attributes["BINDING"].Value != "")
            //        //{
            //        //    if (node.Attributes["BINDING"].Value.IndexOf(".") > 0)
            //        //    {
            //        //        string[] strArray2 = node.Attributes["BINDING"].Value.Split(".".ToCharArray());

            //        //        if (strArray2[0].ToUpper() == "USER")
            //        //        {

            //        //            node.Attributes["VALUE"].Value = tbRankText.Text;
            //        //        }
            //        //    }
            //        //    else if (node.Attributes["BINDING"].Value.StartsWith("$"))
            //        //    {

            //        //        //加上權限
            //        //        node.Attributes["VALUE"].Value = ;

            //        //    }
            //        //}
            //    }

            //    engine.Execute();

            //    object vv = engine.RuleSet.Rules.SelectSingleNode("//PARAMETERS/PARAMETER[@ID='" + name + "']").Attributes["VALUE"].Value;

            //    txtTWMsg.Text = "Value=" + vv.ToString();


            //}
        }
    }
}
