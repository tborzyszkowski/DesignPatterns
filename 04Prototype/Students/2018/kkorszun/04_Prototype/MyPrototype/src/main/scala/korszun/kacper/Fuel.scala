package korszun.kacper

object Fuel {
  sealed  trait FuelValue
  case object GASOLINE extends  FuelValue
  case object DIESEL extends  FuelValue
  val carBrands = Seq(GASOLINE,DIESEL)
}
