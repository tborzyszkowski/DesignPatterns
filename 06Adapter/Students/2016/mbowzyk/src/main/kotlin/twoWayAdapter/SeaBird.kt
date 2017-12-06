package adapter.twoWayAdapter

class SeaBird : SeaCraft(), AirCraftInterface {

    override var airborn: Boolean = false
    override var height: Int = 0

    override fun takeOff() {
        while (!airborn)
            increaseRevs()
        println("it's flying!!")
    }

    override fun increaseRevs() {
        super.increaseRevs()

        if (speed > 40)
            height += 100
        airborn = (height > 50)
    }
}