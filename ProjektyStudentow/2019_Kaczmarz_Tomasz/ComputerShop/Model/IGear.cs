using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Model
{
    public interface IGear
    {
        string Make { get; set; }
        string Model { get; set; }

        string GetSpecs();
    }
}
