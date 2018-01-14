using System.Collections.Generic;
using System.Linq;
using CarsCms.Interfaces;
using CarsCms.Models;
using CarsCms.Repository.Interfaces;
using CarsCms.ViewModels;

namespace CarsCms.Builders
{
    public class CarVMBuilder : BuilderAbstract<VMCars>, ICarVMBuilder
    {
        private readonly ICarsRepository _carsRepository;
        private readonly ICarBusinessLogic _businessLogic;
        public CarVMBuilder
            (
                ICarsRepository carsRepository,
                ICarBusinessLogic businessLogic
            )
        {
            _carsRepository = carsRepository;
            _businessLogic = businessLogic;
        }
        public CarVMBuilder Initialize()
        {
            Prototype = new VMCars
            {
                Car = new CarEntity(),
                CarList = new List<CarEntity>()
            };

            return this;
        }


        public CarVMBuilder SetAllCars()
        {
            Prototype.CarList = _businessLogic.CheckIfUserIsAutorize()
                ? _carsRepository.GetWhere(x => x.Id > 0)
                : _carsRepository.GetWhere(x => x.Id > 0 && x.IsActive);
            return this;
        }
        public CarVMBuilder SetSingleCar(int? id)
        {
            Prototype.Car = _carsRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();

            return this;
        }



        public CarVMBuilder SetEnableAllCars()
        {
            Prototype.ShowIfAuth = _businessLogic.CheckIfUserIsAutorize();
            return this;
        }
    }
}