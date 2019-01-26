using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class SingletonInheritance
    {
        static Singleton singletonInstance;

        SingletonInheritance()
        {
            singletonInstance = Singleton.GetInstance();
        }

        public static Singleton GetInstance()
        {
            if (singletonInstance != null)
            {
                return singletonInstance;
            }
            else
            {
                return Singleton.GetInstance();
            }
        }
        

    }
}
