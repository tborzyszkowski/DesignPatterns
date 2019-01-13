using System;
using System.Collections.Generic;
using System.Text;

namespace Builder2
{
    class MediumTreeBuilder : TreeBuilder
    {
        public MediumTreeBuilder()
        {
            tree = new Tree("medium");
        }

        public override TreeBuilder GrowRoot()
        {
            tree["root"] = "normal root";
            return this;
        }

        public override TreeBuilder GrowBark()
        {
            tree["bark"] = "normal bark";
            return this;
        }

        public override TreeBuilder GrowBranches()
        {
            tree["branches"] = "normal number of branches";
            return this;
        }

        public override TreeBuilder GrowLeaves()
        {
            tree["leaves"] = "normal number of leaves";
            return this;
        }
    }
}
