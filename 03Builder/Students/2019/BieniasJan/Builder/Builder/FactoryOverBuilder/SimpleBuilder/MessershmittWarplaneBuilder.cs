using Builder.FactoryOverBuilder.SimpleBuilder.MilitaryVehicles;
using Builder.FactoryOverBuilder.SimpleBuilder.MilitaryVehicles.Warplanes;

namespace Builder.FactoryOverBuilder.SimpleBuilder
{
    public class MessershmittWarplaneBuilder : WarplaneBuilder
    {
        public MessershmittWarplaneBuilder()
        {
            _warplane = new Warplane() { Name = "Messerschmitt Bf 109" };
        }

        public override void SetAmmoCapacity()
        {
            _warplane.AmmoCapacity = 1100;
        }

        public override void SetHitPoints()
        {
            _warplane.HitPoints = 200;
        }

        public override void SetMaxSpeed()
        {
            _warplane.Speed = 530;
        }

        public override void SetNationality()
        {
            _warplane.Nationality = Nation.Germany;
        }

        public override void SetPrice()
        {
            _warplane.Price = 319_000;
        }

        public override void SetType()
        {
            _warplane.WarplaneType = WarplaneType.Fighter;
        }

        public override void SetYearOfProduction()
        {
            _warplane.YearOfProduction = 1937;
        }
    }
}
