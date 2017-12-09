package factory.abstractfactory

import org.scalatest.FunSpec

class AbstractFactorySpec extends FunSpec {
  describe("Abstraact factory") {
    it("should create proper instances") {
      val dummyEnemy = EnemyFactory.getEnemy(new DummyEnemyFactory("dummy-enemy", 0, 0))
      val smartEnemy = EnemyFactory.getEnemy(new SmartEnemyFactory("strong-enemy", 666, 666))

      assert(dummyEnemy.isInstanceOf[DummyEnemy])
      assert(smartEnemy.isInstanceOf[SmartEnemy])
      assert(dummyEnemy.attacks.contains("noop"))
      assert(smartEnemy.attacks.contains("stronk attack"))
    }
  }


}
