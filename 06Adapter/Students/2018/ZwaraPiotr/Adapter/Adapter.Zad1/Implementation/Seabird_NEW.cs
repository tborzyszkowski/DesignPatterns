using System;

using Adapter.Zad1.Abstraction;

namespace Adapter.Zad1.Implementation
{
    public class Seabird_NEW : ISeacraft, IAircraft
    {
        private readonly IAircraft aircraft;

        public Seabird_NEW(IAircraft aircraft)
        {
            this.aircraft = aircraft;
        }

        public int Speed { get; private set; }

        public bool Airborne
        {
            get { return this.aircraft.Height > 50; }
        }

        public int Height
        {
            get { return this.aircraft.Height; }
            set { this.aircraft.Height = value; }
        }

        public void IncreaseRevs()
        {
            this.Speed += 10;
            Console.WriteLine("Seacraft engine increases revs to " + this.Speed + " knots");

            if (this.Speed > 40)
                this.aircraft.Height += 100;
        }

        public void TakeOff()
        {
            while (!this.Airborne)
                this.IncreaseRevs();
        }
    }
}
