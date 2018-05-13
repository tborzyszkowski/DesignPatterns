using Adapter;
using Adapter.Adapters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdapterTests
{
    [TestClass]
    public class AdapterTests
    {
        [TestMethod]
        public void CreateJson()
        {
            var computer = new Computer();
            global::Adapter.Adapters.Adapter adapter = new global::Adapter.Adapters.Adapter(new JsonAdapter());
            Assert.AreEqual("{\"ProjectName\":\"My dream nr 7005\",\"Case\":\"Obudowa Lian Li DK-03X\",\"Motherboard\":\"Asus ROG RAMPAGE VI EXTREME\"}", adapter.Request(computer));
        }
        [TestMethod]
        public void CreateXml()
        {
            var computer = new Computer();
            global::Adapter.Adapters.Adapter adapter = new global::Adapter.Adapters.Adapter(new XmlAdapter());
            Assert.AreEqual("<?xml version=\"1.0\" encoding=\"utf-16\"?><Computer xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><ProjectName>My dream nr 7005</ProjectName><Case>Obudowa Lian Li DK-03X</Case><Motherboard>Asus ROG RAMPAGE VI EXTREME</Motherboard></Computer>", adapter.Request(computer));
        }
        [TestMethod]
        public void ChangeXmlToJson()
        {
            var computer = new Computer();
            global::Adapter.Adapters.Adapter adapter = new global::Adapter.Adapters.Adapter(new XmlAdapter());
            Assert.AreEqual("<?xml version=\"1.0\" encoding=\"utf-16\"?><Computer xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><ProjectName>My dream nr 7005</ProjectName><Case>Obudowa Lian Li DK-03X</Case><Motherboard>Asus ROG RAMPAGE VI EXTREME</Motherboard></Computer>", adapter.Request(computer));
            JsonAdapter jsonAdapter = new JsonAdapter();
            adapter.ChangeRequest(jsonAdapter.CreateJson);
            Assert.AreEqual("{\"ProjectName\":\"My dream nr 7005\",\"Case\":\"Obudowa Lian Li DK-03X\",\"Motherboard\":\"Asus ROG RAMPAGE VI EXTREME\"}", adapter.Request(computer));
        }
    }
}