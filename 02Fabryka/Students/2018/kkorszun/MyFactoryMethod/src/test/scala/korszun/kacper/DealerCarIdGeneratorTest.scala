package korszun.kacper

import korszun.kacper.CarDealerApp.CarType
import org.scalatest.FlatSpec

class DealerCarIdGeneratorTest extends FlatSpec {


  behavior of "DealerCarIdGenerator"

  it should "return unique Ids" in {
    val id1 = DealerCarIdGeneretor.getId()
    val id2 = DealerCarIdGeneretor.getId()
    assert(id1!=id2)
  }

}
