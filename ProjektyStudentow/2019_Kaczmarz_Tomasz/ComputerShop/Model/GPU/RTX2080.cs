using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Model.GPU
{
    public class RTX2080 : GPU
    {
        public RTX2080()
        {
            Make = "Nvidia";
            Model = "GeForce RTX2080";
            CoreSpeed = 1800;
            Memory = 8;
        }
    }
}
