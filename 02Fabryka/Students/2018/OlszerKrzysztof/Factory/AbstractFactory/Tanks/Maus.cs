using System;

namespace AbstractFactory.Tanks
{
    class Maus : AbstractGerman
    {
        public Maus()
        {
            Name = "Panzerkampfwagen VIII Maus";
            Nationality = "Germany";
            Production = new DateTime(1944, 1, 1);
        }
    }
}
