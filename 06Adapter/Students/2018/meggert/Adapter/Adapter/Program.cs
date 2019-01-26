using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        CarsXMLAdapter xml;
        CarsJSONAdaptee json;

        public Program(CarsJSONAdaptee json)
        {
            this.json = json;
        }

        public Program(CarsXMLAdapter xml)
        {
            this.xml = xml;
        }

        static void Main(string[] args)
        {
            CarsJSONAdaptee json = new CarsJSONAdaptee();
            CarsXMLAdapter xml = new CarsXMLAdapter();

            Program p = new Program(json);
            Console.WriteLine("json\n");
            Console.WriteLine(p.json.GetCarsJSON().ToString());

            p = new Program(xml);
            Console.WriteLine("\nxml\n");
            Console.WriteLine(p.xml.GetCarsXML().InnerXml);
           
            Console.ReadKey();
        }
    }
}
