package factory

package object scalafactory {

  sealed trait Enemy {
    def attack: String
  }

  sealed trait EnemyType

  class Goblin extends Enemy {
    override def attack = "Goblin punch"
  }

  class Dragon extends Enemy {
    override def attack = "Dragon breath"
  }

  case object GoblinType extends EnemyType

  case object DragonType extends EnemyType

  object Enemy {
    def apply(enemyType: EnemyType): Enemy = {
      enemyType match {
        case GoblinType => new Goblin
        case DragonType => new Dragon
      }
    }
  }


}
