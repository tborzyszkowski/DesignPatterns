using System;

namespace Singleton
{
    public sealed class Singleton
    {
        static private Singleton myInstance;
        Singleton()
        {
        }

        public static Singleton GetInstance()
        {
            if (myInstance == null)
            {
                myInstance = new Singleton();
            }
            return myInstance;

        }

        public override string ToString()
        {
            return "Singleton example";
        }
    }
}