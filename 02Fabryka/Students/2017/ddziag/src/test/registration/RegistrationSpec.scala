package factory.registration

import factory.registration.registration.{Dragon, Goblin, RegistrationEnemyFactory}
import org.scalatest.FunSpec

class RegistrationSpec extends FunSpec {
  describe("Registration class factory") {
    it("creates proper goblin and dragon") {
      RegistrationEnemyFactory.register(1L, new Dragon)
      RegistrationEnemyFactory.register(2L, new Goblin)
      val e1 = RegistrationEnemyFactory.create(1L).createEnemy()
      val e2 = RegistrationEnemyFactory.create(2L).createEnemy()
      assert(e1.isInstanceOf[Dragon])
      assert(e2.isInstanceOf[Goblin])
      assert(e1.attack == "Dragon breath")
      assert(e2.attack == "Goblin punch")

    }
  }
}
