package adapter.twoWayAdapter

open class AirCraft : AirCraftInterface {

    override var airborn: Boolean = false
    override var height: Int = 0

    override fun takeOff() {
        println("engines takes off")
        airborn = true
        height = 200
    }
}