package korszun.kacper

class Aircraft extends IAircraft {
  private var height = 0
  private var airborne: Boolean = false
  override def Airborne: Boolean = airborne

  override def TakeOff: Unit = {
    println("Aircraft engine takeoff")
    airborne = true
    height = 200; // Meters
  }

  override def Height: Int = height
}
