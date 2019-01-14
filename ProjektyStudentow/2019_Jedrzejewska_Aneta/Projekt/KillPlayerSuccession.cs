using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    class KillPlayerSuccession : IKill //Strategy
    {
        public void KillSuccession()
        {
            Console.WriteLine("GAME OVER");
        }
    }
}
