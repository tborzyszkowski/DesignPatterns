using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGZAMIN
{
    class Konkretnywizytator : Wizytator
    {
        public override void Konkretnywizytator(
          KonkretnyElemenet konkretnyElemenet)
        {
            Console.WriteLine("{0} visited by {1}",
              konkretnyElemenet.GetType().Name, this.GetType().Name);
        }
    }
}
