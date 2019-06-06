package pkawa.method

import org.junit.Assert.*
import org.junit.Test
import pkawa.model.ConsoleCodename
import pkawa.simple.GameStore
import kotlin.test.assertEquals
import kotlin.test.assertNotSame
import kotlin.test.assertSame

class MethodGameStoreTest {

    private val gameTitle = "Red Dead Redemption"

    @Test
    fun ps4GameFactoryReturnsPS4Game() {
        val ps4Game = PS4GameFactory.purchaseGame(gameTitle)

        assertEquals(ConsoleCodename.PS4, ps4Game.platform)
    }

    @Test
    fun shouldReturnGamesForDifferentConsoles() {
        val xboxGame = XBOXOneGameFactory.purchaseGame(gameTitle)
        val ps4Game = PS4GameFactory.purchaseGame(gameTitle)

        assertSame(xboxGame.title, ps4Game.title)
        assertNotSame(xboxGame.platform, ps4Game.platform)
    }

    @Test
    fun timingTest() {
        val console = GameStore.purchaseConsole(ConsoleCodename.PS4)
        val beforeTime = System.currentTimeMillis()
        for (i in 0 until Math.pow(1024.0, 2.0).toLong()) {
            val game = PS4GameFactory.purchaseGame(gameTitle)
            console.runGame(game)
        }
        val runTime = System.currentTimeMillis() - beforeTime
        println("Method factory runtime: $runTime milliseconds")
    }
}