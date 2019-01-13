using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Teacher
{
    public class EnglishTeacher : ITeacher
    {
        public void Teach()
        {
            Console.WriteLine("I am, you are, he/she/it is...");
        }
    }
}
