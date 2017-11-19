package factory.scalafactory

import org.scalatest.FunSpec

class ScalafactorySpec extends FunSpec {

  describe("Scalafactory") {
    it("return proper enemy type") {
      val gobo: Enemy = Enemy(GoblinType)
      val dragon: Enemy = Enemy(DragonType)
      assert(gobo.attack == "Goblin punch")
      assert(dragon.attack == "Dragon breath")
    }
  }

}
