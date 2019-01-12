using System;
using System.Collections.Generic;
using System.Text;

namespace Builder1
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

        public override void GrowLeaves()
        {
            tree["leaves"] = "normal number of leaves";
        }
    }
}
