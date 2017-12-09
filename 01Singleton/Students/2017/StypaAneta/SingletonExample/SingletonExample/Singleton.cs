using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonExample
{
    //-sealed - uniemozliwa dziedziczenie tej klasy
    //-prywatne statyczne pole ktore zawiera instancje wlasnej klasy z domyslna wart. null
    //-publiczna stat. wlasnosc ktora zwraca obiekt swojejklasy i tworzy ten obiekt
    //-dowolna ilosc metod uzytkowych
    //-prywatny konstruktor ktory zablokuje mozliwosc tworzenia obiektow tej klasy normalna droga i zapewni
    // ze dostep odbywac sie bedzie jedynie za pomoca statycznej wlasciwosci


    public sealed class Singleton
    {
        private static Singleton instance = null;
        private int ile = 0;

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

        public void Print()
        {
            Console.WriteLine("Hello World po raz {0}!", ile++);
        }

        private Singleton()
        {
            ile = 1;
        }
    }
}
