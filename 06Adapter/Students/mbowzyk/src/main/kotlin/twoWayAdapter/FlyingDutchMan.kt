package adapter.twoWayAdapter

class FlyingDutchMan : AirCraft(), SeaCraftInterface {

    override var speed: Int = 0

    override fun increaseRevs() {
        speed += 10
        println("Flying dutch man is going with ${speed} knots")
        if (airborn) {
            height += 100
            println("on ${height} meters")
        }
    }

    override fun takeOff() {
        super.takeOff()
        increaseRevs()
    }
}