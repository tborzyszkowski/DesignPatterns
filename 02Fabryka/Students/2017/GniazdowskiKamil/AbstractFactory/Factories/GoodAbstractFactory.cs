using AbstractFactory.Model;

namespace AbstractFactory
{
    class GoodAbstractFactory : IQueryAbstractFactory
    {
        public Insert GenerateInsert(IEntity entity)
        {
            var query = new GoodInsert();
            query.Value = string.Format("INSERT INTO Good (Name) VALUES ('{0}');", (entity as Good).Name);
            return query;
        }

        public Select GenerateUpdate(IEntity entity)
        {
            var query = new GoodSelect();
            query.Value = string.Format("SELECT * FROM Good WHERE Name = '{0}';", (entity as Good).Name);
            return query;
        }
    }
}
