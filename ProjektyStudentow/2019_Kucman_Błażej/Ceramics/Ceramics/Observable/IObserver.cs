using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceramics.Observable
{
    public interface IObserver
    {
       void update(PlateObservable plateObservable);
    }
}
