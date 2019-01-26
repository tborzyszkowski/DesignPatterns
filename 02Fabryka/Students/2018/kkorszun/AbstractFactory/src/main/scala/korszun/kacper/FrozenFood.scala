package korszun.kacper

import java.util.Date

object FrozenFood {
  trait FrozenFood {
    def weight : Int
    def price: BigDecimal
    def exprDate: Date
    def countryOfOrigin: String
  }

  trait MyBurger extends FrozenFood
  trait MyFrenchFries extends FrozenFood
  trait MyPizza extends FrozenFood
}
