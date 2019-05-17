using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern.ex2
{
    public class Swap
    {
        public string SwapMethod(string value)
        {
            char[] buffer = value.ToCharArray();
            for (int i = 0; i < buffer.Length-1; i += 2)
            {
                char letter = buffer[i];
                buffer[i] = buffer[i + 1];
                buffer[i + 1] = letter; 

            }
            return new string(buffer);
        }
    }
}
