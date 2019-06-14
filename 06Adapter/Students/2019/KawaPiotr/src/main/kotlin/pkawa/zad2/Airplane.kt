package pkawa.zad2

import kotlin.random.Random

class Airplane {
    val dropBomb = { damage: Int ->
        print("Airplane is dropping a bomb... ")
        if (Random.nextDouble(0.0, 1.0) < 0.5) // pociski są wolne i łatwo spudłować, 50%
            println("Bomb dropped! It dealt ${damage * 3} damage in the area!")
        else
            println("It missed! Dealt 0 damage.")
        print("\n\n")
    }
}