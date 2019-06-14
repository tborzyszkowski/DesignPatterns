using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public class Seabird : ISeacraft, IAircraft
    {
        private readonly IAircraft aircraft;
        public int Speed { get; set; }
        public int Height { get; set; }
        public Seabird(IAircraft aircraft)
        {
            this.aircraft = aircraft;
        }

        public void TakeOff()
        {
            aircraft.TakeOff();
            while (!Airborne)
                IncreaseRevs();
        }

        public void IncreaseRevs()
        {
            Speed += 15;
            if (Speed > 40)
                aircraft.Height += 100;
        }

        public bool Airborne
        {
            get { return aircraft.Height > 50; }
        }

        
    }
}
