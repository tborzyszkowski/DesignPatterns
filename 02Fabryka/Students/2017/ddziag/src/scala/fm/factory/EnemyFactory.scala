package factory.fm


abstract class EnemyFactory {
  def prepareEnemy(enemyType: EnemyType): Enemy

  def getEnemy(enemyType: EnemyType) = {
    val enemy = prepareEnemy(enemyType)
    enemy.spawn()
    enemy.scream()
    enemy.patrol()
    enemy.flex()
  }
}

class GreenGoblinFactory extends EnemyFactory {
  override def prepareEnemy(enemyType: EnemyType): Enemy = enemyType match {
    case GoblinType => new GreenGoblin
    case HolyGoblinType => new GreenHolyGoblin
    case KingGoblinType => new GreenKingGoblin
  }
}

class PinkGoblinFactory extends EnemyFactory {
  override def prepareEnemy(enemyType: EnemyType): Enemy = enemyType match {
    case GoblinType => new PinkGoblin
    case HolyGoblinType => new PinkHolyGoblin
    case KingGoblinType => new PinkKingGoblin
  }
}

class UberGoblinFactory {
  def prepareEnemy(goblinColor: GoblinColor, enemyType: EnemyType): Enemy = {
    goblinColor match {
      case GreenGoblinColor =>
        enemyType match {
          case GoblinType => new GreenGoblin
          case HolyGoblinType => new GreenHolyGoblin
          case KingGoblinType => new GreenKingGoblin
        }
      case PinkGoblinColor =>
        enemyType match {
          case GoblinType => new PinkGoblin
          case HolyGoblinType => new PinkHolyGoblin
          case KingGoblinType => new PinkKingGoblin
        }
    }
  }
}


