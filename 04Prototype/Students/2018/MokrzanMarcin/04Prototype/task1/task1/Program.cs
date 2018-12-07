using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            NPC npcOne = new NPC();
            npcOne.Health = "100Hp";
            npcOne.Money = "150$";
            npcOne.Status = "Alive";

            NPC npcTwo = new NPC();
            npcTwo.Health = "90Hp";
            npcTwo.Money = "450$";
            npcTwo.Status = "Alive";

            Console.WriteLine("Original npcOne: ");
            Console.WriteLine("Health: {0}, Money: {1}, Status: {2}",
                npcOne.Health,
                npcOne.Money,
                npcOne.Status
                );

            Console.WriteLine("Original npcTwo: ");
            Console.WriteLine("Health: {0}, Money: {1}, Status: {2}",
                npcTwo.Health,
                npcTwo.Money,
                npcTwo.Status
                );

            NPC npcOneClone = npcOne.Clone() as NPC;
            NPC npcTwoClone = npcTwo.Clone() as NPC;
            Console.WriteLine("");
            Console.WriteLine("Clone npcOneClone: ");
            Console.WriteLine("Health: {0}, Money: {1}, Status: {2}",
                npcOneClone.Health,
                npcOneClone.Money,
                npcOneClone.Status
                );

            Console.WriteLine("Clone npcTwoClone: ");
            Console.WriteLine("Health: {0}, Money: {1}, Status: {2}",
                npcTwoClone.Health,
                npcTwoClone.Money,
                npcTwoClone.Status
                );

            Console.ReadKey();
        }
    }
}
