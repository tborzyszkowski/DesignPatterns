namespace GunStore.Decorator
{
    //Concrete Decorator
    public class HoloSight : Attachment
    {
        public HoloSight(AbstractGun gun) : base(gun)
        {
            AdditionalValue = 150m;
        }

        public override string ToString()
        {
            return base.ToString() + " + Holographic sight";
        }
    }
}
