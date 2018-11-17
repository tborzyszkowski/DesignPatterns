namespace AbstractFactory.Cars
{
    class Yaris : AbstractToyota
    {
        public Yaris()
        {
            Name = "Toyota Yaris";
            MaxSpeed = 120;
            HP = 10;
        }

        public string BreakCar() => "500 m";
    }
}
