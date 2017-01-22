using System;

namespace Mewa
{
    public class Kaczka : Samolot, IStatek
    {
        // samolot: WPowietrzuX, StartowanieX, WysokośćX
        // statek: Prędkość, ZwiększObrotyX 
        int prędkość = 0;

        public new bool WPowietrzu
        {
            get { return Wysokość > 50; }
        }


        int IStatek.Prędkość
        {
            get
            {
                return prędkość; 
            }
        }
       
        public void ZwiększObroty()
        {
            prędkość += 20;
            Console.WriteLine("Prędkość kaczki " + prędkość + " węzłów");
            if (WPowietrzu)
            {
                Wysokość += 100;
                Console.WriteLine("Wysokość lotu " + Wysokość + " metrów.");
            }
        }

        public override void Startowanie()
        {
            base.Startowanie();
            ZwiększObroty();
        }

    }
}
