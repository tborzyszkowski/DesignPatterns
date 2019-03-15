using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    public class logerMlody1 : logerStary1
    {
        //private logerMlody1() : base() { }

        new public void loguj()
        {
            Console.WriteLine("syn jeden pisze");
        }
    }
}
