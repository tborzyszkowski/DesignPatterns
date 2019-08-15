using System;
using System.Collections.Generic;
using System.Text;

namespace projekt
{
    public class magazyn
    {
        private int zawartosc;

        public magazyn()
        {
            zawartosc = 100;
        }

        public bool czyStarczy(int i)
        {
            if (zawartosc < i)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void dostawa(int i)
        {
            zawartosc += i;
        }

        public void zapotrzebowanie(int i)
        {
            zawartosc -= i;
        }
    }
}
