package pkawa.model

abstract class Console {
    var currentGame: Game? = null
    lateinit var currentLoginID: String

    abstract fun checkGameCompatibility(game: Game): Boolean

    fun runGame(game: Game) {
        checkGameCompatibility(game)
        currentGame = game
    }

    fun closeGame() {
        currentGame = null
    }

    fun logIn(currentLoginID: String) {
        this.currentLoginID = currentLoginID
    }
}

// XBone platform
open class XboxOne : Console() {
    override fun checkGameCompatibility(game: Game): Boolean = game.platform == ConsoleCodename.XBOX_ONE
}

class XboxOneX : XboxOne()

// PS4 platform
open class PlayStation4 : Console() {
    override fun checkGameCompatibility(game: Game): Boolean = game.platform == ConsoleCodename.PS4
}

class PlayStation4Pro : PlayStation4()

// Nintendo Switch platform
class NintendoSwitch : Console() {
    override fun checkGameCompatibility(game: Game): Boolean = game.platform == ConsoleCodename.NINTENDO_SWITCH
}


// 3DS platform
open class ThreeDS : Console() {
    override fun checkGameCompatibility(game: Game): Boolean = game.platform == ConsoleCodename.NINTENDO_3DS
}

class TwoDS : ThreeDS()
class New3DS : ThreeDS() {
    override fun checkGameCompatibility(game: Game): Boolean =
        game.platform == ConsoleCodename.NINTENDO_NEW_3DS || game.platform == ConsoleCodename.NINTENDO_3DS
}

