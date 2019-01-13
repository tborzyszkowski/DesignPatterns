using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    class ForestFactory : MapFactory //Metoda fabrykująca
    {
        public override IMap CreateMap(Player player)
        {
            return new Forest(player);
        }
    }
}
