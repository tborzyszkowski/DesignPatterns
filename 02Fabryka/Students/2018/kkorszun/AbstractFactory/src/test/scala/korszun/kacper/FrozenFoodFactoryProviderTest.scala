package korszun.kacper

import korszun.kacper.FrozenFood.FrozenFood
import korszun.kacper.MyFactories.{CheapFrozenFoodFactory, ExpensiveFrozenFoodFactory}
import org.scalatest.FlatSpec

class FrozenFoodFactoryProviderTest extends FlatSpec {
  behavior of "FrozenFoodFactoryProvider"

  it should "return Option[AbstractFrozenFoodFactory] in getFactory" in {
    assert(FrozenFoodFactoryProvider.getFactory("").isInstanceOf[Option[AbstractFrozenFoodFactory]])
  }

  it should  "return proper Type in getFactory" in{
    CheapFrozenFoodFactory
    ExpensiveFrozenFoodFactory
    assert(FrozenFoodFactoryProvider.getFactory("Cheap").get == CheapFrozenFoodFactory)
    assert(FrozenFoodFactoryProvider.getFactory("Expensive").get == ExpensiveFrozenFoodFactory)
  }

  it should "returned factory  should give FrozenFood" in {
    assert(FrozenFoodFactoryProvider.getFactory("Cheap").get.getFrozenBurger.isInstanceOf[FrozenFood])
  }

}
