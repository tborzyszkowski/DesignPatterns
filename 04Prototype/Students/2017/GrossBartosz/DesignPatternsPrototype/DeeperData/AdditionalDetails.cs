using System;

namespace DesignPatternsPrototype.DeeperData
{
    [Serializable()]
    public class AdditionalDetails
    {
        private int height;
        private int weight;

        private DeeperData deeperData = new DeeperData("aaa");

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public DeeperData DeeperData
        {
            get { return deeperData; }
            set { deeperData = value; }
        }
    }
}