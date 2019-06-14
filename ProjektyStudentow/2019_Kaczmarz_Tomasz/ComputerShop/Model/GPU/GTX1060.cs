using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Model.GPU
{
    class GTX1060 : GPU
    {
        public GTX1060()
        {
            Make = "Nvidia";
            Model = "GeForce GTX1060";
            CoreSpeed = 1708;
            Memory = 6;
        }
    }
}
