using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PrimaxBPM2Library.Policy.Entity
{
    public class CDATA : IXmlSerializable
    {
        public CDATA()
        { 
            
        }

        public CDATA(string text)
        {
            this.Value=text;
        }
        
        public string Value { get; set; }
       
        void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteCData(this.Value);
        }

        System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
            //MSDN dice "This member supports the .NET Framework infrastructure 
            //and is not intended to be used directly from your code."
            //...se ho capito lo scopo del metodo per i nostri casi d'uso va benissimo 
            //fare tornare null.
            return null;
        }

        void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
        {   //(@update 04-nov-2005, vedi errata korrige)

            //this.text = reader.ReadString();
            //reader.Read()         this.Text = reader.GetElementString();
        }
       

    }
}
