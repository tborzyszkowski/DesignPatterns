package pkawa.factory

interface GameFactory {
    fun createGame(title: String): Game
}