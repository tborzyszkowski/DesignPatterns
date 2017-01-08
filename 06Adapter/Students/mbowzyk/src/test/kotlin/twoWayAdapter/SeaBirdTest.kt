package adapter.twoWayAdapter

import org.junit.Test

class SeaBirdTest {

    @Test
    fun makeSeaBirdFly() {
        val airCraft: AirCraftInterface = AirCraft()
        airCraft.takeOff()
        if (airCraft.airborn)
            println("aircraft is flying at ${airCraft.height} meters")

        val seaBird: AirCraftInterface = SeaBird()
        seaBird.takeOff()
        println("seabird took off")

        seaBird as SeaCraft
        seaBird.increaseRevs()
        seaBird.increaseRevs()
        if (seaBird.airborn)
            println("seabird flying at ${seaBird.height} meters with speed ${seaBird.speed} knots")
    }
}