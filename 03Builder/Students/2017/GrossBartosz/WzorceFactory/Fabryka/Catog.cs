using System.Collections.Generic;
using WzorceFactory.Animals;
using WzorceFactory.Utils;

namespace WzorceFactory.Fabryka
{
    internal class Catog : Animal
    {
        public override string Name => "Andrzej Dudan";

        public List<string> AndrzejDudanHistory = new List<string>() {"Country : Israel", "Profession : Secret" };

        protected override string Kind => "Genetic modified ultra best president";
        protected override FurType Fur => FurType.Thin;

        public Catog()
        {
        }

        public override string ToString()
        {
            return $"Name : {Name} \n Kind : {Kind} \n FurType : {Fur} \n History: {AndrzejDudanHistory}";
        }
    }
}