package decorator

open class GameJoiner (protected val cardGame: CardGame) : CardGame {

    override fun makeTurn() {
        cardGame.makeTurn()
    }

    override fun killPlayer() {
        cardGame.killPlayer()
    }
}