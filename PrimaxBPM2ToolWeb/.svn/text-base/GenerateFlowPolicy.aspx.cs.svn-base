using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrimaxBPM2Library.Policy.Entity;
using Primax.Core.Helper;
using Primax.Core.Data;
using Primax.Core.Data.Extensions;
using System.IO;
using System.Data.Common;
using System.Data;

namespace PrimaxBPM2ToolWeb
{
    public partial class GenerateFlowPolicy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
            
            
            
        

        /// <summary>
        /// 產生北京的核決權限表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUTD3Policy_Click(object sender, EventArgs e)
        {
            //北京
            string path=Server.MapPath("~/Policy")+"\\CNleavePplocy.xml";
            
            GetLeavePolicy().ClassToXmlFile(path);

            //東聚
            string path2 = Server.MapPath("~/Policy") + "\\CNPCH2Pplocy.xml";

            GetPCH2LeavePolicy().ClassToXmlFile(path2);

            //廣州
            string path3 = Server.MapPath("~/Policy") + "\\CNPCH2Pplocy2.xml";

            GetPCH2LeavePolicy2().ClassToXmlFile(path3);
        }

        private PolicyEntity GetLeavePolicy()
        {

            PolicyEntity policy = new PolicyEntity()
            {
                RuleEngine = new RuleEngineEntity()
                {
                    Rules = new RulesEntity() { RuleList = new List<RuleEntity>() { 
                        new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"P\")==0"),
                               Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                        new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="DAYS",Text="0"}
                                        }
                                     }
                               }},
                       new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)<=5"),
                               Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                        new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="DAYS",Text="0"}
                                        }
                                     }
                               }},
                       new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=6 && #RANK#.substr(1)<=8"),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="DAYS",Text="1"}
                                }
                             }
                       }},
                       new RuleEntity(){Condition=new CDATA("#RANK#==\"L9\""),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="DAYS",Text="2"}
                                }
                             }
                       }},
                       new RuleEntity(){Condition=new CDATA("#RANK#==\"L10\""),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="DAYS",Text="9"}
                                }
                             }
                       }},
                       new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=11"),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="DAYS",Text=""}
                                }
                             }
                       }}

                    } },
                    Parameters = new ParametersEntity()
                    {
                        ParameterList = new List<ParameterEntity>() {
                            new ParameterEntity(){Id="RANK",Binding="USER.RANK",Display="職級",Value="0",ValueType="string"},
                            new ParameterEntity(){Id="DAYS",Binding="$LEAVE_DAYS",Display="請假天數",Value="0",ValueType="decimal"}
                        }
                    }
                }
            };

            return policy;
        }

        /// <summary>
        /// 新增北京的Policy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInsertCNLeave_Click(object sender, EventArgs e)
        {
            int No = NextNumber();

            DataContext context = new DataContext();

            List<DbCommand> commList = new List<DbCommand>();

            //Step1 北京
            string path = Server.MapPath("~/Policy") + "\\CNleavePplocy.xml";

            BussinessPolicy policy = new BussinessPolicy() {
                SystemID = 2,
                PolicyName = "職級休假天數權限檢核",
                OrgID = "UTD3",MajorVersion=1, MinorVersion=0,
                BRML=GetPolicyXmlString(path),
                PolicyId = No
            };

            DbCommand comm = policy.GetDBCommand<BussinessPolicy>(context.DBase, BussinessPolicy.Insert);

            commList.Add(comm);

            //東聚
            path = Server.MapPath("~/Policy") + "\\CNPCH2Pplocy.xml";

            policy = new BussinessPolicy()
            {
                SystemID = 2,
                PolicyName = "職級休假天數權限檢核",
                OrgID = "PCH2",
                MajorVersion = 1,
                MinorVersion = 0,
                BRML = GetPolicyXmlString(path),
                PolicyId = No+1
            };

            comm = policy.GetDBCommand<BussinessPolicy>(context.DBase, BussinessPolicy.Insert);

            commList.Add(comm);
            //昆山
            path = Server.MapPath("~/Policy") + "\\CNPCH2Pplocy.xml";

            policy = new BussinessPolicy()
            {
                SystemID = 2,
                PolicyName = "職級休假天數權限檢核",
                OrgID = "PKS1",
                MajorVersion = 1,
                MinorVersion = 0,
                BRML = GetPolicyXmlString(path),
                PolicyId = No+2
            };

            comm = policy.GetDBCommand<BussinessPolicy>(context.DBase, BussinessPolicy.Insert);

            commList.Add(comm);

            //廣州
            path = Server.MapPath("~/Policy") + "\\CNPCH2Pplocy2.xml";

            policy = new BussinessPolicy()
            {
                SystemID = 2,
                PolicyName = "廣州職級休假天數權限檢核",
                OrgID = "PCH2",
                MajorVersion = 1,
                MinorVersion = 0,
                BRML = GetPolicyXmlString(path),
                PolicyId =No+3
            };

            comm = policy.GetDBCommand<BussinessPolicy>(context.DBase, BussinessPolicy.Insert);

            commList.Add(comm);

            if (context.SaveChange(commList))
            {
                lbMsg1.Text = "Insert Success";
            }
            else
            {
                lbMsg1.Text = "Insert Fail";
            }
            
        }

        public string GetPolicyXmlString(string path)
        {
            string bpml = "";

            using (StreamReader sr = new StreamReader(path))
            {
                bpml = sr.ReadToEnd();
            }

            return bpml;
        }

        private int NextNumber()
        {
            int no = 0;

            string sql = "select Max(BUSINESS_POLICY_ID)+1 as No from BUSINESS_POLICY";

            DataContext context = new DataContext();

            DataTable dt = context.QuerySelect(sql);

            if (dt.Rows.Count > 0)
            {
                no =Convert.ToInt16(dt.Rows[0]["No"]);
            }

            return no;
        }

       

        /// <summary>
        /// 取得東聚/昆山的核決權限表
        /// </summary>
        /// <returns></returns>
        private PolicyEntity GetPCH2LeavePolicy()
        {

            PolicyEntity policy = new PolicyEntity()
            {
                RuleEngine = new RuleEngineEntity()
                {
                    Rules = new RulesEntity()
                    {
                        RuleList = new List<RuleEntity>() { 
                        new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"P\")==0"),
                               Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                        new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="DAYS",Text="0"}
                                        }
                                     }
                               }},
                       new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)<=5"),
                               Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                        new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="DAYS",Text="0"}
                                        }
                                     }
                               }},
                       new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=6 && #RANK#.substr(1)<=8 && #APPLICANT_RANK#.indexOf(\"P\")==0 && #APPLICANT_RANK#.substr(1)<=5"),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="DAYS",Text="2"}
                                }
                             }
                       }},
                       new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=6 && #RANK#.substr(1)<=8 && #APPLICANT_RANK#.indexOf(\"L\")==0 && #APPLICANT_RANK#.substr(1)<=5"),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="DAYS",Text="2"}
                                }
                             }
                       }},
                       new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=9 && #RANK#.substr(1)<=10 && #APPLICANT_RANK#.indexOf(\"P\")==0 && #APPLICANT_RANK#.substr(1)>=6"),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="DAYS",Text="2"}
                                }
                             }
                       }},
                        new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=9 && #RANK#.substr(1)<=10 && #APPLICANT_RANK#.indexOf(\"L\")==0 && #APPLICANT_RANK#.substr(1)>=6"),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="DAYS",Text="2"}
                                }
                             }
                       }},
                        new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=9 && #RANK#.substr(1)<=11 && #APPLICANT_RANK#.indexOf(\"P\")==0 && #APPLICANT_RANK#.substr(1)<=5"),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="DAYS",Text=""}
                                }
                             }
                       }},
                       new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=9 && #RANK#.substr(1)<=11 && #APPLICANT_RANK#.indexOf(\"L\")==0 && #APPLICANT_RANK#.substr(1)<=5"),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="DAYS",Text=""}
                                }
                             }
                       }},
                       new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=12 && #RANK#.substr(1)<=13 && #APPLICANT_RANK#.indexOf(\"P\")==0 && #APPLICANT_RANK#.substr(1)>=6"),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="DAYS",Text=""}
                                }
                             }
                       }},
                        new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=12 && #RANK#.substr(1)<=13 && #APPLICANT_RANK#.indexOf(\"L\")==0 && #APPLICANT_RANK#.substr(1)>=6"),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="DAYS",Text=""}
                                }
                             }
                       }}
                      
                       

                    }
                    },
                    Parameters = new ParametersEntity()
                    {
                        ParameterList = new List<ParameterEntity>() {
                            new ParameterEntity(){Id="APPLICANT_RANK",Binding="$APPLICANT_RANK",Display="申請人職級",Value="0",ValueType="string"},
                            new ParameterEntity(){Id="RANK",Binding="USER.RANK",Display="職級",Value="0",ValueType="string"},
                            new ParameterEntity(){Id="DAYS",Binding="$LEAVE_DAYS",Display="請假天數",Value="0",ValueType="decimal"}
                        }
                    }
                }
            };

            return policy;
        }

        /// <summary>
        /// 廣州的核決權限表
        /// </summary>
        /// <returns></returns>
        private PolicyEntity GetPCH2LeavePolicy2()
        {

            PolicyEntity policy = new PolicyEntity()
            {
                RuleEngine = new RuleEngineEntity()
                {
                    Rules = new RulesEntity()
                    {
                        RuleList = new List<RuleEntity>() { 
                        new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"P\")==0"),
                               Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                        new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="DAYS",Text="0"}
                                        }
                                     }
                               }},
                       new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)<=5"),
                               Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                        new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="DAYS",Text="0"}
                                        }
                                     }
                               }},
                       new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=6 && #RANK#.substr(1)<=8"),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="DAYS",Text="2"}
                                }
                             }
                       }},
                      
                        new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)==11" ),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="DAYS",Text=""}
                                }
                             }
                       }}                      
      
                    }
                    },
                    Parameters = new ParametersEntity()
                    {
                        ParameterList = new List<ParameterEntity>() {
                            new ParameterEntity(){Id="RANK",Binding="USER.RANK",Display="職級",Value="0",ValueType="string"},
                            new ParameterEntity(){Id="DAYS",Binding="$LEAVE_DAYS",Display="請假天數",Value="0",ValueType="decimal"}
                        }
                    }
                }
            };

            return policy;
        }

       
       
    }
}
