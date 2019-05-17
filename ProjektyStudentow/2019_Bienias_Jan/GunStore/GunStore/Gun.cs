using GunStore.Prototype;

namespace GunStore
{
    public class Gun : AbstractGun, IPrototype<Gun>
    {
        public Gun Clone()
        {
            return MemberwiseClone() as Gun;
        }

        public override decimal Value()
        {
            return BasePrice;
        }
    }
}
