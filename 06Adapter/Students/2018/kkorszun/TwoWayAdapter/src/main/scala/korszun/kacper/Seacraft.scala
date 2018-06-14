package korszun.kacper

class Seacraft extends ISeacraft {
  private var speed = 0
  override def Speed: Int = speed

  override def IncreaseRevs: Unit = {
    speed += 10
    println("Seacraft engine increases revs to " + speed + " knots")
  }
}
