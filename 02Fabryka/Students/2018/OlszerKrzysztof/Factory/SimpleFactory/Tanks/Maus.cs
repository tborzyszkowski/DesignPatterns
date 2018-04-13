using System;

namespace SimpleFactory.Tanks
{
    class Maus : Tank
    {
        public Maus()
        {
            Name = "Panzerkampfwagen VIII Maus";
            Nationality = "Germany";
            Production = new DateTime(1944, 1, 1);
        }
    }
}
