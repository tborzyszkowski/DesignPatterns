using System;

using Adapter.Zad1.Abstraction;

namespace Adapter.Zad1.Implementation
{
    public sealed class Aircraft : IAircraft
    {
        public Aircraft()
        {
            this.Airborne = false;
            this.Height = 0;
        }

        public bool Airborne { get; private set; }

        public int Height { get; set; } // private set; }

        public void TakeOff()
        {
            Console.WriteLine("Aircraft engine takeoff");

            this.Airborne = true;
            this.Height = 200;
        }
    }
}
