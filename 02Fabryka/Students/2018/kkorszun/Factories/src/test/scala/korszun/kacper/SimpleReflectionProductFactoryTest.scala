package korszun.kacper


import korszun.kacper.ProductTraits._
import korszun.kacper.ProductsImplements._
import org.scalatest.FlatSpec

class SimpleReflectionProductFactoryTest extends FlatSpec {

  private object objectsInit {
    Coffee
    ReamOfPaper
  }
  objectsInit

  behavior of "SimpleReflectionProductFactoryTest"

  it should "return MyProduct in getProduct" in {

    assert(SimpleReflectionProductFactory.getProduct(TraitsEnum.EATABLE_PRODUCT).get.isInstanceOf[MyProduct])
  }

  it should  "not return MyProduct in getProduct if input is not proper" in{
    assert(SimpleProductFactory.getProduct(null) == None)



  }

  it should "return instance of BookstoreProduct with string: \"BookstoreProduct\" and no other" in {
    assert(SimpleReflectionProductFactory.getProduct(TraitsEnum.BOOKSTORE_PRODUCT).get.isInstanceOf[BookstoreProduct])
    assertThrows[ClassCastException](SimpleReflectionProductFactory.getProduct(TraitsEnum.BOOKSTORE_PRODUCT).get.asInstanceOf[EatableProduct])

  }

  it should "return instance of EatableProduct with string: \"EatableProduct\" and no other" in {
    assert(SimpleReflectionProductFactory.getProduct(TraitsEnum.EATABLE_PRODUCT).get.isInstanceOf[EatableProduct])
    assertThrows[ClassCastException](SimpleReflectionProductFactory.getProduct(TraitsEnum.EATABLE_PRODUCT).get.asInstanceOf[BookstoreProduct])
  }
}
