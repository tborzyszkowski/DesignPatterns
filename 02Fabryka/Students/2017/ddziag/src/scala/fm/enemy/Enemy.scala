package factory.fm

import scala.collection.mutable.ArrayBuffer


sealed trait Enemy {
  val name: String
  val hp: Integer
  val mp: Integer
  val attacks: ArrayBuffer[String] = ArrayBuffer.empty[String]


  def spawn() = println("Enemy spawned")

  def scream() = println("Enemy spawn scream sound")

  def patrol() = println("Started searching for player")

  def flex() = attacks.foreach(println(_))

}

sealed trait EnemyType

sealed trait GoblinColor

class GreenGoblin extends Enemy {
  override val name: String = "GreenGoblin"
  override val hp: Integer = 6
  override val mp: Integer = 3
  attacks += "Stone throw"
  attacks += "Kick"
  attacks += "Punch"

  override def scream(): Unit = {
    super.scream()
    println("Additional green screamz!")
  }
}

class GreenHolyGoblin extends Enemy {
  override val name: String = "GreenHolyGoblin"
  override val hp: Integer = 10
  override val mp: Integer = 15
  attacks += "Holy Stone throw"
  attacks += "Holy Kick"
  attacks += "Holy Punch"

  override def scream(): Unit = {
    println("Additional green screamz!")
  }
}

class GreenKingGoblin extends Enemy {
  override val name: String = "GreenKingGoblin"
  override val hp: Integer = 15
  override val mp: Integer = 10
  attacks += "King Stone throw"
  attacks += "King Kick"
  attacks += "King Punch"

  override def scream(): Unit = {
    println("Additional green screamz!")
  }
}

class PinkGoblin extends Enemy {
  override val name: String = "PinkGoblin"
  override val hp: Integer = 5
  override val mp: Integer = 7
  attacks += "Stone throw"
  attacks += "Kick"
  attacks += "Punch"

}

class PinkHolyGoblin extends Enemy {
  override val name: String = "PinkHolyGoblin"
  override val hp: Integer = 5
  override val mp: Integer = 20
  attacks += "Holy Stone throw"
  attacks += "Holy Kick"
  attacks += "Holy Punch"
}

class PinkKingGoblin extends Enemy {
  override val name: String = "PinkKingGoblin"
  override val hp: Integer = 20
  override val mp: Integer = 0
  attacks += "King Stone throw"
  attacks += "King Kick"
  attacks += "King Punch"
}

case object PinkGoblinColor extends GoblinColor

case object GreenGoblinColor extends GoblinColor

case object GoblinType extends EnemyType

case object HolyGoblinType extends EnemyType

case object KingGoblinType extends EnemyType


