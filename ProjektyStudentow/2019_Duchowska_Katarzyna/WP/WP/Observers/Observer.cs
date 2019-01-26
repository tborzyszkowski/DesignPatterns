using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Observers
{
    public abstract class Observer
    {
        public abstract void Update(double price);
    }
}
