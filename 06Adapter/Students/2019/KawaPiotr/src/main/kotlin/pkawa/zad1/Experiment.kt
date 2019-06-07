package pkawa.zad1

fun main() {
    // No adapter
    println("Experiment no. 1: test the aircraft engine")
    val aircraft: IAircraft = Aircraft()
    aircraft.takeOff()
    if (aircraft.airborne) println("The aircraft engine is fine, flying at ${aircraft.height} meters")

    // Classic usage of an adapter
    println("\nExperiment 2: Use the engine in the Seabird")
    val seabird: IAircraft = Seabird()
    seabird.takeOff() // And automatically increases speed
    println("The Seabird took off")

    // Two-way adapter: using seacraft instructions on an IAircraft object
    // (where they are not in the IAircraft interface)
    println("\nExperiment 3: Increase the speed of the Seabird:")
    (seabird as ISeacraft).increaseRevs()
    (seabird as ISeacraft).increaseRevs()
    if (seabird.airborne) println("Seabird flying at height ${seabird.height} meters and speed ${seabird.speed} knots")
    println("Experiments successful; the Seabird flies!")


    println("\nExperiment 4: Seabird NextGen as an Aircraft object:")
    val seabirdNextGen: Aircraft = SeabirdNextGen()
    seabirdNextGen.takeOff()
    println("The Seabird NextGen took off")
    (seabirdNextGen as SeabirdNextGen).increaseRevs()
    seabirdNextGen.increaseRevs()

    if (seabird.airborne) println("Seabird NextGen flying at height ${seabird.height} meters and speed ${seabird.speed} knots")
    println("Experiments successful; the Seabird flies!")
}