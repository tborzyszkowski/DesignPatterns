package korszun.kacper

class Seabird extends Seacraft with IAircraft {
  private var height = 0

  override def IncreaseRevs: Unit = {
    super.IncreaseRevs
    if (Speed > 40) height += 100;
  }

  override def TakeOff: Unit = {
    while (!Airborne) IncreaseRevs
  }

  override def Height: Int = height

  override def Airborne: Boolean = height > 50
}
