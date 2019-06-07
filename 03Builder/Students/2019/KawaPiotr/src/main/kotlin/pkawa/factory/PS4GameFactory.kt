package pkawa.factory

import pkawa.Platform

object PS4GameFactory : GameFactory {
    override fun createGame(title: String) = Game(title, Platform.PS4)
}