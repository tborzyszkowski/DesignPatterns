using System;
using System.Collections.Generic;
using System.Text;

namespace Builder2
{
    abstract class TreeBuilder
    {
        protected Tree tree;
        
        Tree Tree
        {
            get
            {
                return tree;
            }
        }
        
        public abstract TreeBuilder GrowRoot();
        public abstract TreeBuilder GrowBark();
        public abstract TreeBuilder GrowBranches();
        public abstract TreeBuilder GrowLeaves();

        public static implicit operator Tree(TreeBuilder treeBuilder)
        {
            return treeBuilder.GrowRoot()
                .GrowBark()
                .GrowBranches()
                .GrowLeaves()
                .Tree;
        }
    }
}
