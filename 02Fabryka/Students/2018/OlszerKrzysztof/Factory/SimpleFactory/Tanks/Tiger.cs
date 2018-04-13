using System;

namespace SimpleFactory.Tanks
{
    class Tiger : Tank
    {
        public Tiger()
        {
            Name = "Panzerkampfwagen VI Tiger";
            Nationality = "Germany";
            Production = new DateTime(1942, 1, 1);
        }
    }
}
