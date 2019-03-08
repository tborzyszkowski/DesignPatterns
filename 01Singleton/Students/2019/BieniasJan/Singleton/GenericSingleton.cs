using System;

//Jan Bienias 238201

/* 
Zaproponować przykładowe rozwiązania dwóch problemów związanych ze wzorcem Singleton:

a) odporność na współbieżne wykorzystanie kodu z jednoczesnym zachowaniem maksymalnej wydajności
b) problem rozszerzania klasy Singleton przez dziedziczenie
c) problem serializacji i deserializacji obiektów klasy Singleton

Do zaproponowanych rozwiązan załączyć odpowiednie testy wydajnościowe / funkcjonalne.
*/

/*
Do rozwiązania wybrano problemy : a) i b)
*/

namespace Singleton
{
    public abstract class GenericSingleton<T> where T : class
    {
        public static int Counter { get; private set; }
        private static readonly Lazy<T> _instance = new Lazy<T>(() => Activator.CreateInstance(typeof(T), nonPublic: true) as T);

        protected GenericSingleton()
        {
            Counter++;
        }

        public static T Instance
        {
            get { return _instance.Value; }
        }
    }
}
