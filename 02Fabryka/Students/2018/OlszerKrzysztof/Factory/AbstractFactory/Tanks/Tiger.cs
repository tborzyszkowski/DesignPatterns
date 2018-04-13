using System;

namespace AbstractFactory.Tanks
{
    class Tiger : AbstractGerman
    {
        public Tiger()
        {
            Name = "Panzerkampfwagen VI Tiger";
            Nationality = "Germany";
            Production = new DateTime(1942, 1, 1);
        }
    }
}
