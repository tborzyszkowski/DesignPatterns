using System;
using System.Collections.Generic;
using System.Text;

namespace Builder1
{
    abstract class TreeBuilder
    {
        protected Tree tree;
        
        public Tree Tree
        {
            get
            {
                return tree;
            }
        }
        
        public abstract TreeBuilder GrowRoot();
        public abstract TreeBuilder GrowBark();
        public abstract TreeBuilder GrowBranches();
        public abstract void GrowLeaves();
    }
}
