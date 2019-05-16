package pkawa.abstract

import pkawa.exception.UnknownConsoleException
import pkawa.model.*

class XBOXGame(gameTitle: String) : Game(gameTitle, ConsoleCodename.XBOX_ONE)

object XboxOneStoreFactory: PlatformStoreFactory() {
    override fun createConsole(consoleVersion: String): Console {
        return when (consoleVersion) {
            "Xbox One" -> XboxOne()
            "Xbox One X" -> XboxOneX()
            else -> throw UnknownConsoleException("Not known console version. Please try 'Xbox One' / 'Xbox One X'")
        }
    }
    override fun createGame(gameTitle: String): Game = XBOXGame(gameTitle)
}