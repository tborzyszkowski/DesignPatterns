package pkawa.observer

import pkawa.abstractfactory.PlatformDistributor
import pkawa.abstractfactory.impl.PlaystationFactory
import pkawa.abstractfactory.impl.XboxOneFactory
import pkawa.chain.FactoryChain
import pkawa.facade.GameStoreFacade
import pkawa.model.Console
import pkawa.model.Game

class GameStore : GameShopObserver {
    val availableGames = ArrayList<Game>()
    val temporarilyUnavailable = ArrayList<Game>()

    init {
        PlaystationFactory.INSTANCE.register(this)
        XboxOneFactory.INSTANCE.register(this)
    }

    class ConsoleBox(val console: Console, val game: Game) {

        companion object Builder {
            private var factoryChain: FactoryChain = GameStoreFacade().prepareFactoryChain()
            private lateinit var consoleName: String
            private lateinit var gameTitle: String

            fun console(consoleName: String): Builder {
                this.consoleName = consoleName
                return this
            }

            fun factoryChain(chain: FactoryChain): Builder {
                factoryChain = chain
                return this
            }

            fun game(gameTitle: String): Builder {
                this.gameTitle = gameTitle
                return this
            }

            fun build(): ConsoleBox {
                val factory = factoryChain.findFactory(consoleName)!!
                val distributor = PlatformDistributor(factory)
                val console = distributor.getConsole(consoleName)
                val game = distributor.getGame(gameTitle)
                return ConsoleBox(console, game)
            }
        }
    }

    override fun listAGame(newGame: Game) {
        availableGames.add(newGame)
    }

    override fun listAllGames(games: List<Game>) {
        availableGames.addAll(games)
    }

    fun removeAGame(game: Game) {
        availableGames.remove(game)
        temporarilyUnavailable.remove(game)
    }

    fun isTheGameAvailable(game: Game): Boolean = availableGames.any { it == game }
    fun isTheGameAvailable(title: String): Boolean = availableGames.any { it.title == title }

    fun moveToTemporarilyUnavailable(game: Game) =
            temporarilyUnavailable.add(availableGames[availableGames.indexOf(game)])

}