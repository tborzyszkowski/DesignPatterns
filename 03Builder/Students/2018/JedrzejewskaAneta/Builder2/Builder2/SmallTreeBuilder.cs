using System;
using System.Collections.Generic;
using System.Text;

namespace Builder2
{
    class SmallTreeBuilder : TreeBuilder
    {
        public SmallTreeBuilder()
        {
            tree = new Tree("small");
        }

        public override TreeBuilder GrowRoot()
        {
            tree["root"] = "small root";
            return this;
        }

        public override TreeBuilder GrowBark()
        {
            tree["bark"] = "thin bark";
            return this;
        }

        public override TreeBuilder GrowBranches()
        {
            tree["branches"] = "few branches";
            return this;
        }

        public override TreeBuilder GrowLeaves()
        {
            tree["leaves"] = "few leaves";
            return this;
        }
    }
}
