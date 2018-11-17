package korszun.kacper

object CarBrand {
  sealed  trait BrandValue
  case object FIAT extends  BrandValue
  case object TOYOTA extends BrandValue
  case object RENAULT extends BrandValue
  case object ALFA_ROMEO extends BrandValue
  val carBrands = Seq(FIAT, TOYOTA, RENAULT, ALFA_ROMEO)
}