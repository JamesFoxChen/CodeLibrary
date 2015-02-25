using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Data;
using System.IO;

namespace CL.Framework.Utils.IO
{
    public static class XmlUtil
    {
        public static string Attr(this XElement xe, string attrName)
        {
            XAttribute attribute = xe.Attribute(attrName);
            return ((attribute != null) ? attribute.Value : null);
        }

        public static string ConverDictionaryToXml(Dictionary<string, object> data)
        {
            XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new object[0]);
            XElement content = new XElement("root");
            document.Add(content);
            foreach (KeyValuePair<string, object> pair in data)
            {
                XElement element2 = new XElement(pair.Key, pair.Value);
                content.Add(element2);
            }
            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
            {
                document.Save(writer);
            }
            return sb.ToString();
        }

        public static string ConvertDataTableToXml(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
            {
                dt.WriteXml(writer);
            }
            return sb.ToString();
        }

        public static string ElementVal(XElement parentElement, string name)
        {
            XElement element = parentElement.Element(name);
            return ((element != null) ? element.Value : null);
        }

        public static string SerializeToXml(object data)
        {
            XmlSerializer serializer = new XmlSerializer(data.GetType());
            StringBuilder sb = new StringBuilder();
            using (StringWriter writer = new StringWriter(sb))
            {
                serializer.Serialize((TextWriter)writer, data);
            }
            return sb.ToString();
        }

        public static void SerializeToXml(object data, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(data.GetType());
            using (FileStream stream = File.Open(filePath, FileMode.Create))
            {
                serializer.Serialize((Stream)stream, data);
            }
        }
    }
}
