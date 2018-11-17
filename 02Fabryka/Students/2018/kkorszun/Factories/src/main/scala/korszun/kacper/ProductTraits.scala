package korszun.kacper

import java.util.Date

object ProductTraits {

  trait MyProduct {
    def id: String
    def price: BigDecimal
    def shopSection: ShopSection.SectionValue

    // our A,B,C products:
    // - BookstoreProduct
    // - HouseHoldChemistryProduct
    // - EatableProduct
  }


  trait BookstoreProduct extends MyProduct {
    override def shopSection = ShopSection.BOOKSTORE
  }

  trait HouseHoldChemistryProduct extends MyProduct
  trait EatableProduct extends MyProduct

  // extra trait
  trait EatablePackedProduct extends EatableProduct{
    def exprDate: Date
  }







}
