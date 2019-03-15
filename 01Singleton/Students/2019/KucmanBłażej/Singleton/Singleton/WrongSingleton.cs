using System;

namespace Singleton
{
    public class WrongSingleton
    {
        private static WrongSingleton objectWrongSingleton = null;

        private WrongSingleton() { }
        public static int counter = 0;

        public static WrongSingleton GetOn()
        {
            if (objectWrongSingleton == null)
            {
                counter++;
                objectWrongSingleton = new WrongSingleton();
            }
            return objectWrongSingleton;
        }
        public static void Delete()
        {
            objectWrongSingleton = null;
        }
    }
}
