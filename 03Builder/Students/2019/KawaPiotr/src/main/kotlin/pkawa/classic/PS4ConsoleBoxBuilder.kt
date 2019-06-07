package pkawa.classic

import pkawa.Platform

object PS4ConsoleBoxBuilder : ConsoleBoxBuilder {
    override val consoleBox = ConsoleBox()

    override fun model() {
        consoleBox.modelName = "Playstation 4 Pro"
    }

    override fun platform() {
        consoleBox.gameCompatibilityPlatform = Platform.PS4
    }

    override fun controllerColor() {
        consoleBox.controllerColor = "Black"
    }

    override fun game() {
        consoleBox.game = "God of War"
    }

    override fun build(): ConsoleBox = consoleBox
}