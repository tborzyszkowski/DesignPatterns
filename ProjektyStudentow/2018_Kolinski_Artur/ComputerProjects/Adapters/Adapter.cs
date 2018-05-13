using System;

namespace ComputerProjects.Adapters
{
    public class Adapter
    {
        public Func<object, string> Request;

        public Adapter(JsonAdapter jsonAdapter)
        {
            Request = jsonAdapter.CreateJson;
        }

        public Adapter(XmlAdapter xmlAdapter)
        {
            Request = xmlAdapter.CreateXml;
        }
    }
}