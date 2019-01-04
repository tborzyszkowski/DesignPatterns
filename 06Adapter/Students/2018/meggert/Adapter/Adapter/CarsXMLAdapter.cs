using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace Adapter
{
    public class CarsXMLAdapter : ICarsXMLTarget
    {
        public XmlDocument GetCarsXML()
        {
            CarsJSONAdaptee personJSONAdapte = new CarsJSONAdaptee();
            string cars = personJSONAdapte.GetCarsJSON();
            XmlDocument x = JsonConvert.DeserializeXmlNode(cars, "ListOfCars", true);
            return x;
        }
    }
}
