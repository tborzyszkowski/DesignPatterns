using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace AdapterPattern.ex2
{
    public class AdapterEncryption
    {
        public Func<string,string> Encryption;

        public AdapterEncryption(Swap adapterSwap)
        {
            Encryption = adapterSwap.SwapMethod;
        }
        public AdapterEncryption(CesarChipper adapterCesarChipper)
        {
            Encryption = adapterCesarChipper.Caesar;
        }

        public void ChangeRequest(Func<string,string> func)
        {
            Encryption = func;
        }
        


    }
}
