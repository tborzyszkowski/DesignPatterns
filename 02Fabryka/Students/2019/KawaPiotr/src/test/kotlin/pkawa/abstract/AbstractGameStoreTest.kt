package pkawa.abstract

import org.junit.Assert.assertSame
import org.junit.Assert.assertTrue
import org.junit.Test
import pkawa.model.ConsoleCodename

class AbstractGameStoreTest {
    private val gameTitle = "Red Dead Redemption"
    val xboneStore = PlatformStore(XboxOneStoreFactory)
    val ps4Store = PlatformStore(PlaystationStoreFactory)

    @Test
    fun bothStoresProduceGamesForDifferentPlatforms() {
        val xboneGame = xboneStore.purchaseGame(gameTitle)
        val ps4Game = ps4Store.purchaseGame(gameTitle)

        assertSame(xboneGame.title, ps4Game.title)
        assertTrue(xboneGame.platform == ConsoleCodename.XBOX_ONE)
        assertTrue(ps4Game.platform == ConsoleCodename.PS4)
    }

    @Test
    fun timingTest() {
        val console = ps4Store.purchaseConsole("PS4")
        val beforeTime = System.currentTimeMillis()
        for (i in 0 until Math.pow(1024.0, 2.0).toLong()) {
            val game = ps4Store.purchaseGame(gameTitle)
            console.runGame(game)
        }
        val runTime = System.currentTimeMillis() - beforeTime
        println("Abstract factory runtime: $runTime milliseconds")
    }
}