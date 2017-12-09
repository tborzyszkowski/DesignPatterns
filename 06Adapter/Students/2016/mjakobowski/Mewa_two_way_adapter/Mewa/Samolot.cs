using System;

namespace Mewa
{
    public class Samolot : ISamolot
    {
        int wysokość;
        bool wPowietrzu;
        public Samolot()
        {
            wysokość = 0;
            wPowietrzu = false;
        }

        public virtual void Startowanie()
        {
            Console.WriteLine("Samolot włącza silniki.");
            wPowietrzu = true;
            wysokość = 200;
        }

        public bool WPowietrzu
        {
            get { return wPowietrzu; }
        }

        public int Wysokość
        {
            get { return wysokość; }
            set { wysokość = value; }
        }
    }
}
