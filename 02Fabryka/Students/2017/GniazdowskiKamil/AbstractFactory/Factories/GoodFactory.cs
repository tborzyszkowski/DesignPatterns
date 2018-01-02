using System;
using AbstractFactory.Model;

namespace AbstractFactory.Factories
{
    public class GoodFactory : IQueryFactory
    {
        public void PrepareQuery(IEntity entity, ref Insert query)
        {
            query.PrepareQuery(entity as Good);
        }

        public void PrepareQuery(IEntity entity, ref Select query)
        {
            query.PrepareQuery(entity as Good);
        }
    }
}
