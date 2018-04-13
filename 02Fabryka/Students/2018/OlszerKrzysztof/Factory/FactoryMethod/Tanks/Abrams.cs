using System;

namespace FactoryMethod.Tanks
{
    class Abrams : Tank
    {
        public Abrams()
        {
            Name = "M1 Abrams";
            Nationality = "USA";
            Production = new DateTime(1980, 1, 1);
        }
    }
}
