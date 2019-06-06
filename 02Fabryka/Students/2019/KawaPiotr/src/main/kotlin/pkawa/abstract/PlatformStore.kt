package pkawa.abstract

import pkawa.model.Console
import pkawa.model.Game

abstract class PlatformStoreFactory {
    abstract fun createConsole(consoleVersion: String) : Console
    abstract fun createGame(gameTitle: String) : Game
}

class PlatformStore(private val platformStoreFactory: PlatformStoreFactory) {
    fun purchaseConsole(consoleVersion: String) : Console = platformStoreFactory.createConsole(consoleVersion)
    fun purchaseGame(gameTitle: String) : Game = platformStoreFactory.createGame(gameTitle)
}