package korszun.kacper

import korszun.kacper.MyFactories._

import scala.util.Random

/*
Fabryka abstrakcyjna:
Zalety:
- Dynamiczne dodawanie nowych fabryk, brak konieczności zmiany logiki programu
- Prosta struktura dziedziczenia, wzorzec skierowany na tworzenie obiektów
Wady:
- Konieczność spełnienia założeń
- Prosta struktura dziedziczenia, wzorzec skierowany na tworzenie obiektów
 */

object Main extends App {
  object outerObject {
    CheapFrozenFoodFactory
    ExpensiveFrozenFoodFactory
    Random.nextInt(3) match {
      case 0 => {
        MediumFrozenFoodFactory
      }
      case _ => {}
    }
    //MediumFrozenFoodFactory
  }

  override def main(args: Array[String]): Unit = {
    outerObject
    val cheapFactory = FrozenFoodFactoryProvider.getFactory("Cheap")
    cheapFactory match {
      case Some(x) => println(x.getFrozenBurger)
      case None => println("Factory is not available")
    }

    val mediumFactory = FrozenFoodFactoryProvider.getFactory("Medium")
    mediumFactory match {
      case Some(x) => println(x.getFrozenBurger)
      case None => println("Factory is not available")
    }
  }
}
