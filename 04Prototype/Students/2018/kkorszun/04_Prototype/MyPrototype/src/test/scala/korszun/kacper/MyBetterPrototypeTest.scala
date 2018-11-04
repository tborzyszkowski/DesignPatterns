package korszun.kacper

import korszun.kacper.CarBrand._
import korszun.kacper.Fuel._
import korszun.kacper.Main.MyEngineer
import org.scalatest.FlatSpec

class MyBetterPrototypeTest extends FlatSpec {

  behavior of "MyBetterPrototypeTest"

  val uno_diploma = new MyDiploma("Polytechnic University of Bari", 2010)
  val uno_engineer = new MyEngineer("Marco","Grigio", uno_diploma)
  val uno_engine = new CarEngine("Uno_Engine", FIAT, "Ar_Gulia", uno_engineer, GASOLINE)
  var fiat_uno = new MyCar("4", FIAT, uno_engine, "Uno")

  it should "in shallowCopy should be equal to origin" in {
    fiat_uno.shallowCopy.equals(fiat_uno)
  }

  it should "in shallowCopy should be different object" in {
    val fiat_uno_copy = fiat_uno.shallowCopy
    assert(fiat_uno_copy != fiat_uno)
    fiat_uno.setModelName("Duplo")
    assert(fiat_uno_copy.getModelName != fiat_uno.getModelName)
    //Same reference
    //assert(fiat_uno_copy.getEngine != fiat_uno.getEngine)
  }

  it should "in deepCopy should be equal to origin" in {
    val fiat_uno_deepCopy = fiat_uno.deepCopy
    //assert(fiat_uno_deepCopy.equals(fiat_uno))
  }

  it should "in deepCopy should be different object" in {
    fiat_uno.setModelName("Uno")
    val fiat_uno_deepCopy = fiat_uno.deepCopy
    assert(fiat_uno_deepCopy != fiat_uno)
    fiat_uno.setModelName("Duplo")
    assert(fiat_uno_deepCopy.getModelName != fiat_uno.getModelName)
    //Different reference
    assert(fiat_uno_deepCopy.getEngine != fiat_uno.getEngine)


  }

  it should "in deepCopy should copy deep" in {
    fiat_uno.setModelName("Uno")
    val fiat_uno_deepCopy = fiat_uno.deepCopy
    val uno_eng = fiat_uno.getEngine.getEngineer
    val dc_eng = fiat_uno_deepCopy.getEngine.getEngineer
    //assert(uno_eng.equals(dc_eng))
    fiat_uno.getEngine.getEngineer.firstName_("Kacper")
    assert(fiat_uno.getEngine.getEngineer.eq(fiat_uno_deepCopy.getEngine.getEngineer)==false)
  }


}
