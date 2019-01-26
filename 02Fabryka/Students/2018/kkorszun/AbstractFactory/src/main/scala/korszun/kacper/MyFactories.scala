package korszun.kacper

import java.util.Date

import korszun.kacper.FrozenFood._

object MyFactories {


  object CheapFrozenFoodFactory extends AbstractFrozenFoodFactory {
    FrozenFoodFactoryProvider.addFactory(this, "Cheap")

    case class CheapBurger(weight: Int, price: BigDecimal, exprDate: Date, countryOfOrigin: String) extends MyBurger
    case class CheapFrenchFries(weight: Int, price: BigDecimal, exprDate: Date, countryOfOrigin: String) extends MyFrenchFries
    case class CheapPizza(weight: Int, price: BigDecimal, exprDate: Date, countryOfOrigin: String) extends MyPizza

    override def getFrozenBurger: MyBurger = new CheapBurger(180, 12, new Date(), "Poland")
    override def getFrozenFrenchFries: MyFrenchFries = new CheapFrenchFries(800, 9, new Date(), "Ukraine")
    override def getFrozenPizza: MyPizza = new CheapPizza(500, 10, new Date(), "Poland")

  }

  object MediumFrozenFoodFactory extends AbstractFrozenFoodFactory {
    FrozenFoodFactoryProvider.addFactory(this, "Medium")

    case class MediumBurger(weight: Int, price: BigDecimal, exprDate: Date, countryOfOrigin: String) extends MyBurger
    case class MediumFrenchFries(weight: Int, price: BigDecimal, exprDate: Date, countryOfOrigin: String) extends MyFrenchFries
    case class MediumPizza(weight: Int, price: BigDecimal, exprDate: Date, countryOfOrigin: String) extends MyPizza

    override def getFrozenBurger: FrozenFood.MyBurger = new MediumBurger(200, 16, new Date(), "Poland")
    override def getFrozenFrenchFries: FrozenFood.MyFrenchFries = new MediumFrenchFries(1000, 18, new Date(), "Poland")
    override def getFrozenPizza: FrozenFood.MyPizza = new MediumPizza(400, 12, new Date, "Germany")
  }

  object ExpensiveFrozenFoodFactory extends AbstractFrozenFoodFactory {
    case class ExpensiveBurger(weight: Int, price: BigDecimal, exprDate: Date, countryOfOrigin: String) extends MyBurger
    case class ExpensiveFrenchFries(weight: Int, price: BigDecimal, exprDate: Date, countryOfOrigin: String) extends MyFrenchFries
    case class ExpensivePizza(weight: Int, price: BigDecimal, exprDate: Date, countryOfOrigin: String) extends MyPizza

    FrozenFoodFactoryProvider.addFactory(this, "Expensive")

    override def getFrozenBurger: MyBurger = new ExpensiveBurger(200, 20, new Date(), "Argentina")
    override def getFrozenFrenchFries: MyFrenchFries = new ExpensiveFrenchFries(600, 10,new Date(), "France")
    override def getFrozenPizza: MyPizza = new ExpensivePizza(400, 15, new Date(), "Italy")
  }
}
