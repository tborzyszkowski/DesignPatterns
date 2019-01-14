using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Doctor
{
    public class Cardiologist : IDoctor
    {
        public void Heal()
        {
            Console.WriteLine("<3");
        }
    }
}
