using System;

namespace Builder2
{
    class Program
    {
        static void Main(string[] args)
        {
            Garden garden = new Garden();
            Tree bigTree = garden.Construct(new BigTreeBuilder());
            bigTree.Show();
            garden.Construct(new MediumTreeBuilder()).Show();
            Console.ReadKey();
        }
    }
}
