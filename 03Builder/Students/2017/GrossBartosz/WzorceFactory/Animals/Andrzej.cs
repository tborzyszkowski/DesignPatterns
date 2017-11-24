using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WzorceFactory.Fabryka;
using WzorceFactory.Utils;

namespace WzorceFactory.Animals
{
    public class Andrzej : Animal
    {
        public override string Name => "Andrzej Dudan";

        public List<string> AndrzejDudanHistory = new List<string>() { "Country : Israel", "Profession : Secret" };

        protected override string Kind => "Genetic modified ultra best president";
        protected override FurType Fur => FurType.Thin;

        public Andrzej()
        {
        }

        public override string ToString()
        {
            return $"Name : {Name} \n Kind : {Kind} \n FurType : {Fur} \n History: \n{string.Join("\n", AndrzejDudanHistory.ToArray())}";
        }
    }
}
