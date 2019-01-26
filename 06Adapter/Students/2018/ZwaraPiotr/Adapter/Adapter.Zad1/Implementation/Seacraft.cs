using System;

using Adapter.Zad1.Abstraction;

namespace Adapter.Zad1.Implementation
{
    public class Seacraft : ISeacraft
    {
        public int Speed { get; private set; }

        public virtual void IncreaseRevs()
        {
            this.Speed += 10;
            Console.WriteLine("Seacraft engine increases revs to " + this.Speed + " knots");
        }
    }
}
