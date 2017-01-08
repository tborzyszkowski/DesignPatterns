package adapter.twoWayAdapter

open class SeaCraft : SeaCraftInterface {

    override var speed: Int = 0

    override fun increaseRevs() {
        speed += 10
        println("SeaCraft engine increases revs to ${speed} knots")
    }
}