using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace AdapterPattern.Zad2
{
    public class AdapterPoints
    {
        public IList<Point> Points;

        public AdapterPoints(ReadFromFile adapterReadFromFile)
        {
            Points = adapterReadFromFile.GetPoints();
        }
        public AdapterPoints(ReadFromString adapterReadFromString)
        {
            Points = adapterReadFromString.GetPoints("1,2,3,4,5,6,7,8,9,10");
        }

        public void ChangeRequest(IList<Point> points)
        {
            Points = points;
        }
        


    }
}
