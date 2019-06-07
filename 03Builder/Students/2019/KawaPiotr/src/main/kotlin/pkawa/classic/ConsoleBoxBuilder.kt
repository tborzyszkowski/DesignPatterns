package pkawa.classic

interface ConsoleBoxBuilder {
    val consoleBox: ConsoleBox
    fun model()
    fun platform()
    fun controllerColor()
    fun game()
    fun build(): ConsoleBox
}