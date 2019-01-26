using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Teacher
{
    public class PolishTeacher : ITeacher
    {
        public void Teach()
        {
            Console.WriteLine("Słowacki wielkim poetą był!");
        }
    }
}
