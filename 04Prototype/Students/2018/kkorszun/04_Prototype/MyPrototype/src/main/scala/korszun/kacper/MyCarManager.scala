package korszun.kacper

import scala.collection.mutable

object MyCarManager {
  private var factoriesMap : mutable.HashMap[String,MyCar] = mutable.HashMap()

  def addMyCarToManager(carName: String, myCar: MyCar) = factoriesMap += (carName -> myCar)
  def getMyCar(carName: String) = factoriesMap.get(carName)
}
