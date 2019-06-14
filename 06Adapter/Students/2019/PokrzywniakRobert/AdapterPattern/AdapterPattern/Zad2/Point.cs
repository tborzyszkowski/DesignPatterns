using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.Zad2
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int GetDistance(Point point)
        {
            return (point.X - X) * (point.X - X) + (point.Y - Y) * (point.Y - Y);
        }
    }
}
