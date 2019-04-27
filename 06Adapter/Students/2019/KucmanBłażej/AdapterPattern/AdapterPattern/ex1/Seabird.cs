using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.ex1
{
    public class Seabird : ISeacraft, IAircraft
    {
        private readonly IAircraft aircraft;
        int height = 0;

        public Seabird(IAircraft aircraft)
        {
            this.aircraft = aircraft;
        }

        // A two-way adapter hides and routes the Target's methods
        // Use Seacraft instructions to implement this one
        public void TakeOff()
        {
            aircraft.TakeOff();
            while (!Airborne)
                IncreaseRevs();
        }

        // Routes this straight back to the Aircraft
        public int Height
        {
            get { return aircraft.Height; }
            set { aircraft.Height = value; }
        }

        // This method is common to both Target and Adaptee
        public  void IncreaseRevs()
        {
            Speed += 10;
            if (Speed > 40)
                aircraft.Height += 100;
        }

        public bool Airborne
        {
            get { return aircraft.Height > 50; }
        }

        public int Speed { get; set; }
    }
}
