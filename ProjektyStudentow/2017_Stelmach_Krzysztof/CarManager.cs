using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class CarManager
    {
        private Dictionary<string, CarPrototype> _Cars =
          new Dictionary<string, CarPrototype>();

        public CarPrototype this[string key]
        {
            get { return _Cars[key]; }
            set { _Cars.Add(key, value); }
        }
    }
}

