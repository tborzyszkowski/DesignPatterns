package pkawa.facade

import pkawa.chain.impl.PS4FactoryChain
import pkawa.chain.impl.XboxFactoryChain
import pkawa.exception.game.GameNotAvailableException
import pkawa.observer.GameStore

class GameStoreFacade(private val gameStore: GameStore) {

    constructor() : this(GameStore())

    fun prepareFactoryChain(): PS4FactoryChain {
        val chain = PS4FactoryChain()
        chain.nextInChain = XboxFactoryChain()
        return chain
    }

    fun releaseGames(consoleName: String, vararg titles: String) {
        val factory = prepareFactoryChain().findFactory(consoleName)
        for (title in titles) {
            factory?.notifyShops(factory.createAGame(title))
        }
    }

    fun prepareConsoleBox(consoleName: String, gameTitle: String): GameStore.ConsoleBox {
        if (!gameStore.isTheGameAvailable(prepareFactoryChain().findFactory(consoleName)!!.createAGame(gameTitle))) {
            throw GameNotAvailableException("This game is not released for given platform. Please try again.")
        }
        val gameBox = GameStore.ConsoleBox.Builder
                .console(consoleName)
                .game(gameTitle)
                .factoryChain(prepareFactoryChain())
                .build()

        return gameBox
    }

    fun releaseGameAndPrepareConsoleBox(consoleName: String, gameTitle: String): GameStore.ConsoleBox {
        releaseGames(consoleName, gameTitle)
        return prepareConsoleBox(consoleName, gameTitle)
    }
}