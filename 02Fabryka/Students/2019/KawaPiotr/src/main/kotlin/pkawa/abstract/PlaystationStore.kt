package pkawa.abstract

import pkawa.exception.UnknownConsoleException
import pkawa.model.*

class PlayStationGame(gameTitle: String) : Game(gameTitle, ConsoleCodename.PS4)

object PlaystationStoreFactory : PlatformStoreFactory() {
    override fun createConsole(consoleVersion: String): Console {
        return when (consoleVersion) {
            "PS4" -> PlayStation4()
            "PS4 Pro" -> PlayStation4Pro()
            else -> throw UnknownConsoleException("Not known console version. Please try PS4/ PS4 Pro")
        }
    }
    override fun createGame(gameTitle: String): Game = PlayStationGame(gameTitle)
}