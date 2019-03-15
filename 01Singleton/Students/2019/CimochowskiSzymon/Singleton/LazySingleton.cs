using System;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public sealed class LazySingleton
    {
        private static LazySingleton instanceSingleton;

        public static int counter { get; set; }

        private LazySingleton()
        {
            counter++;
        }

        public static LazySingleton getInstance()
        {
            if (instanceSingleton == null)
            {
                instanceSingleton = new LazySingleton();
            }

            return instanceSingleton;
        }

        public int getCounter()
        {
            return counter;
        }
    }
}