package factory.fm

import org.scalatest.FunSpec

class FactoryMethodSpec extends FunSpec {
  describe("factory method tests") {
    it("Goblin type tests") {
      val gs = new GreenGoblinFactory()
      val ps = new PinkGoblinFactory()
      val us = new UberGoblinFactory()

      val gg: Enemy = gs.prepareEnemy(GoblinType)
      val pg: Enemy = ps.prepareEnemy(GoblinType)
      assert(gg.name != pg.name)
      val ggg: Enemy = us.prepareEnemy(GreenGoblinColor, GoblinType)
      val pgg: Enemy = us.prepareEnemy(PinkGoblinColor, GoblinType)
      assert(pgg.name == pg.name)
      assert(ggg.name == gg.name)

    }
    it("king goblin type tests") {
      val gs = new GreenGoblinFactory()
      val ps = new PinkGoblinFactory()
      val us = new UberGoblinFactory()
      val gg: Enemy = gs.prepareEnemy(KingGoblinType)
      val pg: Enemy = ps.prepareEnemy(KingGoblinType)
      assert(gg.name != pg.name)
      val ggg: Enemy = us.prepareEnemy(GreenGoblinColor, KingGoblinType)
      val pgg: Enemy = us.prepareEnemy(PinkGoblinColor, KingGoblinType)
      assert(pgg.name == pg.name)
      assert(ggg.name == gg.name)

    }
    it("holy goblin tests") {
      val gs = new GreenGoblinFactory()
      val ps = new PinkGoblinFactory()
      val us = new UberGoblinFactory()

      val gg: Enemy = gs.prepareEnemy(HolyGoblinType)
      val pg: Enemy = ps.prepareEnemy(HolyGoblinType)
      assert(gg.name != pg.name)
      val ggg: Enemy = us.prepareEnemy(GreenGoblinColor, HolyGoblinType)
      val pgg: Enemy = us.prepareEnemy(PinkGoblinColor, HolyGoblinType)
      assert(pgg.name == pg.name)
      assert(ggg.name == gg.name)

    }
  }
}
