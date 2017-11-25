using AbstractFactory.Model;

namespace AbstractFactory.Factories
{
    public class SimpleFactory
    {
        public Insert GenerateContractorInsert(Contractor contractor)
        {
            var query = new ContractorInsert();
            query.Value = string.Format("INSERT INTO Contractor (Name) VALUES ('{0}');", contractor.Name);
            return query;
        }

        public Select GenerateContractorSelect(Contractor contractor)
        {
            Select query = new Select();
            query.Value = string.Format("SELECT * FROM Contractor WHERE Name = '{0}';", contractor.Name);
            return query;
        }

        public Insert GenerateGoodInsert(Good good)
        {
            var query = new GoodInsert();
            query.Value = string.Format("INSERT INTO Good (Name) VALUES ('{0}');", good.Name);
            return query;
        }

        public Select GenerateGoodSelect(Good good)
        {
            var query = new GoodSelect();
            query.Value = string.Format("SELECT * FROM Good WHERE Name = '{0}';", good.Name);
            return query;
        }
    }
}
