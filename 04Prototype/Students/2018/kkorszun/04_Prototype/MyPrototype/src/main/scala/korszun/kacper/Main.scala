package korszun.kacper

import korszun.kacper.CarBrand._
import korszun.kacper.Fuel._

object Main extends App{

  @SerialVersionUID(100L)
  class MyEngineer(private var _firstName : String,
                   private var _secondName: String,
                   private var _diploma : MyDiploma) extends Serializable {
    def firstName = _firstName
    def firstName_(string: String)= {_firstName = string}
    def secondName = _secondName
    def secondName_(string: String) = {_secondName = string}
    def diploma = _diploma
  }

  override def main(args: Array[String]): Unit = {
    println("'Hello there'")
    val numeroUno = new SimpleConcreteClass("1234", 12, 12.5)
    val duo: SimpleConcreteClass = numeroUno.clone.asInstanceOf[SimpleConcreteClass]


    //Different objects, same reference
    numeroUno.printState
    duo.printState
    numeroUno.setV1(11)
    numeroUno.v33.v1 = 13
    numeroUno.printState
    duo.printState
    //Same reference
    println("------------------------")
    println(numeroUno.v33.v1)
    println(duo.v33.v1)


    //Manager
    val alfaDiploma = new MyDiploma("Politechnika Warszawska", 2014)
    val alfaEngineer = new MyEngineer("Adam","Jot", alfaDiploma)
    val alfaEngine = new CarEngine("Gulietta_Engine", FIAT, "Ar_Gulia", alfaEngineer, GASOLINE)
    //MyCarManager.addMyCarToManager("Renault_Clio",new MyCar("1", RENAULT, "ENG_1", "Clio"))
    //MyCarManager.addMyCarToManager("Fiat_Panda",new MyCar("2", FIAT, "ENG_2", "Panda"))
    MyCarManager.addMyCarToManager("AlfaRomeo_Gulia",new MyCar("3", ALFA_ROMEO, alfaEngine, "Gulia"))

    //Cloning from Manager


    val car3 = MyCarManager.getMyCar("AlfaRomeo_Gulia") match {
      case  Some(x)=> {
        //x.shallowCopy
        x.deepCopy
      }
    }

    val car5 = MyCarManager.getMyCar("AlfaRomeo_Gulia") match {
      case  Some(x)=> {
        x.shallowCopy
        //x.deepCopy
      }
    }

    MyCarManager.getMyCar("AlfaRomeo_Gulia").get.setModelName("Gulietta")
    val car4 = MyCarManager.getMyCar("AlfaRomeo_Gulia").get
    car4.getEngine.setCarModel("Ar_Gulietta")
    car4.getEngine.getEngineer.firstName_("Kacper")
    car4.getEngine.getEngineer.diploma.schoolName_("Politechnika Rzeszowska")

    println(car3.getModelName+"  "+car4.getModelName+"  "+car5.getModelName)
    println(car3.getEngine.getCarModel+"  "+car4.getEngine.getCarModel+" "+car5.getEngine.getCarModel)
    println(car3.getEngine.getEngineer.firstName+"  "+car4.getEngine.getEngineer.firstName+" ")
    println(car3.getEngine.getEngineer.diploma.schoolName+"  "+car4.getEngine.getEngineer.diploma.schoolName+" ")

  }
}
