using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        private PersonJSONAdaptee _json;
        private PersonXMLAdapter _xml;

        public Program(PersonJSONAdaptee json)
        {
            this._json = json;
        }

        public Program(PersonXMLAdapter xml)
        {
            this._xml = xml;
        }

        static void Main(string[] args)
        {
            PersonJSONAdaptee json = new PersonJSONAdaptee();
            PersonXMLAdapter xml = new PersonXMLAdapter();

            Program p = new Program(json);
            Console.WriteLine("=================JSON====================");
            Console.WriteLine(p._json.GetPersonListJSON().ToString());

            p = new Program(xml);
            Console.WriteLine("=================XML=====================");
            Console.WriteLine(p._xml.GetPersonXML().InnerXml);
           
            Console.ReadKey();
        }
    }
}
