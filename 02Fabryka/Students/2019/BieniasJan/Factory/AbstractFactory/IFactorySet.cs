using Factory.MilitaryVehicles.Tanks;
using Factory.MilitaryVehicles.Warplanes;
using Factory.MilitaryVehicles.Warships;

//The abstract factory interface declares a set of methods that
//return different abstract products. These products are called
//a family and are related by a high-level theme or concept.
//Products of one family are usually able to collaborate among
//themselves. A family of products may have several variants,
//but the products of one variant are incompatible with the
//products of another variant.
namespace Factory.AbstractFactory
{
    public interface IFactorySet
    {
        Tank CreateTank();
        Warplane CreateWarplane();
        Warship CreateWarship();
    }
}
