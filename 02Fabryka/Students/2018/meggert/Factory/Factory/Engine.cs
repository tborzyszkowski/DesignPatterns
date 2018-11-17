using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Factory
{
    public class Engine
    {
        public virtual void eng() { }
    }
    public class TraxasEngine : Engine
    {
        public override void eng()
        {
            Console.WriteLine("Silnik szczotkowy");
        }

    }

    public class HpiEngine : Engine
    {
        public override void eng()
        {
            Console.WriteLine("Silnik bezszczotkowy");
        }
    }
}
