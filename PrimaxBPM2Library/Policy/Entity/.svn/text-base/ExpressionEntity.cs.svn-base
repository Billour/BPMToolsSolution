using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;

namespace PrimaxBPM2Library.Policy.Entity
{
    public class ExpressionEntity
    {
        [XmlAttribute("PARAMETER")]
        public string Parameter { get; set; }

        [XmlIgnore]
        public string Text { get; set; }


        [XmlText]

        public XmlNode[] CDataContent
        {

            get
            {

                var dummy = new XmlDocument();

                return new XmlNode[] { dummy.CreateCDataSection(this.Text)};

            }

            set
            {

                if (value == null)
                {

                    this.Text = null;

                    return;

                }



                if (value.Length != 1)
                {

                    throw new InvalidOperationException(

                        String.Format(

                            "Invalid array length {0}", value.Length));

                }



                var node0 = value[0];



                if (node0 == null)
                {

                    throw new InvalidOperationException(

                        String.Format(

                            "Invalid node type {0}", node0.NodeType));

                }



                this.Text = node0.Value;

            }

        }


        
    }
}
