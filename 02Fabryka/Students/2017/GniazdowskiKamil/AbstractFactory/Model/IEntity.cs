using AbstractFactory.Factories;
using System;

namespace AbstractFactory.Model
{
    public interface IEntity
    {
        Tuple<Insert, Select> GenerateQueries(SimpleFactory factory);
    }
}
