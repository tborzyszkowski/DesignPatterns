using System;

namespace Prototype.DeepPrototype
{
    [Serializable]
    public class Restaurant : Prototype<Restaurant>
    {
        public Kitchen Kitchen { get; set; }

        public Restaurant(Kitchen kitchen)
        {
            Kitchen = kitchen;
        }
    }
}
