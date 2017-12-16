using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace Adapter
{
    public class PersonXMLAdapter : IPersonXMLTarget
    {
        public XmlDocument GetPersonXML()
        {
            PersonJSONAdaptee personJSONAdapte = new PersonJSONAdaptee();
            string jsonPerson = personJSONAdapte.GetPersonListJSON();

            XmlDocument doc = JsonConvert.DeserializeXmlNode(jsonPerson,"PersonList", true);

            return doc;
        }
    }
}
