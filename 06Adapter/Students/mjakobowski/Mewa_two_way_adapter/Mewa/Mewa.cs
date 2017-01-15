namespace Mewa
{
    public class Mewa : Statek, ISamolot
    {
        int wysokość = 0;

        public int Wysokość
        {
            get { return wysokość; }
        }

        public void Startowanie()
        {
            while (!WPowietrzu)
                ZwiększObroty();
        }

        public override void ZwiększObroty()
        {
            base.ZwiększObroty();
            if (Prędkość > 40)
                wysokość += 100;
        }

        public bool WPowietrzu
        {
            get { return wysokość > 50; }
        }
    }
}
