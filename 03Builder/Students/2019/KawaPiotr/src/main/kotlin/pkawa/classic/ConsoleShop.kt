package pkawa.classic

object ConsoleShop {
    fun prepareConsoleBox(consoleBoxBuilder: ConsoleBoxBuilder): ConsoleBox {
        consoleBoxBuilder.model()
        consoleBoxBuilder.controllerColor()
        consoleBoxBuilder.game()
        consoleBoxBuilder.platform()
        return consoleBoxBuilder.build()
    }
}