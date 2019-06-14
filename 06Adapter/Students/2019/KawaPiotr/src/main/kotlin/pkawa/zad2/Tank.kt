package pkawa.zad2

import kotlin.random.Random

class Tank {
    val shoot = { i: Int ->
        print("Shot the missile from the tank. ")
        if (Random.nextDouble(0.0, 1.0) < 0.2) { // 20% chance for crit
            println("Critical hit! it dealt ${i * 2} damage!")
        } else {
            println("Normal hit. It dealt $i damage.")
        }
        print("\n\n")
    }
}