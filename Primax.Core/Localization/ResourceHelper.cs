using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Primax.Core.Localization
{
    public static class ResourceHelper
    {
        /// <summary>
        /// Language 的語系
        /// </summary>
        public static Dictionary<string, Dictionary<string, Dictionary<string,string>>> LangResource { get; set; }
    }
}
