namespace GunStore.Decorator
{
    //Concrete Decorator
    public class Silencer : Attachment
    {
        public Silencer(AbstractGun gun) : base(gun)
        {
            AdditionalValue = 50m;
        }

        public override string ToString()
        {
            return base.ToString() + " + Silencer";
        }
    }
}
