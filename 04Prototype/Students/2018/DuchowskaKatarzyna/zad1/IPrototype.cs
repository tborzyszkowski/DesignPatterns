using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.zad1
{
    public interface IPrototype
    {
        IPrototype ShallowCopy();
        IPrototype DeepCopy();
    }
}
