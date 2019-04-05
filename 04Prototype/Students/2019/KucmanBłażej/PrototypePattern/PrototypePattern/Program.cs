using PrototypePattern.exercise1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer comp = new Computer("KOKO", "Asrok", "Intel", "500");
            Computer compWrong = comp;
            compWrong.Hdd = "1100";
            Console.WriteLine(comp.Hdd + " i " + compWrong.Hdd);
            Computer compGood = comp.Clone() as Computer;
            compGood.Hdd = "200";
            Console.WriteLine(comp.Hdd + " i " + compGood.Hdd);

            exercise2.Computer compik = new exercise2.Computer("Super",new exercise2.Motherboard("asrock",new exercise2.Chipset("ie3424",new exercise2.Producent("Intel"))),"500GB","s2500PLN");
            exercise2.Computer compikWrong = compik;
            compikWrong.Motherboard.chipset.name = "EE43552";

            Console.WriteLine(compik.Motherboard.chipset.name + " i " + compikWrong.Motherboard.chipset.name);
            exercise2.Computer compikGood = compik.Duplicate() as exercise2.Computer;

            compik.Motherboard.chipset.name = "FE848";
            Console.WriteLine(compik.Motherboard.chipset.name + " i " + compikGood.Motherboard.chipset.name);
            compik.Name = "koko";
            Console.WriteLine(compik.Name + " i " + compikGood.Name);


            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
