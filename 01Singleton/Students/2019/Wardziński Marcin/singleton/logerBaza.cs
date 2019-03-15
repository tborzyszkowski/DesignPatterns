using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    public class logerBaza<T> where T : class, new()
    {
        private static readonly object @object = new object();
        private static T instancja;
        protected logerBaza() { }

        public static T dajLogera
        {
            get
            {
                if (instancja == null)
                {
                    lock (@object)
                    {
                        if (instancja == null)
                        {
                            instancja = new T();
                        }
                    }            
                }
                return instancja;
            }
        }

        public void loguj()
        {
            Console.WriteLine("baza sobie pisze");
        }

        public void okresl()
        {
            Console.WriteLine(this.GetType());
        }
    }
}
