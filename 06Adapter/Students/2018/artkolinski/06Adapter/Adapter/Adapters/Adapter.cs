using System;

namespace Adapter.Adapters
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

        public void ChangeRequest(Func<object, string> ff)
        {
            Request = ff;
        }
    }
}
