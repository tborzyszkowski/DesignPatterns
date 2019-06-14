package pkawa.abstractfactory

import pkawa.model.Console
import pkawa.model.Game
import pkawa.observer.GameFactory

interface PlatformFactory : GameFactory {
    fun createAGame(title: String): Game
    fun createAConsole(consoleName: String): Console
}