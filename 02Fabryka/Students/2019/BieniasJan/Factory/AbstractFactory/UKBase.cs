namespace Factory.AbstractFactory

//The client code works with factories and products only
//through abstract types: IFactorySet, Tank, Warplane and Warship. This
//lets you pass any factory or product subclass to the client
//code without breaking it.
{
    public class UKBase : Base
    {
        public UKBase(IFactorySet factionFactory) : base(factionFactory) { }
        public UKBase() : this(UKFactorySet.Instance) { }
    }
}
