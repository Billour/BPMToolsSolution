using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrimaxBPM2Library.Flow.Logic;

namespace BPM2ToolWeb
{
    public partial class MailTemplateRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMailTemplate_Click(object sender, EventArgs e)
        {
            MailLogic logic = new MailLogic();

            if (logic.InserMailLTemplate())
            {
                lbMsg.Text = "OK";
            }
            else
            {
                lbMsg.Text = "Not OK";
            }
        }
    }
}
