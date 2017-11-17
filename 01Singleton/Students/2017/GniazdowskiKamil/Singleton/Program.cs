using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            MainLogger.Instance.Log("Pierwszy log");
            PrivateLogger.Instance.Log("Log prywatny");

            Console.WriteLine(MainLogger.LastLog);
            Console.WriteLine(PrivateLogger.LastLog);

            Console.ReadKey();
        }
    }
}
