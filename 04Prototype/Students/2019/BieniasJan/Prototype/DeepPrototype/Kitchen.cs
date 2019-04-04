using System;

namespace Prototype.DeepPrototype
{
    [Serializable]
    public class Kitchen
    {
        public Chef Chef { get; set; }

        public Kitchen(Chef chef)
        {
            Chef = chef;
        }
    }
}
