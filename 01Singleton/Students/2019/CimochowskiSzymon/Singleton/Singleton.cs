using System;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Singleton
    {
        private static readonly Singleton instanceSingleton = new Singleton();

        private Singleton() { }

        public static Singleton getInstance()
        {
            return instanceSingleton;
        }

    }
}
