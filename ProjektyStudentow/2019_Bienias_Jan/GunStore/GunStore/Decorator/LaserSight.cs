namespace GunStore.Decorator
{
    //Concrete Decorator
    public class LaserSight : Attachment
    {
        public LaserSight(AbstractGun gun) : base(gun)
        {
            AdditionalValue = 100m;
        }

        public override string ToString()
        {
            return base.ToString() + " + Laser sight";
        }
    }
}
