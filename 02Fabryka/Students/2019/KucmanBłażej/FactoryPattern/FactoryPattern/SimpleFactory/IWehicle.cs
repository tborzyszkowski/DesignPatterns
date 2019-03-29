using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.SimpleFactory
{
    public interface IWehicle
    {
        string Name { get; set; }
        int Price { get; set; }
        int Speed { get; set; }
        int Horsepower { get; set; }

        void getSound();
    }

}
