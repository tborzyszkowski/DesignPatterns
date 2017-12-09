using System;
using DesignPatternsPrototype.BaseShallowAndDeep.Prototype;
using DesignPatternsPrototype.DeeperData;

namespace DesignPatternsPrototype.BaseShallowAndDeep.ConcretePrototype
{
    [Serializable()]
    public class PrototypeAnimalDog : PrototypeAnimal<PrototypeAnimalDog>
    {
        public override PrototypeAnimalDog Clone()
        {
            PrototypeAnimalDog cloned = this.MemberwiseClone() as PrototypeAnimalDog;
            cloned.Details = new AdditionalDetails
            {
                Height = this.Details.Height,
                Weight = this.Details.Weight
            };

            return cloned;

        }
    }
}
