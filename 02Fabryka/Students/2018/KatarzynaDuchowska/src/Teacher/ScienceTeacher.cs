using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Teacher
{
    public class ScienceTeacher : ITeacher
    {
        public void Teach()
        {
            Console.WriteLine("F = ma");
        }
    }
}
