package korszun.kacper

class SeabirdT(sb: Seabird) extends  Aircraft {
  val mySeabird = sb

  override def TakeOff: Unit = mySeabird.TakeOff

  override def Height: Int = mySeabird.Height

  override def Airborne: Boolean = mySeabird.Airborne

}
