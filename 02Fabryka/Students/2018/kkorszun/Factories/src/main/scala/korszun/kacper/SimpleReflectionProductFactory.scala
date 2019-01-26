package korszun.kacper

import java.util.Date

import korszun.kacper.ProductTraits._

import scala.collection.mutable
import scala.reflect.api.JavaUniverse
import scala.reflect.runtime.{universe => ru}



object SimpleReflectionProductFactory {

  private var counter = 0
  private val factory_name = "simple_reflection_product_factory"
  private val productsMap : mutable.HashMap[TraitsEnum.TraitValue, ru.Type] = mutable.HashMap()

  def registerCreator(traitType: TraitsEnum.TraitValue, myClassType: ru.Type) {
    productsMap += (traitType -> myClassType)
  }

  private case class Soap(id: String, price: BigDecimal) extends HouseHoldChemistryProduct {
    override def shopSection = ShopSection.BODY_CLEANING
  }


  def getProduct(traitType : TraitsEnum.TraitValue): Option[MyProduct] = {


    if(productsMap.get(traitType) != None) {
      val productType: ru.Type = productsMap.get(traitType).get
      val m = ru.runtimeMirror(getClass.getClassLoader)
      val classProduct= productType.typeSymbol.asClass
      val cm = m.reflectClass(classProduct)
      val ctor = productType.decl(ru.termNames.CONSTRUCTOR).asMethod
      val ctorm = cm.reflectConstructor(ctor)
      counter += 1
      val myNewProduct =ctorm(traitType + "_" + factory_name + "_" + counter, 60: BigDecimal).asInstanceOf[MyProduct]
      Some(myNewProduct)
    } else {
      None
    }

  }
}
