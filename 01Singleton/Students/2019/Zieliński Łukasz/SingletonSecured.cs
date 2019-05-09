using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton{
    public class SingletonSecured{
        private static SingletonSecured SInstance = null;
        public static int counter = 0;
        private static readonly object locked = new object();
        
        public static SingletonSecured getInstance(){
            lock (locked){   
                if (SInstance == null){
                    counter++;
                    SInstance = new SingletonSecured();
                }
                return SInstance;
            }
        }
    }
}
