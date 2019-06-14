package pkawa.abstractfactory.impl

import pkawa.abstractfactory.PlatformFactory
import pkawa.exception.console.UnknownConsoleException
import pkawa.model.Console
import pkawa.model.Game
import pkawa.model.Platform
import pkawa.observer.GameFactory
import pkawa.observer.GameShopObserver

class PlaystationFactory : GameFactory, PlatformFactory {
    override val shops = ArrayList<GameShopObserver>()
    val platform = Platform.PS4

    companion object {
        private var singleton: PlaystationFactory? = null
        private var getInstanceWasAlreadyCalled: Boolean = false
        val INSTANCE: PlaystationFactory
            get() = getInstance()

        fun getInstance(): PlaystationFactory {
            if (singleton == null) {
                synchronized(PlaystationFactory::class) {
                    if (singleton == null) {
                        singleton = PlaystationFactory()
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

    override fun createAGame(title: String): Game = Game(title, Platform.PS4)

    override fun createAConsole(consoleName: String): Console {
        return when (consoleName) {
            "Playstation 4" -> Console(consoleName, "AMD x86-64 Jaguar 1.6 GHz", 8, platform)
            "Playstation 4 Pro" -> Console(consoleName, "AMD x86-64 Jaguar 2.13 GHz", 9, platform)
            else -> throw UnknownConsoleException("Console with name $consoleName is not produced in this factory.")
        }
    }


    override fun register(shop: GameShopObserver) {
        shops.add(shop)
    }

    override fun unregister(shop: GameShopObserver) {
        shops.remove(shop)
    }

    override fun notifyShops(game: Game) = shops.parallelStream().forEach { it.listAGame(game) }

}