using GunStore.Enums;
using GunStore.Visitor;

namespace GunStore
{
    public abstract class AbstractGun : IElement
    {
        public int Count { get; set; }
        public string Name { get; set; }
        public GunType Type { get; set; }
        public Nation Nation { get; set; }
        public decimal BasePrice { get; set; }
        public string Designer { get; set; }
        public string Manufacturer { get; set; }
        public int MuzzleVelocity { get; set; }
        public int RateOfFire { get; set; }
        public string Caliber { get; set; }
        public decimal Mass { get; set; }

        public abstract decimal Value(); //Value = BasePrice + Possible Attachments Values - for Decorator

        public void Accept(IVisitor visitor) //Implementation of IElement required for Visitor
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            return "Name: " + Name + ", Type: " + Type + ", Nation: " + Nation + ", Base Price: " + BasePrice +
                "$, Designer: " + Designer + ", Manufacturer: " + Manufacturer +
                ", Muzzle Velocity: " + MuzzleVelocity + " m/s, Rate of Fire: " + RateOfFire + " rds/min, Caliber: " + Caliber +
                ", Mass: " + Mass + " kg";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                AbstractGun p = (AbstractGun)obj;
                return (Name == p.Name) && (Type == p.Type) && (Nation == p.Nation) && (BasePrice == p.BasePrice)
                    && (Designer == p.Designer) && (Manufacturer == p.Manufacturer) && (RateOfFire == p.RateOfFire)
                    && (MuzzleVelocity == p.MuzzleVelocity) && (Caliber == p.Caliber) && (Mass == p.Mass);
            }
        }
    }
}
