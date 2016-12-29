package decorator

class LongGame (cardGame: CardGame) : GameJoiner(cardGame) {

    override fun killPlayer() {
        println("You really want to kill that player")
        super.killPlayer()
    }

    override fun makeTurn() {
        someLongActions()
        super.makeTurn()
    }

    fun someLongActions(){
        println("making some very long actions...")
        println("they take soooo long...")
    }
}