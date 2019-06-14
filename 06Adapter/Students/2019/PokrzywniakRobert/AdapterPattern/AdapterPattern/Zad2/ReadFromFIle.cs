using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Zad2
{
    public class ReadFromFile
    {
        public IList<Point> GetPoints()
        {
            var lines = File.ReadLines("points.txt");
            var points = new List<Point>();
            foreach (var line in lines)
            {
                var splitted = line.Split(',');
                var point = new Point
                {
                    X = int.Parse(splitted[0]),
                    Y = int.Parse(splitted[1])
                };
                points.Add(point);
            }
            return points;
        }
    }
}
