namespace AbstractFactory.Cars
{
    class Focus : AbstractFord
    {
        public Focus()
        {
            Name = "Ford Focus";
            MaxSpeed = 220;
            HP = 80;
        }

        public string BreakCar() => "180 m";
    }
}
