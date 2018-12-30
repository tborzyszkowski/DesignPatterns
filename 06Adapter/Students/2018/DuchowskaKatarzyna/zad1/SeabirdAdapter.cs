using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.zad1
{
    public class SeabirdAdapter : Aircraft
    {
        private Seabird seabird = new Seabird();

        public SeabirdAdapter() : base() { }

        //from IAircraft

        public new void TakeOff()
        {
            seabird.TakeOff();
        }

        public new int Height
        {
            get { return seabird.Height; }
        }

        public new bool Airborne
        {
            get { return seabird.Height > 50; }
        }

        //from ISeacraft
        public void IncreaseRevs()
        {
            seabird.IncreaseRevs();
        }

        public int Speed { get { return seabird.Speed; } }
    }
}
