namespace Seabird
{
    public class SeabirdToAircraft : Aircraft, ISeacraft
    {
        private int speed = 0;

        public override void TakeOff()
        {
            while (!Airborne)
                IncreaseRevs();
        }

        public void IncreaseRevs()
        {
            speed += 10;
            if (speed > 40)
                Height += 100;
        }

        public int Speed
        {
            get { return speed; }
        }

        public override bool Airborne
        {
            get { return Height > 50; }
        }
    }
}
