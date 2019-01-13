using System;
using System.Collections.Generic;
using System.Text;

namespace Builder2
{
    class BigTreeBuilder : TreeBuilder
    {
        public BigTreeBuilder()
        {
            tree = new Tree("big");
        }

        public override TreeBuilder GrowRoot()
        {
            tree["root"] = "big root";
            return this;
        }

        public override TreeBuilder GrowBark()
        {
            tree["bark"] = "bold bark";
            return this;
        }

        public override TreeBuilder GrowBranches()
        {
            tree["branches"] = "many branches";
            return this;
        }

        public override TreeBuilder GrowLeaves()
        {
            tree["leaves"] = "many leaves";
            return this;
        }
    }
}
