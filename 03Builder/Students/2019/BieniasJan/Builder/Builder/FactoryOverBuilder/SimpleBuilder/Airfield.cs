namespace Builder.FactoryOverBuilder.SimpleBuilder
{
    //Director
    public class Airfield
    {
        public void Construct(WarplaneBuilder warplaneBuilder)
        {
            warplaneBuilder.SetAmmoCapacity();
            warplaneBuilder.SetHitPoints();
            warplaneBuilder.SetNationality();
            warplaneBuilder.SetPrice();
            warplaneBuilder.SetType();
            warplaneBuilder.SetYearOfProduction();
            warplaneBuilder.SetMaxSpeed();
        }
    }
}
