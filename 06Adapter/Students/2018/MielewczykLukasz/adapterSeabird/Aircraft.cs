namespace AdapterSeabird
{
    public class Aircraft : IAircraft
    {
        int height;
        bool airborne;

        public Aircraft()
        {
            height = 0;
            airborne = false;
        }

        public virtual void TakeOff()
        {
            airborne = true;
            height = 200;
        }

        public virtual bool Airborne
        {
            get { return airborne; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }
    }
}
