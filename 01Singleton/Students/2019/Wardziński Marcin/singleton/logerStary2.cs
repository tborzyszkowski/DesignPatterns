using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    public class logerStary2 : logerBaza<logerStary2>
    {
        //private logerStary2() : base() { }

        new public void loguj()
        {
            Console.WriteLine("ociec dwa pisze");
        }
    }
}
