using System;
using AbstractFactory.Factories;

namespace AbstractFactory.Model
{
    public class Good : IEntity
    {
        public string Name { get; set; }

        public Tuple<Insert, Select> GenerateQueries(SimpleFactory factory)
        {
            Insert insert = factory.GenerateGoodInsert(this);
            Select select = factory.GenerateGoodSelect(this);
            Tuple<Insert, Select> resultTup = new Tuple<Insert, Select>(insert, select);
            return resultTup;
        }
    }
}
