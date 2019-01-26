using System;
using System.Collections.Generic;
using System.Text;

namespace Builder2
{
    class Garden
    {
        public Tree Construct(TreeBuilder treeBuilder)
        {
            return treeBuilder;
        }
    }
}
