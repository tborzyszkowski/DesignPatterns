package pkawa.model

import pkawa.decorator.IConsole

data class Console(
        val consoleName: String,
        val cpuModel: String,
        val ramAmount: Int, // in gigs
        val platform: Platform
) : IConsole {
    override fun bootGame(game: Game): Boolean {
        println("Booting ${game.title}...")
        val result = game.platform == platform
        return if (result) {
            println("Succesffully booted the game!")
            true
        } else {
            println("You can't run ${game.platform} Game on $consoleName!!")
            false
        }
    }
}