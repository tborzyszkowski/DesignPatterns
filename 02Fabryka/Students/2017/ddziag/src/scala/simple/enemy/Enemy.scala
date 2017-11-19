package factory.simple


import scala.collection.mutable.ArrayBuffer

sealed trait Enemy {
  val name: String
  val hp: Integer
  val mp: Integer
  val attacks: ArrayBuffer[String] = ArrayBuffer.empty[String]


  def spawn() = println("Enemy spawned")

  def scream() = println("Enemy spawn scream sound")

  def patrol() = println("Started searching for player")

}

sealed trait EnemyType

class Goblin extends Enemy {
  override val name: String = "Goblin"
  override val hp: Integer = 5
  override val mp: Integer = 5
  attacks += "Stone throw"
  attacks += "Kick"
  attacks += "Punch"
}

class HolyGoblin extends Enemy {
  override val name: String = "HolyGoblin"
  override val hp: Integer = 5
  override val mp: Integer = 10
  attacks += "Holy Stone throw"
  attacks += "Holy Kick"
  attacks += "Holy Punch"
}

class KingGoblin extends Enemy {
  override val name: String = "KingGoblin"
  override val hp: Integer = 10
  override val mp: Integer = 5
  attacks += "King Stone throw"
  attacks += "King Kick"
  attacks += "King Punch"
}

case object GoblinType extends EnemyType

case object HolyGoblinType extends EnemyType

case object KingGoblinType extends EnemyType

