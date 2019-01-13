using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    class CityFactory : MapFactory //Dependency Injection, Metoda fabrykująca
    {
        public override IMap CreateMap(Player player)
        {
            return new City(player);
        }

    }
}
