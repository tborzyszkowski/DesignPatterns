namespace AdapterSeabird
{
    public class Seabird : Aircraft, ISeacraft
    {
        int speed = 0;

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

        public override bool Airborne
        {
            get { return Height > 50; }
        }

        public int Speed
        {
            get { return speed; }
        }
    }
}
