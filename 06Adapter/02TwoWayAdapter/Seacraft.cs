using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02TwoWayAdapter {
    // Adaptee implementation
    public class Seacraft : ISeacraft {
        int speed = 0;

        public virtual void IncreaseRevs() {
            speed += 10;
            Console.WriteLine("Seacraft engine increases revs to " + speed + " knots");
        }
        public int Speed
        {
            get { return speed; }
        }
    }

}
