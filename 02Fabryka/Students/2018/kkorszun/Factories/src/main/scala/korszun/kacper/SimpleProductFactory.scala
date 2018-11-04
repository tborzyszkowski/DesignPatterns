package korszun.kacper

import java.util.Date

import korszun.kacper.ProductTraits._
import TraitsEnum._
import korszun.kacper.ShopSection.FROZEN_FOOD


object SimpleProductFactory {
  private var counter = 0
  private val factory_name = "simple_product_factory"


  private case class Book(id: String, price: BigDecimal, isbn: String) extends  BookstoreProduct
  private case class Fruit(id: String, price: BigDecimal, deliveryDate: Date) extends  EatableProduct {
    override def shopSection = ShopSection.FRUITS_AND_VEGS
  }


  def getProduct( traitType : TraitValue):Option[MyProduct] = {
    traitType match {
      case  BOOKSTORE_PRODUCT => {
        counter +=1
        Some(new Book("book"+"_"+factory_name+"_"+counter, 12.50, "83 12345678901"))
      }
      case EATABLE_PRODUCT => {
        counter += 1
        Some(new Fruit("apple"+"_"+factory_name+"_"+counter, 2.5, new Date()))
      }
      case _ => None
    }
  }
}
