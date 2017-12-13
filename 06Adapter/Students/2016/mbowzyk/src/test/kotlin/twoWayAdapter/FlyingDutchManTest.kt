package adapter.twoWayAdapter

import org.junit.Test

class FlyingDutchManTest {

    @Test
    fun makeFlyingDutchManGo() {
        val seaCraft: SeaCraftInterface = SeaCraft()
        seaCraft.increaseRevs()
        println("seacraft is going with ${seaCraft.speed} knots")

        val flyingDutchMan: SeaCraftInterface = FlyingDutchMan()
        flyingDutchMan.increaseRevs()
        println("flying dutch man is sailing")

        flyingDutchMan as AirCraft
        flyingDutchMan.takeOff()
        if (flyingDutchMan.airborn)
            println("flying dutch man is going ${flyingDutchMan.speed} knot on ${flyingDutchMan.height} meters high")
    }
}