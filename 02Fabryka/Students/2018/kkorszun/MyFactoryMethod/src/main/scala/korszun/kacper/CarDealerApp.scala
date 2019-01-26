package korszun.kacper

import  scala.collection.mutable

object CarDealerApp {
  private case class CoupeCar(id: String , modelSymbol : String, modelName: String,
                              carBrand: CarBrand.BrandValue, parkingSpotNumber: Int) extends MyCar
  private case class VanCar(id: String , modelSymbol : String, modelName: String,
                            carBrand: CarBrand.BrandValue, parkingSpotNumber: Int) extends MyCar
  private case class Hatchback(id: String , modelSymbol : String, modelName: String,
                               carBrand: CarBrand.BrandValue, parkingSpotNumber: Int) extends MyCar

  private sealed trait CarCreator{
    def factoryMethod: MyCar

    def createAndPrintInfo() = {
      val carx = factoryMethod
      println("-- Car---------")
      println("brand: "+ carx.carBrand)
      println("model: "+carx.modelName)
      println("-------------------")
      carx
    }

  }


  private object CoupeCreator extends CarCreator{
    override def factoryMethod: MyCar = {
      val parkingSpotNumber = ParkingSpotGenerator.getSpot
      parkingSpotNumber match {
        case Some(_) => new CoupeCar(DealerCarIdGeneretor.getId(), "200_Gulia",
          "Gulia", CarBrand.ALFA_ROMEO, parkingSpotNumber.get)
      }

    }
  }

  private object HatchbackCreator extends CarCreator{
    override def factoryMethod: MyCar = {
      val parkingSpotNumber = ParkingSpotGenerator.getSpot
      parkingSpotNumber match {
        case Some(_) => new Hatchback(DealerCarIdGeneretor.getId(), "300_Panda",
          "Panda", CarBrand.FIAT, parkingSpotNumber.get)
      }
    }
  }

  private  object VanCreator extends CarCreator {
    val START_NUMBER = 123
    var counter = 0
    override def factoryMethod: MyCar = {
      val parkingSpotNumber = ParkingSpotGenerator.getSpot
      parkingSpotNumber match {
        case Some(_) => {
          counter += 1
          new VanCar("van_"+(START_NUMBER+counter),"100_Sienna", "Sienna", CarBrand.TOYOTA, parkingSpotNumber.get)
        }
      }

    }
  }

  object CarType {
    sealed  trait TypeValue
    case object COUPE extends  TypeValue
    case object HATCHBACK extends TypeValue
    case object VAN extends TypeValue
    val carTypeValues = Seq(COUPE, HATCHBACK, VAN)
  }

  private var currentCar : MyCar = _
  private var carsSeq : mutable.MutableList[MyCar] = mutable.MutableList()


  def addCurrentToBase:Unit = {
    carsSeq += currentCar
  }
  def createNewCar(carType: CarType.TypeValue) = carType match{
    case CarType.COUPE => {
      currentCar = CoupeCreator.createAndPrintInfo()
    }
    case CarType.HATCHBACK => {
      currentCar = HatchbackCreator.createAndPrintInfo()
    }
    case CarType.VAN => {
      currentCar = VanCreator.createAndPrintInfo()
    }
  }
  def newCar(carType: CarType.TypeValue): MyCar ={
    carType match {
      case CarType.COUPE => CoupeCreator.factoryMethod
      case CarType.HATCHBACK => HatchbackCreator.factoryMethod
      case CarType.VAN => VanCreator.factoryMethod
    }

  }
  def addGivenToBase(yourCar: MyCar)={
    carsSeq += yourCar
  }
}

