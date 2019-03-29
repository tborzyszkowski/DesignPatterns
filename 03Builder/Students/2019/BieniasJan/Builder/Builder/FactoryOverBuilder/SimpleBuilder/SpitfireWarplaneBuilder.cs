using Builder.FactoryOverBuilder.SimpleBuilder.MilitaryVehicles;
using Builder.FactoryOverBuilder.SimpleBuilder.MilitaryVehicles.Warplanes;

namespace Builder.FactoryOverBuilder.SimpleBuilder
{
    public class SpitfireWarplaneBuilder : WarplaneBuilder
    {
        public SpitfireWarplaneBuilder()
        {
            _warplane = new Warplane() { Name = "Supermarine Spitfire" };
        }

        public override void SetAmmoCapacity()
        {
            _warplane.AmmoCapacity = 500;
        }

        public override void SetHitPoints()
        {
            _warplane.HitPoints = 230;
        }

        public override void SetMaxSpeed()
        {
            _warplane.Speed = 585;
        }

        public override void SetNationality()
        {
            _warplane.Nationality = Nation.UK;
        }

        public override void SetPrice()
        {
            _warplane.Price = 892_000;
        }

        public override void SetType()
        {
            _warplane.WarplaneType = WarplaneType.Fighter;
        }

        public override void SetYearOfProduction()
        {
            _warplane.YearOfProduction = 1938;
        }
    }
}
