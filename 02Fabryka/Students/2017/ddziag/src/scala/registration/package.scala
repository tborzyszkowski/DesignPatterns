package factory.registration

import scala.collection.mutable

package object registration {

  abstract class Enemy {
    def createEnemy(): Enemy

    def attack: String
  }

  class Goblin extends Enemy {
    override def createEnemy(): Enemy = new Goblin

    override def attack: String = "Goblin punch"
  }

  class Dragon extends Enemy {
    override def createEnemy(): Enemy = new Dragon

    override def attack: String = "Dragon breath"
  }

  object RegistrationEnemyFactory {
    val instances = new mutable.HashMap[Long, Enemy]()

    def register(id: Long, obj: Enemy): Unit = {
      instances += (id -> obj)
    }

    def create(id: Long): Enemy = {
      instances
        .get(id)
        .map(_.createEnemy())
        .get
    }
  }

}
