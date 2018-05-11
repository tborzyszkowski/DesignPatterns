namespace AdapterSeabird
{

    public sealed class Seacraft : ISeacraft
    {
        int speed = 0;

        public void IncreaseRevs()
        {
            speed += 10;
        }

        public int Speed
        {
            get { return speed; }
        }
    }

}
