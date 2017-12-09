using System;

namespace DesignPatternsPrototype.DeeperData
{
    [Serializable()]
    public class DeeperData
    {
        public string Data { get; set; }

        public DeeperData()
        {
            Data = string.Empty;
        }
        public DeeperData(string s)
        {
            Data = s;
        }
    }
}
