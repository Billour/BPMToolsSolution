using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BPM2ToolWeb
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string nextUser = "";

            string[] data = { "A","B","C","D","E" };
            string last = "E";
            var next = data.SkipWhile(u => u != last);

            if (next.ToList().Count==1)
            {
                nextUser = next.First();
            }
            else
            {
                nextUser = next.Skip(1).First();
            }


            //var next = data.SkipWhile(u => u != last).Skip(1).First();

        }
    }
}
