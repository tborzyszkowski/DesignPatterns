package pkawa.classic

import pkawa.Platform

object SwitchConsoleBoxBuilder : ConsoleBoxBuilder {
    override val consoleBox = ConsoleBox()

    override fun model() {
        consoleBox.modelName = "Nintendo Switch Mario Odyssey Limited Edition"
    }

    override fun platform() {
        consoleBox.gameCompatibilityPlatform = Platform.SWITCH
    }

    override fun controllerColor() {
        consoleBox.controllerColor = "Red joy-cons"
    }

    override fun game() {
        consoleBox.game = "Super Mario Odyssey"
    }

    override fun build(): ConsoleBox = consoleBox
}