package factory

import scala.collection.mutable.ArrayBuffer

package object abstractfactory {

  sealed trait Enemy {
    val name: String
    val hp: Integer
    val mp: Integer
    val attacks: ArrayBuffer[String] = ArrayBuffer.empty[String]

    def attack() = attacks.foreach(println(_))

  }

  sealed trait EnemyAbstractFactory {
    def createEnemy: Enemy
  }

  class DummyEnemy(val name: String, val hp: Integer, val mp: Integer) extends Enemy {
    attacks += "noop"
    attacks += "noop"
    attacks += "noop"
  }

  class SmartEnemy(val name: String, val hp: Integer, val mp: Integer) extends Enemy {
    attacks += "stronk attack"
    attacks += "very stronk attack"
    attacks += "veri very stronk attack"
  }

  class DummyEnemyFactory(val name: String, hp: Integer, mp: Integer) extends EnemyAbstractFactory {
    override def createEnemy: Enemy = new DummyEnemy(name, hp, mp)
  }


  class SmartEnemyFactory(val name: String, hp: Integer, mp: Integer) extends EnemyAbstractFactory {
    override def createEnemy: Enemy = new SmartEnemy(name, hp, mp)
  }

  object EnemyFactory {
    def getEnemy(enemyAbstractFactory: EnemyAbstractFactory): Enemy = {
      enemyAbstractFactory.createEnemy
    }
  }


}
