using WzorceFactory.Utils;

namespace WzorceFactory.Fabryka
{
    public abstract class Animal
    {
        public abstract string Name { get; }

        protected abstract string Kind { get; }

        protected abstract FurType Fur { get; }

        public override string ToString()
        {
            return $"Name : {Name} \n Kind : {Kind} \n FurType : {Fur}";
        }

    }
}
