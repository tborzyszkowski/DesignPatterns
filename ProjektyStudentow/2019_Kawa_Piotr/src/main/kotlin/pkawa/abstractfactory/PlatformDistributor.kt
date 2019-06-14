package pkawa.abstractfactory

class PlatformDistributor(private val platformFactory: PlatformFactory) {
    fun getConsole(consoleName: String) = platformFactory.createAConsole(consoleName)
    fun getGame(title: String) = platformFactory.createAGame(title)
}