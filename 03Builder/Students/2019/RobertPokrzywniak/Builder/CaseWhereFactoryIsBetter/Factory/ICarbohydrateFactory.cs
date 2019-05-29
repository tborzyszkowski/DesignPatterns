
using Builder.CaseWhereFactoryIsBetter.Carbohydrates.Groats;
using Builder.CaseWhereFactoryIsBetter.Carbohydrates.Potatoes;

namespace Builder.CaseWhereFactoryIsBetter.Factory
{
    public interface ICarbohydrateFactory
    {
        Potato CreatePotato(string type);
        Groat CreateGroat();
    }
}
