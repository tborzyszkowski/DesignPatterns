package korszun.kacper

import korszun.kacper.ProductTraits._
import scala.reflect.runtime.{universe => ru}


object ProductsImplements {
  object ReamOfPaper {
    private case class ReamOfPaper (id: String, price: BigDecimal) extends BookstoreProduct

    def myInit ={}
    SimpleReflectionProductFactory.registerCreator(TraitsEnum.BOOKSTORE_PRODUCT, ru.typeOf[ReamOfPaper])
  }

  object Coffee {

    private case class Coffee(id: String, price: BigDecimal) extends EatableProduct {
      override def shopSection = ShopSection.TEA_AND_COFFEE
    }
    //println("Hello")
    SimpleReflectionProductFactory.registerCreator(TraitsEnum.EATABLE_PRODUCT, ru.typeOf[Coffee])
  }
}
