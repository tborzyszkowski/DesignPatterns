using System;

namespace FactoryMethod.Cars
{
    class Auris : Car
    {
        public Auris()
        {
            Name = "Toyota Yaris";
            MaxSpeed = 120;
            HP = 10;
        }
    }
}
