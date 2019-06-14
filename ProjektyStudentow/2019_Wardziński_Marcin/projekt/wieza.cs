using System;
using System.Collections.Generic;
using System.Text;

namespace projekt
{
    [Serializable]
    public class wieza
    {
        private int pancerz;
        private dzialo dzialo;

        public wieza(int a, dzialo b)
        {
            pancerz = a;
            dzialo = b;
        }
    }
}
