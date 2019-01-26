package korszun.kacper

import korszun.kacper.ProductTraits._
import korszun.kacper.TraitsEnum._
import org.scalatest.FlatSpec

class SimpleProductFactoryTest extends FlatSpec {

  behavior of "SimpleProductFactoryTest"

  it should "return MyProduct in getProduct" in {
    assert(SimpleProductFactory.getProduct(BOOKSTORE_PRODUCT).get.isInstanceOf[MyProduct])
  }

  it should  "not return MyProduct in getProduct if input is not proper" in{
    assert(SimpleProductFactory.getProduct(null) == None)
  }

  it should "return instance of BookstoreProduct with type: BOOKSTORE_PRODUCT and no other" in {
    assert(SimpleProductFactory.getProduct(BOOKSTORE_PRODUCT).get.isInstanceOf[BookstoreProduct])
    assertThrows[ClassCastException](SimpleProductFactory.getProduct(BOOKSTORE_PRODUCT).get.asInstanceOf[EatableProduct])
  }

  it should "return instance of EatableProduct with string: EATABLE_PRODUCT and no other" in {
    assert(SimpleProductFactory.getProduct(EATABLE_PRODUCT).get.isInstanceOf[EatableProduct])
    assertThrows[ClassCastException](SimpleProductFactory.getProduct(EATABLE_PRODUCT).get.asInstanceOf[BookstoreProduct])
  }

}
