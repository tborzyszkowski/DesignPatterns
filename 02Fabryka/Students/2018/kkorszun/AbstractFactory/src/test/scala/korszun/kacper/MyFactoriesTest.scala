package korszun.kacper

import korszun.kacper.FrozenFood.{MyBurger, MyFrenchFries, MyPizza}
import korszun.kacper.MyFactories.{CheapFrozenFoodFactory, ExpensiveFrozenFoodFactory, MediumFrozenFoodFactory}
import org.scalatest.FlatSpec

class MyFactoriesTest extends FlatSpec {
  behavior of "CheapFrozenFoodFactory"
  it should "return proper types" in {
    CheapFrozenFoodFactory.getFrozenBurger.isInstanceOf[MyBurger]
    CheapFrozenFoodFactory.getFrozenFrenchFries.isInstanceOf[MyFrenchFries]
    CheapFrozenFoodFactory.getFrozenPizza.isInstanceOf[MyPizza]
  }

  behavior of "ExpensiveFrozenFoodFactory"
  it should "return proper types" in {
    ExpensiveFrozenFoodFactory.getFrozenBurger.isInstanceOf[MyBurger]
    ExpensiveFrozenFoodFactory.getFrozenFrenchFries.isInstanceOf[MyFrenchFries]
    ExpensiveFrozenFoodFactory.getFrozenPizza.isInstanceOf[MyPizza]
  }

  behavior of "MediumFrozenFoodFactory"
  it should "return proper types" in {
    MediumFrozenFoodFactory.getFrozenBurger.isInstanceOf[MyBurger]
    MediumFrozenFoodFactory.getFrozenFrenchFries.isInstanceOf[MyFrenchFries]
    MediumFrozenFoodFactory.getFrozenPizza.isInstanceOf[MyPizza]
  }
}
