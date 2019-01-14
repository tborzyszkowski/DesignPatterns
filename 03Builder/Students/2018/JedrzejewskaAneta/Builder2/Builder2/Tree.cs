using System;
using System.Collections.Generic;
using System.Text;

namespace Builder2
{
    class Tree
    {
        private string treeSize;
        private Dictionary<string, string> elements =
          new Dictionary<string, string>();

        public Tree(string treeSize)
        {
            this.treeSize = treeSize;
        }

        public string this[string key]
        {
            get
            {
                return elements[key];
            }
            set
            {
                elements[key] = value;
            }
        }

        public void Show()
        {
            Console.WriteLine("Tree size: {0}", treeSize);
            Console.WriteLine(" Leaves : {0}", elements["leaves"]);
            Console.WriteLine(" Root : {0}", elements["root"]);
            Console.WriteLine(" Bark: {0}", elements["bark"]);
            Console.WriteLine(" Branches : {0}", elements["branches"]);
        }
    }
}
