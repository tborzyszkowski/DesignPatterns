using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metodaWytworcza
{
    public interface Ipojazd
    {
        String nazwa { get; }
        decimal kaliber { get; }

        void ostrzelaj();
    }
}
