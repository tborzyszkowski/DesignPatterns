package pkawa.decorator;

import pkawa.model.Game
import pkawa.model.Platform

interface IConsole {
    fun bootGame(game: Game): Boolean
}
