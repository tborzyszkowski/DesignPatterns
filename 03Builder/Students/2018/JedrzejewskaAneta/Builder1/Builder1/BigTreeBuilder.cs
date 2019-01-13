using System;
using System.Collections.Generic;
using System.Text;

namespace Builder1
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

        public override void GrowLeaves()
        {
            tree["leaves"] = "many leaves";
        }
    }
}
