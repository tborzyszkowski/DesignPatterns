package pkawa.fluent

import org.junit.Assert.assertEquals
import org.junit.Test
import pkawa.Platform

class FluentTest {
    @Test
    fun buildSwitchBoxTest() {
        val box = ConsoleBox.Builder
            .modelName("Nintendo Switch Pikachu Edition")
            .controllerColor("Brown and Yellow")
            .game("Pokemon: Let's go Pikachu")
            .gameCompatibilityPlatform(Platform.SWITCH)
            .build()

        assertEquals(box.game, "Pokemon: Let's go Pikachu")
        assertEquals(box.controllerColor, "Brown and Yellow")
        assertEquals(box.gameCompatibilityPlatform, Platform.SWITCH)
        assertEquals(box.modelName, "Nintendo Switch Pikachu Edition")
    }
}