using System;

namespace AbstractFactory.Tanks
{
    class Pershing : AbstractUSA
    {
        public Pershing()
        {
            Name = "M26 Pershing";
            Nationality = "USA";
            Production = new DateTime(1944, 1, 1);
        }
    }
}
