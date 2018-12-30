using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.zad2
{
    public class Telephone
    {
        public void MakeACall(String message)
        {
            Random rand = new Random();
            int p = rand.Next(100);
            if (p < 30)
            {
                throw new Exception("Line is busy");
            }

            Console.WriteLine("Message passed");
        }
    }
}
