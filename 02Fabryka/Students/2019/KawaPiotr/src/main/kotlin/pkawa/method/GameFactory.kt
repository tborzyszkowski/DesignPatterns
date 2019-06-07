package pkawa.method

import pkawa.model.ConsoleCodename
import pkawa.model.Game

abstract class GameFactory {
    protected fun createGame(gameTitle: String, platform: ConsoleCodename): Game = Game(gameTitle, platform)
    abstract fun purchaseGame(gameTitle: String): Game
}

object PS4GameFactory : GameFactory() {
    override fun purchaseGame(gameTitle: String) = createGame(gameTitle, ConsoleCodename.PS4)
}

object XBOXOneGameFactory : GameFactory() {
    override fun purchaseGame(gameTitle: String) = createGame(gameTitle, ConsoleCodename.XBOX_ONE)
}

object NSwitchGameFactory : GameFactory() {
    override fun purchaseGame(gameTitle: String) = createGame(gameTitle, ConsoleCodename.NINTENDO_SWITCH)
}