using System;

namespace Prototype.DeepPrototype
{
    [Serializable]
    public class Chef
    {
        public Assistant Assistant { get; set; }

        public Chef(Assistant assistant)
        {
            Assistant = assistant;
        }
    }
}
