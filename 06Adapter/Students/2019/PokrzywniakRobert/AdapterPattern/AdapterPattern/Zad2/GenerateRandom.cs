using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Zad2
{
    public static class GenerateRandom
    {
        public static IList<Point> GetPoints()
        { 
            var points = new List<Point>();
            for (int i = 0; i < 10; i++)
            {
                Random rnd = new Random();
                var point = new Point
                {
                    X = rnd.Next(0, 10),
                    Y = rnd.Next(0, 10)
                };
                if (points.Exists(x => x.Y == point.Y && x.X == point.X))
                {
                    continue;
                }

                points.Add(point);
            }
            return points;
        }
    }
}
