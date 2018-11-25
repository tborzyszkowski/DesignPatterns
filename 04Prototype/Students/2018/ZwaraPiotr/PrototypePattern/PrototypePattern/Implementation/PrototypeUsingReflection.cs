using PrototypePattern.Abstraction;
using PrototypePattern.Helpers;

namespace PrototypePattern.Implementation
{
    public class PrototypeUsingReflection : BasePrototype<PrototypeUsingReflection>
    {
        public override PrototypeUsingReflection DeepClone()
        {
            return new DeepCopier(this).Copy() as PrototypeUsingReflection;
        }
    }
}
