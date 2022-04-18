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
    public partial class TaiwanPolicy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnClick_Click(object sender, EventArgs e)
        {
            SqlRuleStore store = new SqlRuleStore();
            Primax.Foundation.Components.RuleEngine.RuleSet ruleset = null;
            RuleEngine engine = null;
             ruleset = store.GetRuleSet("PTW2", "職級休假天數權限檢核");

             RuleSet myRuleSet = new RuleSet(ruleset.Name, ruleset.Rules.InnerXml);

            decimal num3 = Convert.ToDecimal(tbLeaveDays.Text);
            decimal num4 = 0M;

            string name = "LEAVE_DAYS";


            if (myRuleSet != null)
            {
                engine = new RuleEngine(myRuleSet);
                foreach (XmlNode node in engine.RuleSet.Rules.SelectNodes("//PARAMETERS/PARAMETER"))
                {
                    string id = node.Attributes["ID"].Value;

                    switch (id)
                    {
                        case "APPLICANT":
                            node.Attributes["VALUE"].Value = tbApplicant.Text;
                            break;
                        case "PERSON_ID":
                            node.Attributes["VALUE"].Value = tbPersonId.Text;
                            break;
                        //case "LEAVE_DAYS":
                        //    node.Attributes["VALUE"].Value =Convert.ToInt16("0") ;
                        //    break;
                        case "BU_HEAD":
                            node.Attributes["VALUE"].Value = tbBUHead.Text;
                            break;
                        case "ORG_HEAD":
                            node.Attributes["VALUE"].Value = tbOrgHead.Text;
                            break;
                        case "CEO":
                            node.Attributes["VALUE"].Value =tbCEO.Text ;

                            break;
                        case "SEQUENTIAL_CURRENT_INDEX":
                            node.Attributes["VALUE"].Value = tbCurrent.Text;
                            break;
                        case "IS_ORG_BOSS":
                            node.Attributes["VALUE"].Value = tbIsOrgBoss.Text;
                            break;

                    }

                }

                engine.Execute();

                object vv = engine.RuleSet.Rules.SelectSingleNode("//PARAMETERS/PARAMETER[@ID='" + name + "']").Attributes["VALUE"].Value;

                lbMsg.Text = "BBB=" + vv.ToString();



            }
        }
    }
}
