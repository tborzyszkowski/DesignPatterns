using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Adaptee
    {
        public string Match(string model)
        {
            string device = "";
            if(string.Equals(model, "Dualshock4"))
            {
                InstallDrivers(model);
                device = model;
            }
            else if(string.Equals(model, "XboxOneController"))
            {
                InstallDrivers(model);
                device = model;
            }
            else if(string.Equals(model, "Logitech"))
            {
                InstallDrivers(model);
                device = model;     
            }

            return device;
        }

        private void InstallDrivers(string model)
        {
            Console.WriteLine("Installing drivers for your: " + model);
        }
    }
}
