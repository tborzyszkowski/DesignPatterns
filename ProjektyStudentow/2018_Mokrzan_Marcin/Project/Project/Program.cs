using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Account user = Account.Instance; //[Singleton] utworzono instancje Gracza o nazwie " + user.name + " i id " + user.id

            Console.WriteLine("Welcome " + user.name + " take a seat and play!");
            ConsoleKeyInfo key;
            Console.WriteLine("Chosen game: (g - Go, c - Chess,  d - draughts)");
            key = Console.ReadKey();
                
            //Console.WriteLine("\n" + "Chosen game: {0}", key.KeyChar);

            Facade facade = new Facade();
            facade.createGame(key.KeyChar, user);
            
            Console.ReadKey();
        }
    }
}
