using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Primax.Core.Localization.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum)]
    public class SupportLocalizationAttribute : Attribute
    {
        public SupportLocalizationAttribute()
        {
            this.IsKeyFromData = false;
        }

        /// <summary>
        /// 允許的語系
        /// </summary>
        public string AllowLanguage { get; set; }

        /// <summary>
        /// 是否Key 值是來自List
        /// 如果=是(詳再將資料加入Key值)
        /// 如果=否(就不需要)
        /// </summary>
        public bool IsKeyFromData { get; set; }

        /// <summary>
        /// 專門針對資料從資料庫而來的參數
        /// </summary>
        public string DataKeyID { get; set;}
    }
}
