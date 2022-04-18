using System;
using System.Configuration;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace PrimaxBPM2Library.Config
{
    public static class LoginInfo
    {
        public static string GetPortalDB(this string env)
        {
            NameValueCollection di;


            di = (NameValueCollection)ConfigurationSettings.GetConfig("Primax/" + env + "/Base");

            if (di.Count == 0)
            {
                throw new Exception("無法取得此區段" + env + "Base的設定參數，請確定WebConfig有此區段的設定值");
            }

            return di["DB"].ToString();
        }

        public static NameValueCollection GetProcessList(this string env)
        {
            NameValueCollection di;


            di = (NameValueCollection)ConfigurationSettings.GetConfig("Primax/" + env + "/Process");

            if (di.Count == 0)
            {
                throw new Exception("無法取得此區段" + env + "的設定參數，請確定WebConfig有此區段的設定值");
            }

            return di;


        }

    }
}
