using Adapter.Zad1.Abstraction;

namespace Adapter.Zad1.Implementation
{
    public class Seabird : Seacraft, IAircraft
    {
        public void TakeOff()
        {
            while (!this.Airborne)
                this.IncreaseRevs();
        }

        public int Height { get; set; } // private set; }

        public override void IncreaseRevs()
        {
            base.IncreaseRevs();
            if (this.Speed > 40)
                this.Height += 100;
        }

        public bool Airborne
        {
            get { return this.Height > 50; }
        }
    }
}