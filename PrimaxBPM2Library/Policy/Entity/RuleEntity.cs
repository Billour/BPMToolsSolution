using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PrimaxBPM2Library.Policy.Entity
{
    public class RuleEntity
    {
        
        [XmlElement("CONDITION")]
        public CDATA Condition { get; set; }

        [XmlElement("ACTIONS")]
        public ActionsEntity Actions { get; set; }
    }
}
