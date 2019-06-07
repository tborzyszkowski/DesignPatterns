package pkawa.classic

import org.junit.Assert.assertEquals
import org.junit.Test
import pkawa.Platform

class ClassicTest {
    @Test
    fun buildSwitchConsoleBox() {
        val console = ConsoleShop.prepareConsoleBox(SwitchConsoleBoxBuilder)

        assertEquals(console.modelName, "Nintendo Switch Mario Odyssey Limited Edition")
        assertEquals(console.game, "Super Mario Odyssey")
        assertEquals(console.controllerColor, "Red joy-cons")
        assertEquals(console.gameCompatibilityPlatform, Platform.SWITCH)
    }

    @Test
    fun buildPS4ConsoleBox() {
        val console = ConsoleShop.prepareConsoleBox(PS4ConsoleBoxBuilder)

        assertEquals(console.modelName, "Playstation 4 Pro")
        assertEquals(console.game, "God of War")
        assertEquals(console.controllerColor, "Black")
        assertEquals(console.gameCompatibilityPlatform, Platform.PS4)
    }
}