using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    sealed class Save //Singleton
    {
        static readonly object myLock = new object();
        static Save instance;
        static DateTime date;
        static string userName;
        static IMap map;
        private Save(string name, IMap currentMap)
        {
            date = DateTime.Now;
            userName = name;
            map = currentMap;

        }
        public static Save GetInstance(string name, IMap map)
        {
            if (instance == null)
            {
                lock (myLock)
                {
                    if (instance == null)
                    {
                        instance = new Save(name, map);
                    }
                }
            }
            return instance;
        }

        public override string ToString()
        {
            return "Player's name: " + userName + ", date of creating save: " + date + ", map: \n" + map.ToString();
        }
    }
}
