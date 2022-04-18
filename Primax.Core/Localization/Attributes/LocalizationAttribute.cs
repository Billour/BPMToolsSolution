using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Primax.Core.Localization.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = true)]
    public class LocalizationAttribute : System.Attribute
    {
        public LocalizationAttribute()
        {
            this.Text = "Text";
            
        }

        //private Type _ControlType = null;
        //private string _Name;
        //private string _Text = "Text";
        

        ///// <summary>
        ///// UI ID
        ///// </summary>
        ///// <param name="name"></param>
        //public LocalizationAttribute(string name)
        //{
        //    _Name = name;

        //}


        //public LocalizationAttribute(string name, Type type)
        //{
        //    _ControlType = type;
        //    _Name = name;

        //}

        ///// <summary>
        ///// Local String
        ///// </summary>
        ///// <param name="name">UI ID</param>
        ///// <param name="text">UI Display Property</param>
        //public LocalizationAttribute(string name, string text)
        //{
        //    _Name = name;
        //    _Text = text;
        //}

        //public LocalizationAttribute(string name, string text, Type type)
        //{
        //    _ControlType = type;
        //    _Name = name;
        //    _Text = text;
        //}

        /// <summary>
        /// 註解說明
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Localization Control Name
        /// </summary>
        public string Name{get;set;}
      
        /// <summary>
        /// Output Parameter
        /// </summary>
        public string Text { get; set; }
       
        /// <summary>
        /// Control Type 目前己經不用
        /// </summary>
        public Type ControlType{get;set;}

        
        
    }
}
