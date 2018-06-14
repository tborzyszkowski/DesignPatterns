package korszun.kacper

import korszun.kacper.CarBrand._
import korszun.kacper.Fuel._
import korszun.kacper.Main.MyEngineer
import org.scalatest.FlatSpec

class MyCarManagerTest extends FlatSpec {

  behavior of "MyCarManagerTest"

  val uno_diploma = new MyDiploma("Polytechnic University of Bari", 2012)
  val uno_engineer = new MyEngineer("Paulo","Bianco", uno_diploma)
  val uno_engine = new CarEngine("Uno_Engine", FIAT, "Ar_Gulia", uno_engineer, GASOLINE)
  var fiat_uno = new MyCar("4", FIAT, uno_engine, "Uno")

  it should "in getMyCar return added car" in {
    MyCarManager.addMyCarToManager("Fiat_Uno", fiat_uno)
    assert(MyCarManager.getMyCar("Fiat_Uno").get.isInstanceOf[MyCar])
  }

  it should "not in getMyCar return not added car" in {
    assert(MyCarManager.getMyCar("Fiat_Duplo") == None)
  }

}


/*




var fiat_uno_copy = fiat_uno.shallowCopy
    assert(fiat_uno_copy.eq(fiat_uno))


 */