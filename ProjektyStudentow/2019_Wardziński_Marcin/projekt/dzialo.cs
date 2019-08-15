using System;
using System.Collections.Generic;
using System.Text;

namespace projekt
{
    [Serializable]
    public class dzialo
    {
        private int kaliber;
        private int dlugosc;

        public dzialo(int a, int b)
        {
            kaliber = a;
            dlugosc = b;
        }
    }
}
