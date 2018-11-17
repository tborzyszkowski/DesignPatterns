package korszun.kacper

import korszun.kacper.FrozenFood._

trait AbstractFrozenFoodFactory {
  def getFrozenBurger : MyBurger
  def getFrozenFrenchFries : MyFrenchFries
  def getFrozenPizza : MyPizza
}
