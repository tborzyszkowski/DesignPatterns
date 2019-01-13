using System;

namespace Builder1
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeBuilder builder;

            Garden garden = new Garden();
            
            builder = new BigTreeBuilder();
            garden.Construct(builder);
            builder.Tree.Show();

            builder = new MediumTreeBuilder();
            garden.Construct(builder);
            builder.Tree.Show();

            builder = new SmallTreeBuilder();
            garden.Construct(builder);
            builder.Tree.Show();

            Console.ReadKey();
        }
    }
}
