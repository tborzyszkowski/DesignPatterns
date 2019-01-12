using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    abstract class MapFactory //Metoda fabrykująca
    {
        public abstract IMap CreateMap(Player player);
    }
}
