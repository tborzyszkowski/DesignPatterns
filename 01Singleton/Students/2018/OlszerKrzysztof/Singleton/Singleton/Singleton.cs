using System;
using System.Threading.Tasks;

namespace Singleton
{
    public class Singleton
    {
        private static Singleton instance;
        public static int count = 0;
        public int x;

        private Singleton()
        { }

        public static Singleton getInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
                count++;
            }
            return instance;
        }

        public static void setNullInstance()
        {
            instance = null;
        }
    }
}
