package pkawa.simple

import org.junit.Assert.assertTrue
import org.junit.Test
import pkawa.model.ConsoleCodename
import pkawa.model.NintendoSwitch
import pkawa.model.PlayStation4
import pkawa.model.ThreeDS

class SimpleGameStoreTest {

    private val gameTitle = "[PS4] WITCHER 3"

    @Test
    fun shouldReturn3DS() {
        val console = GameStore.purchaseConsole(ConsoleCodename.NINTENDO_3DS)

        assertTrue("Console should be ${ThreeDS::class.java.name}, is ${console::class.java.name}", console is ThreeDS)
    }

    @Test
    fun shouldReturnSwitch() {
        val console = GameStore.purchaseConsole(ConsoleCodename.NINTENDO_SWITCH)

        assertTrue(
            "Console should be ${NintendoSwitch::class.java.name}, is ${console::class.java.name}",
            console is NintendoSwitch
        )
    }

    @Test
    fun consoleAcceptAGameForItsPlatform() {
        val console = GameStore.purchaseConsole(ConsoleCodename.PS4_PRO)
        val game = GameStore.purchaseGame(gameTitle)

        assertTrue(console.checkGameCompatibility(game))
    }

    @Test
    fun timingTest() {
        val console = GameStore.purchaseConsole(ConsoleCodename.PS4)
        val beforeTime = System.currentTimeMillis()
        for (i in 0 until Math.pow(1024.0, 2.0).toLong()) {
            val game = GameStore.purchaseGame(gameTitle)
            console.runGame(game)
        }
        val runTime = System.currentTimeMillis() - beforeTime
        println("Simple factory runtime: $runTime milliseconds")
    }
}