using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using fabrykaAbstrakcyjna.czolg;
using fabrykaAbstrakcyjna.dziala;
using fabrykaAbstrakcyjna.bwp;
using fabrykaAbstrakcyjna.apc;

namespace fabrykaAbstrakcyjna
{
    public interface Ifabryka
    {
        czolg.czolg zrobCzolg();
        apc.apc zrobApc();
        bwp.bwp zrobBwp();
        dziala.dziala zrobDziala();
    }
}
