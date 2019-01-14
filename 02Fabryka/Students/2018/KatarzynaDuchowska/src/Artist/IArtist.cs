using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Artist
{
    public interface IArtist : IPerson
    {
        void DoArt();
    }
}
