using System;
using AbstractFactory.Factories;

namespace AbstractFactory.Model
{
    public class Contractor : IEntity
    {
        public string Name { get; set; }

        public Tuple<Insert, Select> GenerateQueries(SimpleFactory factory)
        {
            Insert insert = factory.GenerateContractorInsert(this);
            Select select = factory.GenerateContractorSelect(this);
            Tuple<Insert, Select> resultTup = new Tuple<Insert, Select>(insert, select);

            return resultTup;
        }
    }
}
