package korszun.kacper

import scala.collection.mutable

object FrozenFoodFactoryProvider {
  var factoriesMap : mutable.HashMap[String,AbstractFrozenFoodFactory] = mutable.HashMap()

  def getRandomFactory ={
    val randNum = scala.util.Random.nextInt(factoriesMap.size)
    factoriesMap.toList.take(randNum).head._2
  }
  def getFactory(someArg : String) ={
    //println(factoriesMap)
    factoriesMap.get(someArg)
  }
  def addFactory(someFactory : AbstractFrozenFoodFactory, factoryName: String) = {

    factoriesMap +=  (factoryName -> someFactory)
  }

}
