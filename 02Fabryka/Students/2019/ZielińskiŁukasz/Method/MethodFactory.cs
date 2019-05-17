using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory;

namespace Factory.Method
{
    public abstract class MethodFactory
    {
        protected abstract Ships CreateFrigate(string frigate);
        protected abstract Ships CreateCruiser(string cruiser);
        protected abstract Ships CreateCapitalShip(string capital);

        public Ships BuildFrigate(string frigate)
        {
            return CreateFrigate(frigate);
        }
        public Ships BuildCruiser(string cruiser)
        {
            return CreateCruiser(cruiser);
        }
        public Ships BuildCapitalShip(string capital)
        {
            return CreateCapitalShip(capital);
        }
    }
}
