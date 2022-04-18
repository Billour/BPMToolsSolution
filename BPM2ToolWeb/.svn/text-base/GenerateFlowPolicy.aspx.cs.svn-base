using System;
using System.Collections.Generic;
using System.Linq;
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
using PrimaxBPM2Library.Extensions;
using PrimaxBPM2Library.Config;


namespace BPM2ToolWeb
{
    /// <summary>
    /// Generate Policy For BPM HR 
    /// </summary>
    public partial class GenerateFlowPolicy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 取得DB Key 值
        /// </summary>
        /// <returns></returns>
        private string DBKey()
        {
            return  ddlPlatform.SelectedValue.GetPortalDB();
        }

        /// <summary>
        /// Get Taiwan Leave Policy
        /// </summary>
        /// <returns></returns>
        private PolicyEntity GetPTWLeavePolicy()
        {
            PolicyEntity policy = new PolicyEntity()
            {
                RuleEngine = new RuleEngineEntity()
                {
                    Rules = new RulesEntity()
                    {
                        RuleList = new List<RuleEntity>() { 
                            new RuleEntity(){Condition=new CDATA(" #APPLICANT#==#CEO# "),
                               Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                        new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text="1000"}
                                        }
                                     }
                               }},
                           new RuleEntity(){Condition=new CDATA(" #APPLICANT#==#BU_HEAD# "),
                               Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                        new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text="1000"}
                                        }
                                     }
                               }},
                            new RuleEntity(){Condition=new CDATA(" #APPLICANT#==#ORG_HEAD# && #APPLICANT#==#BU_HEAD# "),
                               Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                        new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text="1000"}
                                        }
                                     }
                               }},
                            new RuleEntity(){Condition=new CDATA(" #APPLICANT#==#ORG_HEAD# && #APPLICANT#!=#BU_HEAD# && #PERSON_ID#!=#BU_HEAD#"),
                               Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                        new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text="9.99999"}
                                        }
                                     }
                               }},
                           new RuleEntity(){Condition=new CDATA(" #APPLICANT#==#ORG_HEAD# && #APPLICANT#!=#BU_HEAD# && #PERSON_ID#==#BU_HEAD#"),
                               Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                        new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text="1000"}
                                        }
                                     }
                               }},
                           new RuleEntity(){Condition=new CDATA(" #APPLICANT#!=#ORG_HEAD# && #PERSON_ID#!=#BU_HEAD#"),
                               Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                        new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text="9.99999"}
                                        }
                                     }
                               }},
                           new RuleEntity(){Condition=new CDATA(" #APPLICANT#!=#ORG_HEAD# && #PERSON_ID#==#BU_HEAD#"),
                               Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                        new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text="1000"}
                                        }
                                     }
                               }}
             
                    }
                    },
                    Parameters = new ParametersEntity()
                    {
                        ParameterList = new List<ParameterEntity>() {
                            new ParameterEntity(){Id="APPLICANT",Binding="$APPLICANT",Display="申請人",Value="",ValueType="string"},
                            new ParameterEntity(){Id="PERSON_ID",Binding="USER.PERSON_ID",Display="員工編號",Value="",ValueType="string"},
                            new ParameterEntity(){Id="LEAVE_DAYS",Binding="",Display="請假天數",Value="0",ValueType="decimal"},
                            new ParameterEntity(){Id="BU_HEAD",Binding="$BU_HEAD",Display="BU Head",Value="0",ValueType="string"},
                            new ParameterEntity(){Id="ORG_HEAD",Binding="$ORG_HEAD",Display="ORG Head",Value="",ValueType="string"},
                            new ParameterEntity(){Id="CEO",Binding="$CEO",Display="CEO",Value="",ValueType="string"},
                            new ParameterEntity(){Id="SEQUENTIAL_CURRENT_INDEX",Binding="$SEQUENTIAL_CURRENT_INDEX",Display="Current Index",Value="0",ValueType="integer"},
                            new ParameterEntity(){Id="IS_ORG_BOSS",Binding="$IS_ORG_BOSS",Display="是否為組織主管",Value="0",ValueType="decimal"},
                        }
                    }
                }
            };

            return policy;
        }

        /// <summary>
        /// Get CN Leave Policy
        /// </summary>
        /// <returns></returns>
        private PolicyEntity GetLeavePolicy()
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
                                        new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text="0"}
                                        }
                                     }
                               }},
                       new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)<=5"),
                               Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                        new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text="0"}
                                        }
                                     }
                               }},
                       new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=6 && #RANK#.substr(1)<=8"),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text="1"}
                                }
                             }
                       }},
                       new RuleEntity(){Condition=new CDATA("#RANK#==\"L9\""),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text="2"}
                                }
                             }
                       }},
                       new RuleEntity(){Condition=new CDATA("#RANK#==\"L10\""),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text="9"}
                                }
                             }
                       }},
                       new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=11"),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text="10"}
                                }
                             }
                       }}

                    }
                    },
                    Parameters = new ParametersEntity()
                    {
                        ParameterList = new List<ParameterEntity>() {
                            new ParameterEntity(){Id="RANK",Binding="USER.RANK",Display="職級",Value="0",ValueType="string"},
                            new ParameterEntity(){Id="LEAVE_DAYS",Binding="",Display="請假天數",Value="0",ValueType="decimal"}
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

            DataContext context = new DataContext(DBKey());
            DbCommand comm;
            List<DbCommand> commList = new List<DbCommand>();
            string path = "";
            //台灣
            path = Server.MapPath("~/Policy") + "\\PTW2LeavePolicy.xml";

            BussinessPolicy policy = new BussinessPolicy()
            {
                SystemID = 2,
                PolicyName = "事業處主管核決1",
                OrgID = "PTW2",
                MajorVersion = 1,
                MinorVersion = 0,
                BRML = GetPolicyXmlString(path),
                PolicyId = No
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

            DataContext context = new DataContext(DBKey());

            DataTable dt = context.QuerySelect(sql);

            if (dt.Rows.Count > 0)
            {
                no = Convert.ToInt16(dt.Rows[0]["No"]);
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
                                        new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text="0"}
                                        }
                                     }
                               }},
                       new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)<=5"),
                               Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                        new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text="0"}
                                        }
                                     }
                               }},
                    
                       new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=6 && #RANK#.substr(1)<=8 && #APPLICANT_RANK#.substr(1)<=5"),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text="2.99"}
                                }
                             }
                       }},
                       new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=9 && #RANK#.substr(1)<=10 && #APPLICANT_RANK#.substr(1)>=6"),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text="2.99"}
                                }
                             }
                       }},
                        new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1) >= 9 && #RANK#.substr(1) <= 10 && #APPLICANT_RANK#.substr(1)<=5"),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true ,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text="1000"}
                                }
                             }
                       }},
                       new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0  && #RANK#.substr(1) >= 11 && #RANK#.substr(1) <= 13  && #APPLICANT_RANK#.substr(1)>=6"),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true ,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text="1000"}
                                }
                             }
                       }}

                    }
                    },
                    Parameters = new ParametersEntity()
                    {
                        ParameterList = new List<ParameterEntity>() {
                            new ParameterEntity(){Id="APPLICANT_RANK",Binding="$APPLICANT_RANK",Display="申請人職級",Value="",ValueType="string"},
                            new ParameterEntity(){Id="RANK",Binding="USER.RANK",Display="職級",Value="0",ValueType="string"},
                            new ParameterEntity(){Id="LEAVE_DAYS",Binding="",Display="請假天數",Value="0",ValueType="decimal"}
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
                                        new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text="0"}
                                        }
                                     }
                               }},
                       new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)<=5"),
                               Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                        new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text="0"}
                                        }
                                     }
                               }},
                       new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=6 && #RANK#.substr(1)<=8"),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text="3"}
                                }
                             }
                       }},
                      
                        new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)==11" ),
                       Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="LEAVE_DAYS",Text=""}
                                }
                             }
                       }}                      
      
                    }
                    },
                    Parameters = new ParametersEntity()
                    {
                        ParameterList = new List<ParameterEntity>() {
                            new ParameterEntity(){Id="RANK",Binding="USER.RANK",Display="職級",Value="0",ValueType="string"},
                            new ParameterEntity(){Id="LEAVE_DAYS",Binding="",Display="請假天數",Value="0",ValueType="decimal"}
                        }
                    }
                }
            };

            return policy;
        }

        /// <summary>
        /// 產生大陸請假/加班的核決權限表XML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCNPolicyXML_Click(object sender, EventArgs e)
        {
            //大陸核決權限表
            //北京請假
            string path = Server.MapPath("~/Policy") + "\\CNleavePplocy.xml";

            GetLeavePolicy().ClassToXmlFile(path);

            //東聚請假
            string path2 = Server.MapPath("~/Policy") + "\\CNPCH2Pplocy.xml";

            GetPCH2LeavePolicy().ClassToXmlFile(path2);

            //廣州請假
            string path3 = Server.MapPath("~/Policy") + "\\CNPCH2Pplocy2.xml";

            GetPCH2LeavePolicy2().ClassToXmlFile(path3);

            //大陸北京加班核決權限表
            path = Server.MapPath("~/Policy") + "\\CNUTD3OverTimePolicy.xml";

            path.ToPolicyXml<PolicyEntity>(() =>
            { 
                
                PolicyEntity policy = new PolicyEntity()
                {
                    RuleEngine = new RuleEngineEntity()
                    {
                        Rules = new RulesEntity()
                        {
                            RuleList = new List<RuleEntity>() { 
                                new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=9 && #RANK#.substr(1)<=11"),
                                   Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                            new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="COMPARED_VALUE",Text="0"}
                                            }
                                         }
                                   }},
                                new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>11"),
                                   Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                            new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="COMPARED_VALUE",Text="1"}
                                            }
                                         }
                                   }}

                        }
                        },
                        Parameters = new ParametersEntity()
                        {
                            ParameterList = new List<ParameterEntity>() {
                                new ParameterEntity(){Id="RANK",Binding="USER.RANK",Display="職級",Value="0",ValueType="string"},
                                new ParameterEntity(){Id="COMPARED_VALUE",Binding="",Display="比較值",Value="-1",ValueType="decimal"}
                            }
                        
                        }
                    }
                };

                return policy;
                
            });

            //廣州加班申請核決權限表    
            path = Server.MapPath("~/Policy") + "\\CNPCH2OverTimePolicy2.xml";

            path.ToPolicyXml<PolicyEntity>(() =>
            {

                PolicyEntity policy = new PolicyEntity()
                {
                    RuleEngine = new RuleEngineEntity()
                    {
                        Rules = new RulesEntity()
                        {
                            RuleList = new List<RuleEntity>() { 
                                new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=6 && #RANK#.substr(1)<=8 && #OVER_TIME_TYPE#==\"WEEKDAY\""),
                                   Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                            new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="COMPARED_VALUE",Text="0"}
                                            }
                                         }
                                   }},
                                new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=9 && #OVER_TIME_TYPE#==\"WEEKDAY\""),
                                   Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                            new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="COMPARED_VALUE",Text="1"}
                                            }
                                         }
                                   }},
                                new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=6 && #RANK#.substr(1)<=9 && #OVER_TIME_TYPE#==\"HOLIDAY\""),
                                   Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                            new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="COMPARED_VALUE",Text="0"}
                                            }
                                         }
                                   }},
                                new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=10 && #OVER_TIME_TYPE#==\"HOLIDAY\""),
                                   Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                            new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="COMPARED_VALUE",Text="1"}
                                            }
                                         }
                                   }},
                                new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=6 && #RANK#.substr(1)<=11 && #OVER_TIME_TYPE#==\"NATIONAL\""),
                                   Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                            new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="COMPARED_VALUE",Text="0"}
                                            }
                                         }
                                   }},
                                new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=12  && #OVER_TIME_TYPE#==\"NATIONAL\""),
                                   Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                            new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="COMPARED_VALUE",Text="1"}
                                            }
                                         }
                                   }}

                        }
                        },
                        Parameters = new ParametersEntity()
                        {
                            ParameterList = new List<ParameterEntity>() {
                                new ParameterEntity(){Id="RANK",Binding="USER.RANK",Display="職級",Value="0",ValueType="string"},
                                new ParameterEntity(){Id="COMPARED_VALUE",Binding="",Display="比較值",Value="-1",ValueType="decimal"},
                                new ParameterEntity(){Id="OVER_TIME_TYPE",Binding="$OVER_TIME_TYPE",Display="加班類型",Value="",ValueType="string"}

                            }

                        }
                    }
                };

                return policy;

            });

            //東聚/昆山的加班申請
            path = Server.MapPath("~/Policy") + "\\CNPCH2OverTimePolicy.xml";

            path.ToPolicyXml<PolicyEntity>(() =>
            {

                PolicyEntity policy = new PolicyEntity()
                {
                    RuleEngine = new RuleEngineEntity()
                    {
                        Rules = new RulesEntity()
                        {
                            RuleList = new List<RuleEntity>() { 
                                new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=6 && #RANK#.substr(1)<=8 && #OVER_TIME_TYPE#==\"WEEKDAY\""),
                                   Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                            new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="COMPARED_VALUE",Text="0"}
                                            }
                                         }
                                   }},
                                 new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=9 && #OVER_TIME_TYPE#==\"WEEKDAY\""),
                                   Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                            new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="COMPARED_VALUE",Text="1"}
                                            }
                                         }
                                   }},
                                new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=6 && #RANK#.substr(1)<=10 && #OVER_TIME_TYPE#==\"HOLIDAY\""),
                                   Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                            new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="COMPARED_VALUE",Text="0"}
                                            }
                                         }
                                   }},
                                new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=11 && #OVER_TIME_TYPE#==\"HOLIDAY\""),
                                   Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                            new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="COMPARED_VALUE",Text="1"}
                                            }
                                         }
                                   }},
                                new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=6 && #RANK#.substr(1)<=13 && #OVER_TIME_TYPE#==\"NATIONAL\""),
                                   Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                            new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="COMPARED_VALUE",Text="0"}
                                            }
                                         }
                                   }},
                                 new RuleEntity(){Condition=new CDATA("#RANK#.indexOf(\"L\")==0 && #RANK#.substr(1)>=14 && #OVER_TIME_TYPE#==\"NATIONAL\""),
                                   Actions=new ActionsEntity(){ActionList=new List<ActionEntity>(){
                                            new ActionEntity(){Result=true,Expression=new ExpressionEntity(){Parameter="COMPARED_VALUE",Text="1"}
                                            }
                                         }
                                   }}

                        }
                        },
                        Parameters = new ParametersEntity()
                        {
                            ParameterList = new List<ParameterEntity>() {
                                new ParameterEntity(){Id="RANK",Binding="USER.RANK",Display="職級",Value="0",ValueType="string"},
                                new ParameterEntity(){Id="COMPARED_VALUE",Binding="",Display="比較值",Value="-1",ValueType="decimal"},
                                new ParameterEntity(){Id="OVER_TIME_TYPE",Binding="$OVER_TIME_TYPE",Display="加班類型",Value="",ValueType="string"}

                            }

                        }
                    }
                };

                return policy;

            });

            lbMsg2.Text = "執行成功";

        }

        /// <summary>
        /// 請假/加班核決權限表加入至資料庫
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCNToDB_Click(object sender, EventArgs e)
        {
            int No = NextNumber();

            DataContext context = new DataContext(DBKey());
                       

            DbCommand comm2;
            List<DbCommand> commList = new List<DbCommand>();
            comm2 = context.DBase.GetSqlStringCommand("DELETE FROM BUSINESS_POLICY WHERE BUSINESS_POLICY_NAME='職級休假天數權限檢核'");
            commList.Add(comm2);
            comm2 = context.DBase.GetSqlStringCommand("DELETE FROM BUSINESS_POLICY WHERE BUSINESS_POLICY_NAME='廣州職級休假天數權限檢核'");
            commList.Add(comm2);

            //comm2 = context.DBase.GetSqlStringCommand("DELETE FROM BUSINESS_POLICY WHERE BUSINESS_POLICY_NAME='事業處主管核決1'");
            //commList.Add(comm2);

            //加班類
            comm2 = context.DBase.GetSqlStringCommand("DELETE FROM BUSINESS_POLICY WHERE BUSINESS_POLICY_NAME='職級加班天數權限檢核'");
            commList.Add(comm2);

            comm2 = context.DBase.GetSqlStringCommand("DELETE FROM BUSINESS_POLICY WHERE BUSINESS_POLICY_NAME='廣州職級加班天數權限檢核'");
            commList.Add(comm2);


            //Step1 北京
            string path = Server.MapPath("~/Policy") + "\\CNleavePplocy.xml";

            BussinessPolicy policy = new BussinessPolicy()
            {
                SystemID = 2,
                PolicyName = "職級休假天數權限檢核",
                OrgID = "UTD3",
                MajorVersion = 1,
                MinorVersion = 0,
                BRML = GetPolicyXmlString(path),
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
                PolicyId = No + 1
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
                PolicyId = No + 2
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
                PolicyId = No + 3
            };

            comm = policy.GetDBCommand<BussinessPolicy>(context.DBase, BussinessPolicy.Insert);

            commList.Add(comm);

            //加班類
            //Step1 北京
            path = Server.MapPath("~/Policy") + "\\CNUTD3OverTimePolicy.xml";

            policy = new BussinessPolicy()
            {
                SystemID = 2,
                PolicyName = "職級加班天數權限檢核",
                OrgID = "UTD3",
                MajorVersion = 1,
                MinorVersion = 0,
                BRML = GetPolicyXmlString(path),
                PolicyId = No+4
            };

            comm = policy.GetDBCommand<BussinessPolicy>(context.DBase, BussinessPolicy.Insert);

            commList.Add(comm);

            //加班-東聚
            path = Server.MapPath("~/Policy") + "\\CNPCH2OverTimePolicy.xml";

            policy = new BussinessPolicy()
            {
                SystemID = 2,
                PolicyName = "職級加班天數權限檢核",
                OrgID = "PCH2",
                MajorVersion = 1,
                MinorVersion = 0,
                BRML = GetPolicyXmlString(path),
                PolicyId = No + 5
            };

            comm = policy.GetDBCommand<BussinessPolicy>(context.DBase, BussinessPolicy.Insert);

            commList.Add(comm);
            //昆山
            path = Server.MapPath("~/Policy") + "\\CNPCH2OverTimePolicy.xml";

            policy = new BussinessPolicy()
            {
                SystemID = 2,
                PolicyName = "職級加班天數權限檢核",
                OrgID = "PKS1",
                MajorVersion = 1,
                MinorVersion = 0,
                BRML = GetPolicyXmlString(path),
                PolicyId = No + 6
            };

            comm = policy.GetDBCommand<BussinessPolicy>(context.DBase, BussinessPolicy.Insert);

            commList.Add(comm);

            //廣州
            path = Server.MapPath("~/Policy") + "\\CNPCH2OverTimePolicy2.xml";

            policy = new BussinessPolicy()
            {
                SystemID = 2,
                PolicyName = "廣州職級加班天數權限檢核",
                OrgID = "PCH2",
                MajorVersion = 1,
                MinorVersion = 0,
                BRML = GetPolicyXmlString(path),
                PolicyId = No + 7
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

        protected void btnTWPolicy_Click(object sender, EventArgs e)
        {
            //台灣請假
            string path4 = Server.MapPath("~/Policy") + "\\PTW2LeavePolicy.xml";

            GetPTWLeavePolicy().ClassToXmlFile(path4);
        }

        protected void btnInsertTWLeave_Click(object sender, EventArgs e)
        {
            int No = NextNumber();

            DataContext context = new DataContext(DBKey());

            List<DbCommand> commList = new List<DbCommand>();

            DbCommand comm2 = context.DBase.GetSqlStringCommand("DELETE FROM BUSINESS_POLICY  where ORGANIZATION_ID='PTW2' and  BUSINESS_POLICY_NAME='職級休假天數權限檢核'");
            commList.Add(comm2);

            string path = Server.MapPath("~/Policy") + "\\PTW2LeavePolicy.xml";

            BussinessPolicy policy = new BussinessPolicy()
            {
                SystemID = 2,
                PolicyName = "職級休假天數權限檢核",
                OrgID = "PTW2",
                MajorVersion = 1,
                MinorVersion = 0,
                BRML = GetPolicyXmlString(path),
                PolicyId = No + 1
            };

            DbCommand comm = policy.GetDBCommand<BussinessPolicy>(context.DBase, BussinessPolicy.Insert);

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
    }
}
