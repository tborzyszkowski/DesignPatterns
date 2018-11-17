namespace FactoryMethod.Cars
{
    class Escort : Car
    {
        public Escort()
        {
            Name = "Ford Escort";
            MaxSpeed = 111;
            HP = 85;
        }

        public string BreakCar() => "50 m";
    }
}
