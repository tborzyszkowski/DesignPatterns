namespace GunStore.Decorator
{
    //Decorator
    public abstract class Attachment : AbstractGun
    {
        protected AbstractGun _gun;
        public decimal AdditionalValue { get; protected set; }

        public Attachment(AbstractGun gun)
        {
            _gun = gun;
        }

        public override decimal Value()
        {
            return _gun.Value() + AdditionalValue;
        }

        public override string ToString()
        {
            return _gun.ToString();
        }

        public override bool Equals(object obj)
        {
            return _gun.Equals(obj);
        }

        public override int GetHashCode()
        {
            return _gun.GetHashCode();
        }
    }
}
