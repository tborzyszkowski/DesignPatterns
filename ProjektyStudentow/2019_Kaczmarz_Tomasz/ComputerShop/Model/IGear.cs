using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Model
{
    public interface IGear
    {
        string Make { get; set; }
        string Model { get; set; }

        string GetSpecs();
    }
}
