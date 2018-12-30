using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.zad2
{
    public class Pidgeon
    {
        public int Fly(String message)
        {
            Random rand = new Random();
            int distance = rand.Next(100);
            int kilometers = rand.Next(100);

            if (kilometers > distance )
            {
                Console.WriteLine("Pigeon flew {0} kilometers and passed the message", kilometers);
            } else
            {
                Console.WriteLine("Pidgeon did't make it :(");
            }
            
            return kilometers / distance;
        }
    }
}
