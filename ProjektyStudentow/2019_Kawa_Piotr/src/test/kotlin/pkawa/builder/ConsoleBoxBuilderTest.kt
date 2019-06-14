package pkawa.builder

import org.junit.jupiter.api.Assertions.assertEquals
import org.junit.jupiter.api.BeforeEach
import org.junit.jupiter.api.Test
import pkawa.abstractfactory.impl.PlaystationFactory
import pkawa.abstractfactory.impl.XboxOneFactory
import pkawa.decorator.PS4Decorator
import pkawa.facade.GameStoreFacade
import pkawa.observer.GameStore

class ConsoleBoxBuilderTest {
    lateinit var gameStore: GameStore

    @BeforeEach
    fun setUp() {
        PlaystationFactory.INSTANCE.shops.clear()
        XboxOneFactory.INSTANCE.shops.clear()
        gameStore = GameStore()
    }

    @Test
    fun gameGetsBuiltProperlyWithDefaultChain() {
        val gameTitle = "Banjo Kazooie"
        val consoleName = "Playstation 4"
        val gameBox = GameStore.ConsoleBox
                .game(gameTitle)
                .console(consoleName)
                .build()

        assertEquals(gameTitle, gameBox.game.title)
        assertEquals(consoleName, gameBox.console.consoleName)
    }

    @Test
    fun gameGetsBuiltProperlyWithCustomChain() {
        val gameTitle = "Banjo Kazooie"
        val consoleName = "Playstation 4"
        val gameBox = GameStore.ConsoleBox
                .game(gameTitle)
                .console(consoleName)
                .factoryChain(GameStoreFacade().prepareFactoryChain())
                .build()


        // Random decorator example :)
        PS4Decorator(gameBox.console).bootGame(gameBox.game)

        assertEquals(gameTitle, gameBox.game.title)
        assertEquals(consoleName, gameBox.console.consoleName)
    }


}