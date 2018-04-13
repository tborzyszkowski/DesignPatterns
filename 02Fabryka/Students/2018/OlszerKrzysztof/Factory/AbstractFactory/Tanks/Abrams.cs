using System;

namespace AbstractFactory.Tanks
{
    class Abrams : AbstractUSA
    {
        public Abrams()
        {
            Name = "M1 Abrams";
            Nationality = "USA";
            Production = new DateTime(1980, 1, 1);
        }
    }
}
