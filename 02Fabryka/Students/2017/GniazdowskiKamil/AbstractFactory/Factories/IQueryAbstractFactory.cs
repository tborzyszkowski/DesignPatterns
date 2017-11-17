using AbstractFactory.Model;

namespace AbstractFactory
{
    public interface IQueryAbstractFactory
    {
        Insert GenerateInsert(IEntity entity);
        Select GenerateUpdate(IEntity entity);
    }
}
