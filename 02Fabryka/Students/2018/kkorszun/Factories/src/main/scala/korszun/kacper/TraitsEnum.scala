package korszun.kacper

object TraitsEnum {
  sealed trait TraitValue
  case object HOUSE_HOLD_CHEMISTRY extends TraitValue
  case object EATABLE_PRODUCT extends TraitValue
  case object BOOKSTORE_PRODUCT extends TraitValue
  val traitValues = Seq(HOUSE_HOLD_CHEMISTRY, EATABLE_PRODUCT, BOOKSTORE_PRODUCT)
}

