using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PrimaxBPM2Library.Flow.Entity
{
    public class FlowEntity
    {

        [XmlElement(ElementName = "BussinessJob")]
        public BussinessJobEntity Job { get; set; }

        [XmlElement(ElementName = "BussinessNumber")]
        public BussinessNumberEntity BussinessNumber { get; set; }

        [XmlElement(ElementName = "BussinessPolicy")]
        public List<BussinessPolicy> PolicyList { get; set; }

        [XmlElement(ElementName = "Process")]
        public ProcessEntity Process { get; set; }

        [XmlElement(ElementName = "Oraganization")]
        public List<GroupProcessEntity> Groups { get; set; }

        [XmlElement(ElementName = "Property")]
        public List<ProcessPropertyEntity> PropertyList { get; set; }

        [XmlElement(ElementName = "Form")]
        public List<FormPageEntity> FormList { get; set; }

        [XmlElement(ElementName = "Activity")]
        public List<ActivityEntity> ActivityList { get; set; }
    }
}
