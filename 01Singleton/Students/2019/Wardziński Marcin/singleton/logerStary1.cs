using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    public class logerStary1 : logerBaza<logerStary1>
    {
        //private logerStary1() : base() { }

        new public void loguj()
        {
            Console.WriteLine("ociec jeden pisze");
        }
    }
}
