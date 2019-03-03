using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGZAMIN
{
    class Megatron
    {
        protected List<string> Raport = new List<string>();
        protected string wplyw;


        public void Info()
        {
            foreach (var dd in wplyw)
            {
                Console.WriteLine(dd);
            }
        }
    }
}
