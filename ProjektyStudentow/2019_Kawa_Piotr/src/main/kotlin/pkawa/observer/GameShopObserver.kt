package pkawa.observer

import pkawa.model.Game

interface GameShopObserver {
    fun listAGame(newGame: Game)
    fun listAllGames(games: List<Game>)
}