using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Car1 
    {
        Create creating = new Create();
        public string Battery { get; set; }
        public Create Creating
        {
            get { return creating; }
            set { creating = value; }
        }
    }

    public class Car2 
    {
        public Car1 obj;
        Create creating = new Create();
   
        public Create Creating {
            get { return creating; }
            set { creating = value; }
        }

        public Car2()
        {
            obj = new Car1();
        }


        public Car2 DeepCopy()
        {
            Car2 cloned = new Car2();
            cloned.obj.Battery = this.obj.Battery;

            cloned.Creating = new Create();
            cloned.Creating.Company = this.Creating.Company;
            cloned.Creating.Engine = this.Creating.Engine;

            return cloned;
        }

        
    }
}
