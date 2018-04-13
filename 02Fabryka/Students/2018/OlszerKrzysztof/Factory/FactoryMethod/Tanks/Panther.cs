using System;

namespace FactoryMethod.Tanks
{
    class Panther : Tank
    {
        public Panther()
        {
            Name = "Panzerkampfwagen V Panther II";
            Nationality = "Germany";
            Production = new DateTime(1943, 1, 1);
        }
    }
}
