package korszun.kacper

import korszun.kacper.CarDealerApp.CarType
import org.scalatest.FlatSpec


class CarDealerAppTest extends FlatSpec {

  behavior of "CarDealerApp"

  it should "return MyCar in newCar" in {
    assert(CarDealerApp.newCar(CarType.COUPE).isInstanceOf[MyCar])
  }

  it should  "return proper Type in newCar" in{
    assert(CarDealerApp.newCar(CarType.COUPE).getClass.getSimpleName == "CoupeCar")
    assert(CarDealerApp.newCar(CarType.HATCHBACK).getClass.getSimpleName == "Hatchback")
    assert(CarDealerApp.newCar(CarType.VAN).getClass.getSimpleName == "VanCar")
  }

}

