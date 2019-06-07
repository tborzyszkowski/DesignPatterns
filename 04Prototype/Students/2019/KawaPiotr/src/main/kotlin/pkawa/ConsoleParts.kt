package pkawa

import java.time.LocalDate

enum class Platform {
    PS4,
    SWITCH,
    XBOX
}

data class Console(val consoleName: String, val dateOfProduction: LocalDate, val platform: Platform) : Cloneable {
    public override fun clone(): Console = super.clone() as Console
}

data class Game(val gameName: String, val platform: Platform) : Cloneable {
    public override fun clone(): Game = super.clone() as Game
}

data class ConsoleController(val color: String, val isSymmetric: Boolean) : Cloneable {
    public override fun clone(): ConsoleController = super.clone() as ConsoleController
}

data class ConsoleRetailBox(var console: Console, var games: ArrayList<Game>, var pad: ArrayList<ConsoleController>) : Cloneable {
    public override fun clone(): ConsoleRetailBox {
        val consoleBox = super.clone() as ConsoleRetailBox
        consoleBox.console = console.clone()
        consoleBox.games = ArrayList(games.map { it.clone() })
        consoleBox.pad = ArrayList(pad.map { it.clone() })
        return consoleBox
    }

    fun shallowCopy(): ConsoleRetailBox = super.clone() as ConsoleRetailBox
}

