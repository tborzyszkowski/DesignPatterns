using CarsCms.Builders;
using CarsCms.ViewModels;

namespace CarsCms.Interfaces
{
    public interface ICarVMBuilder : IBuilderAbstract<VMCars>
    {
        CarVMBuilder Initialize();
        CarVMBuilder SetAllCars();
        CarVMBuilder SetEnableAllCars();
        CarVMBuilder SetSingleCar(int? id);
    }
}
