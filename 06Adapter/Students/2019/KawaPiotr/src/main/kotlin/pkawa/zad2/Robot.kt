package pkawa.zad2

class Robot {
    var attack = { damage: Int ->
        print("Robot is punching the target... ")
        println("Punches are weak, it dealt only ${damage * 0.6} damage!\n\n")
    }

    constructor()

    constructor(tank: Tank) {
        println("Robot transforms into the tank...")
        attack = tank.shoot
    }

    constructor(airplane: Airplane) {
        println("Robot transforms into the airplane...")
        attack = airplane.dropBomb
    }
}
