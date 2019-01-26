using Adapter.zad1;
using NUnit.Framework;

namespace Tests
{
    public class Zad1
    {
        [Test]
        public void SeabirdAdapterIsAircraft()
        {
            SeabirdAdapter seabirdAdapter = new SeabirdAdapter();
            Assert.IsTrue(seabirdAdapter is Aircraft);
        }

        [Test]
        //przy dodaniu dziedziczenia seacraft : aircraft
        public void SeabirdIsAircraft()
        {
            Seabird seabird = new Seabird();
            Assert.IsTrue(seabird is Aircraft);
        }
    }
}