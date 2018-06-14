package korszun.kacper
import korszun.kacper.Main.MyEngineer

@SerialVersionUID(100L)
class CarEngine(id: String,
                manufacturer: CarBrand.BrandValue,
                private var carModel: String,
                private var engineer: MyEngineer,
                fuel: Fuel.FuelValue) extends  Serializable {



  def setCarModel(carModelName: String) = { carModel = carModelName}
  def getCarModel = carModel
  def getEngineer = engineer
}
