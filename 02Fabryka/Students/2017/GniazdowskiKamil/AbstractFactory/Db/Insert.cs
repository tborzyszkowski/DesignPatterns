using AbstractFactory.Db;
using AbstractFactory.Model;

namespace AbstractFactory
{
    public class Insert : Query
    {

        //---Metoda odtwórcza---
        public override void PrepareQuery(Good good)
        {
            this.Value = string.Format("INSERT INTO Good (Name) VALUES ('{0}');", good.Name);
        }

        public override void PrepareQuery(Contractor contractor)
        {
            this.Value = string.Format("INSERT INTO Contractor (Name) VALUES ('{0}');", contractor.Name);
        }
        //---Metoda odtwórcza---
    }
}
