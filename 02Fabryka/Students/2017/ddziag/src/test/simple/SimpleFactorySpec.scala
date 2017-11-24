package factory.simple

import org.scalatest.FunSpec

class SimpleFactorySpec extends FunSpec {

  describe("Simple factory") {
    it("should return Goblin for GoblinType") {
      val enemy: Enemy = EnemyFactory.createEnemy(GoblinType)
      assert(enemy.hp == 5)
      assert(enemy.mp == 5)
      assert(enemy.attacks.contains("Stone throw"))
      assert(enemy.attacks.contains("Kick"))
      assert(enemy.attacks.contains("Punch"))
    }

    it("should return HolyGoblin for HolyGoblinType") {
      val enemy: Enemy = EnemyFactory.createEnemy(HolyGoblinType)
      assert(enemy.hp == 5)
      assert(enemy.mp == 10)
      assert(enemy.attacks.contains("Holy Stone throw"))
      assert(enemy.attacks.contains("Holy Kick"))
      assert(enemy.attacks.contains("Holy Punch"))
    }

    it("should return KingGoblin for KingGoblinType") {
      val enemy: Enemy = EnemyFactory.createEnemy(KingGoblinType)
      assert(enemy.hp == 10)
      assert(enemy.mp == 5)
      assert(enemy.attacks.contains("King Stone throw"))
      assert(enemy.attacks.contains("King Kick"))
      assert(enemy.attacks.contains("King Punch"))
    }
  }

}
