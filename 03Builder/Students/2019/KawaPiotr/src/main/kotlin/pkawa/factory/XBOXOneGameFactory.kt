package pkawa.factory

import pkawa.Platform

object XBOXOneGameFactory : GameFactory {
    override fun createGame(title: String) = Game(title, Platform.XBOX)
}