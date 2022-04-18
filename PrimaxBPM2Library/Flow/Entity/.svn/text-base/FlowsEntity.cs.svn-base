using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PrimaxBPM2Library.Flow.Entity
{
    [XmlRoot(ElementName="Flows")]
    public class FlowsEntity
    {
        /// <summary>
        /// Table Base Process
        /// </summary>
        [XmlElement(ElementName = "BaseProcess")]
        public BaseProcessEntity BaseProcess { get; set; }

        /// <summary>
        /// 流程計主檔
        /// </summary>
        [XmlElement(ElementName = "Flow")]
        public List<FlowEntity> FlowList { get; set; }
    }
}
