using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderTeam
{
    class Program
    {
        static void Main(string[] args)
        {
            Team t1 = new Team("Name 1", "Trener 1", Color.Red, "Gdańsk", "Football");
            t1.Show();
            TeamBuilder tb = new TeamBuilder();

            Team t2 = tb.CreateTeam("Name2")
                .WithTrener("Trener 2")
                .WithShirtColor(Color.Green)
                .WithCity("Gdynia")
                .AndType("Voleyball");
            t2.Show();

            Team t3 = tb.CreateTeam("Name3")
                .WithTrener("Trener 3")
                .WithShirtColor(Color.White)
                .WithCity("Gdańsk")
                .AndType("Basketball");
            t3.Show();


            Console.ReadKey();
        }
    }
}
