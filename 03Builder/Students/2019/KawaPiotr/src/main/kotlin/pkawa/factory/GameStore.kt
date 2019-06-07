package pkawa.factory

class GameStore(val gameFactory: GameFactory) {
    fun buyAGame(title: String) = gameFactory.createGame(title)
}