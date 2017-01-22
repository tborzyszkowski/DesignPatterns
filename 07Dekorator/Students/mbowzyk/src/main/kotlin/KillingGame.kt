package decorator

class KillingGame(cardGame: CardGame) : GameJoiner(cardGame) {

    override fun makeTurn() {
        println("making some killing actions")
        killingFun()
        super.makeTurn()
    }

    override fun killPlayer() {
        println("killing one is for pussies, killing two!")
        super.killPlayer()
        super.killPlayer()
    }

    fun killingFun() {
        println("killing 2 players")
        super.killPlayer()
        super.killPlayer()
    }
}