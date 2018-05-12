using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Adapter.Adapters
{
    public class XmlAdapter
    {
        public string CreateXml(object obj)
        {
            var xmlSerializer = new XmlSerializer(obj.GetType());
            string xml;

            using (var stringWriter = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stringWriter))
                {
                    xmlSerializer.Serialize(xmlWriter, obj);
                    xml = stringWriter.ToString();
                }
            }
            return xml;
        }
    }
}