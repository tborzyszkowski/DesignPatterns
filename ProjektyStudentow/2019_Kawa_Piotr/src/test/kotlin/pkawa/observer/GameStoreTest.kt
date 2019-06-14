package pkawa.observer

import org.junit.jupiter.api.Assertions.assertEquals
import org.junit.jupiter.api.Assertions.assertTrue
import org.junit.jupiter.api.BeforeEach
import org.junit.jupiter.api.Test
import pkawa.abstractfactory.impl.PlaystationFactory
import pkawa.abstractfactory.impl.XboxOneFactory

class GameStoreTest {
    lateinit var gameStore: GameStore

    @BeforeEach
    fun setUp() {
        PlaystationFactory.INSTANCE.shops.clear()
        XboxOneFactory.INSTANCE.shops.clear()
        gameStore = GameStore()
    }

    @Test
    fun newGameStoreSuccesfullyRegistered() {
        val amountOfRegisteredStoresBefore = PlaystationFactory.INSTANCE.shops.size
        val newStore = GameStore()
        assertEquals(amountOfRegisteredStoresBefore + 1, PlaystationFactory.INSTANCE.shops.size)
    }

    @Test
    fun shopCanBeUnregistered() {
        val amountOfRegisteredStoresBefore = PlaystationFactory.INSTANCE.shops.size
        PlaystationFactory.INSTANCE.unregister(gameStore)
        assertEquals(amountOfRegisteredStoresBefore - 1, PlaystationFactory.INSTANCE.shops.size)
    }

    @Test
    fun shopGetsNotifiedAboutNewGame() {
        val gamesInStoreBefore = gameStore.availableGames.size
        val game = PlaystationFactory.INSTANCE.createAGame("Banjo Kazooie")

        PlaystationFactory.INSTANCE.notifyShops(game)

        assertEquals(gamesInStoreBefore + 1, gameStore.availableGames.size)
        assertTrue(game in gameStore.availableGames)
    }
}