package korszun.kacper

import java.util.Date

import korszun.kacper.ProductTraits.MyProduct
import korszun.kacper.TraitsEnum._

/* Fabryka prosta:
Do „klienta” dostarczany jest o obiekt o pewnych własnościach.
Zalety:
- Zwiększamy poziom abstrakcji poprzez oddzielenie operacji na obiekcie od jego konstruktora.
- Jednoznaczny i prosty wzorzec
- Brak konieczności spełniania wspólnych założeń w tworzonych fabrykach

Wady:
- Konieczność tworzenia fabryki od podstaw dla każdego przypadku
- Konieczność wywołania konkretnej nazwy fabryki w logice programu
- Dynamiczne dodawanie fabryk wymusza konieczność zmiany w logice programu(np. przez refleksje)
 */


object Main extends App {
  private object objectsInit {
    ProductsImplements.Coffee
    ProductsImplements.ReamOfPaper
  }

  override def main(args: Array[String]): Unit = {
    objectsInit

    def factoryString(x : Option[MyProduct]) = x match {
      case Some(y) => y
      case None => "<No result>"
    }

    val productFromSimpleFactory_1 = SimpleProductFactory.getProduct(BOOKSTORE_PRODUCT)
    val productFromSimpleFactory_2 = SimpleProductFactory.getProduct(EATABLE_PRODUCT)

    val productFromReflectionFactory_1 = SimpleReflectionProductFactory.getProduct(TraitsEnum.EATABLE_PRODUCT)
    val productFromReflectionFactory_2 = SimpleReflectionProductFactory.getProduct(TraitsEnum.BOOKSTORE_PRODUCT)

    println("--- RESULTS  ---")
    println(s"values from SimpleProductFactory: \n${factoryString(productFromSimpleFactory_1)}," +
      s" \n${factoryString(productFromSimpleFactory_2)}")
    println()
    println(s"products from SimpleReflectionProductFactory \n${factoryString(productFromReflectionFactory_1)}," +
      s" \n${factoryString(productFromReflectionFactory_2)}")
    println("-----------------")
  }
}
