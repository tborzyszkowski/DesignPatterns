package pkawa.abstractfactory.impl

import pkawa.abstractfactory.PlatformFactory
import pkawa.exception.console.UnknownConsoleException
import pkawa.model.Console
import pkawa.model.Game
import pkawa.model.Platform
import pkawa.observer.GameFactory
import pkawa.observer.GameShopObserver

class XboxOneFactory : GameFactory, PlatformFactory {
    override val shops = ArrayList<GameShopObserver>()
    val platform = Platform.XBOX_ONE

    companion object {
        private var singleton: XboxOneFactory? = null
        private var getInstanceWasAlreadyCalled: Boolean = false
        val INSTANCE: XboxOneFactory
            get() = getInstance()

        fun getInstance(): XboxOneFactory {
            if (singleton == null) {
                synchronized(XboxOneFactory::class) {
                    if (singleton == null) {
                        singleton = XboxOneFactory()
                        getInstanceWasAlreadyCalled = true
                    }
                }
            }
            return singleton!!
        }
    }


    init {
        if (singleton != null || getInstanceWasAlreadyCalled) {
            throw InstantiationError("This object already has one instance created")
        }

    }

    override fun register(shop: GameShopObserver) {
        shops.add(shop)
    }

    override fun unregister(shop: GameShopObserver) {
        shops.remove(shop)
    }

    override fun notifyShops(game: Game) = shops.parallelStream().forEach { it.listAGame(game) }

    override fun createAGame(title: String): Game = Game(title, Platform.XBOX_ONE)

    override fun createAConsole(consoleName: String): Console {
        return when (consoleName) {
            "Xbox One" -> Console(consoleName, "1.75 GHz AMD 8-core APU", 8, platform)
            "Xbox One X" -> Console(consoleName, "2.3 GHz AMD 8-core APU", 12, platform)
            else -> throw UnknownConsoleException("Console with name $consoleName is not produced in this factory.")
        }
    }
}