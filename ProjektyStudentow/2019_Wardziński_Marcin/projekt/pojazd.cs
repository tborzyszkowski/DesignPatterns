using System;
using System.Collections.Generic;
using System.Text;

namespace projekt
{
    [Serializable]
    public abstract class pojazd : prototyp<pojazd>
    {
        public abstract void akceptuj(Iodwiedzajacy odwiedzajacy);
    }
}
