using System;
using System.Collections.Generic;
using System.Text;

namespace Builder1
{
    class Garden
    {
        public void Construct(TreeBuilder treeBuilder)
        {
            treeBuilder.GrowRoot()
                .GrowBark()
                .GrowBranches()
                .GrowLeaves();
        }
    }
}
