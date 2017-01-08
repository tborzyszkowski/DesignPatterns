package decorator

class BaseGame : CardGame {

    override fun makeTurn() {
        println("making turn")
    }

    override fun killPlayer() {
        println("killing one player")
    }
}