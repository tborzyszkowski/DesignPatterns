namespace Factory.Model
{
    public abstract class BaseVehicle
    {
        public abstract string Name { get; }
        public abstract int Wheels { get; }
        public abstract bool HasEngine { get; }
    }
}
