package decorator

import org.junit.Test

class GamesTest{

    @Test
    fun makeSomeGame() {
        val baseGame: BaseGame = BaseGame()
        baseGame.makeTurn()
        baseGame.killPlayer()
        println()

        println("making killing game")
        println("*************")
        val killingGame: GameJoiner = KillingGame(baseGame)
        killingGame.makeTurn()
        println()
        killingGame.killPlayer()
        println()
        (killingGame as KillingGame).killingFun()
        println()

        println("making long game")
        println("*************")
        val longGame: GameJoiner = LongGame(baseGame)
        longGame.makeTurn()
        println()
        longGame.killPlayer()
        println()
        (longGame as LongGame).someLongActions()
        println()

        println("making long killing game")
        println("*************")
        val longKillingGame: GameJoiner = KillingGame(longGame)
        longKillingGame.makeTurn()
        println()
        longKillingGame.killPlayer()
    }
}