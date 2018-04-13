using System;

namespace SimpleFactory.Cars
{
    class Focus : Car
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
