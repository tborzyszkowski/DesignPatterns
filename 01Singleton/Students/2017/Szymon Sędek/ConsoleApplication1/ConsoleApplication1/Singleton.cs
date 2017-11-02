using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public abstract class Singleton<T> where T: class,new ()
    {
        public static T Instance { get; } = new T();

        protected Singleton()
        {
            if (Instance != null)
                throw new Exception("juz istnieje jedna instancja");
        }

        public void Draw()
        {
            Console.WriteLine("Cos tam draw");
        }
    }
}
