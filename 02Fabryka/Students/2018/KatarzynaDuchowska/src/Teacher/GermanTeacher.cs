using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Teacher
{
    public class GermanTeacher : ITeacher
    {
        public void Teach()
        {
            Console.WriteLine("Ich bin, du bist, er/sie/es ist...");
        }
    }
}
