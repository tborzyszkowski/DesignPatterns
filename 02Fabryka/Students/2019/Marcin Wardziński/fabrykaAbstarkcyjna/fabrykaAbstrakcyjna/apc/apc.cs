using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fabrykaAbstrakcyjna.apc
{
    public abstract class apc
    {
        public String nazwa { get; protected set; }
        public decimal kaliber { get; protected set; }
        public int desant { get; protected set; }

        public void ostrzelaj()
        {
            Console.WriteLine(nazwa + " prowadzi ostrzał z działa " + kaliber + "mm.");
        }

        public void wyzadzDesant()
        {
            Console.WriteLine(nazwa + " wysadził desant w liczbie " + desant + "osób.");
        }
    }
}
