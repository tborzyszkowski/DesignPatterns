using AbstractFactory.Db;
using AbstractFactory.Model;

namespace AbstractFactory.Factories
{
    public interface IQueryFactory
    {
        void PrepareQuery(IEntity entity, ref Insert query);
        void PrepareQuery(IEntity entity, ref Select query);
    }
}
