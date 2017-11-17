using AbstractFactory.Db;
using AbstractFactory.Model;

namespace AbstractFactory
{
    public class Select : Query
    {
        //---Metoda odtwórcza---
        public override void PrepareQuery(Good good)
        {
            this.Value = string.Format("SELECT * FROM Good WHERE Name = '{0}';", good.Name);
        }

        public override void PrepareQuery(Contractor contractor)
        {
            this.Value = string.Format("SELECT * FROM Contractor WHERE Name = '{0}'", contractor.Name);
        }
        //---Metoda odtwórcza---
    }
}
