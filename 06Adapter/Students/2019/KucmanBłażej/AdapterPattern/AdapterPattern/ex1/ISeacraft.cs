using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.ex1
{
    public interface ISeacraft
    {
        int Speed { get; }
        void IncreaseRevs();
    }
}
