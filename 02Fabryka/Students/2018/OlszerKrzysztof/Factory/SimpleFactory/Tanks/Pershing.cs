using System;

namespace SimpleFactory.Tanks
{
    class Pershing : Tank
    {
        public Pershing()
        {
            Name = "M26 Pershing";
            Nationality = "USA";
            Production = new DateTime(1944, 1, 1);
        }
    }
}
