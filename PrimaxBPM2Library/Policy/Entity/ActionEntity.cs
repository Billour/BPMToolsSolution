using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;


namespace PrimaxBPM2Library.Policy.Entity
{
    public class ActionEntity
    {

        [XmlAttribute("RESULT")]
        public bool Result { get; set; }

        [XmlElement("EXPRESSION")]
        public ExpressionEntity Expression { get; set; }
    }
}
