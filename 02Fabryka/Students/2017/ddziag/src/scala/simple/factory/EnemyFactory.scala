package factory.simple


object EnemyFactory {
  def createEnemy(enemyType: EnemyType) = {
    enemyType match {
      case GoblinType => new Goblin
      case HolyGoblinType => new HolyGoblin
      case KingGoblinType => new KingGoblin
    }
  }
}

