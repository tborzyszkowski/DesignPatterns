using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.zad1
{
    public interface ISeacraft
    {
        int Speed { get; }
        void IncreaseRevs();
    }
}
