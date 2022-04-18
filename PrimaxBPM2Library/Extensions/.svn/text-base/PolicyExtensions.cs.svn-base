using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrimaxBPM2Library.Policy.Entity;
using Primax.Core.Helper;
using System.Data.Common;
using Primax.Core.Data;

namespace PrimaxBPM2Library.Extensions
{
    public static class PolicyExtensions
    {

        public static void ToPolicyXml<T>(this string path, Func<T> policyMethod)
        {
            policyMethod().ClassToXmlFile<T>(path);      
        }

        
    }
}
