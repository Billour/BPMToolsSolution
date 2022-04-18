using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PrimaxBPM2Library.Policy.Entity
{
    public class ParametersEntity
    {
        [XmlElement("PARAMETER")]
        public List<ParameterEntity> ParameterList { get; set; }
    }
}
