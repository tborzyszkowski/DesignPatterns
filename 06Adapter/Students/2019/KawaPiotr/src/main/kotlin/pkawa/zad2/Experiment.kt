package pkawa.zad2

fun main() {
    val tank = Tank()
    tank.shoot(10)

    val airplane = Airplane()
    airplane.dropBomb(10)

    val robot = Robot()
    robot.attack(10)

    //Tank robot
    val tankRobot = Robot(tank)
    tankRobot.attack(10)

    //Airplane robot
    val airplaneRobot = Robot(Airplane())
    airplaneRobot.attack(10)
}