using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public sealed class SingletonSeald
    {
        private static SingletonSeald _instance;

        public static SingletonSeald Instance => _instance ?? (_instance = new SingletonSeald());

        private SingletonSeald()
        {

        }
    }
}
