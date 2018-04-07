namespace Prototype
{
    public abstract class ComputerPrototype
    {
        public abstract ComputerPrototype DeepClone();
        public abstract object ShallowClone();
    }
}
