using AbstractFactory.Model;

namespace AbstractFactory
{
    class ContractorAbstractFactory : IQueryAbstractFactory
    {
        public Insert GenerateInsert(IEntity entity)
        {
            var query = new ContractorInsert();
            query.Value = string.Format("INSERT INTO Contractor (Name) VALUES ('{0}');", (entity as Contractor).Name);
            return query;
        }

        public Select GenerateUpdate(IEntity entity)
        {
            var query = new GoodSelect();
            query.Value = string.Format("SELECT * FROM Contractor WHERE Name = '{0}';", (entity as Contractor).Name);
            return query;
        }
    }
}
