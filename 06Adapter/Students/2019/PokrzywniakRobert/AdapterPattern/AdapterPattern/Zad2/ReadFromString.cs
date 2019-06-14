using AdapterPattern.Zad2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Zad2
{
    public class ReadFromString
    {
        public IList<Point> GetPoints(string value)
        {
            var points = new List<Point>();
            var point = new Point();
            int index = 0;
            foreach (var line in value.Split(','))
            {
                if(index % 2 == 0)
                {
                    point.X = int.Parse(line);
                }
                else
                {
                    point.Y = int.Parse(line);
                    points.Add(point);
                    point = new Point();
                }
                index++;
            }
            return points;
        }
    }
}
