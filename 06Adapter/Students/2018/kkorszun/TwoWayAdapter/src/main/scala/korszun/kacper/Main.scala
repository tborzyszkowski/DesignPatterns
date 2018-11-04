package korszun.kacper

//Experiment_MakeSeaBirdFly
/*
Zadanie 1
Rozważmy program Seabird.
Czy byłoby możliwe utworzenie instancji obiektu Aircraft zamiast obiektu Seacraft,
 zmieniając metody wewnątrz Seabird odpowiednio?

Jeśli tak, należy dokonać zmian takich zmian.

Jeśli nie, proszę wyjaśnić, w jaki sposób obecny program będzie musiał zostać zmieniony by to osiągnąć,
 a następnie dokonać zmian takich zmian.
 */
object Main extends App{

  implicit def toSBTwo(sb: Seabird) = {
    new SeabirdT(sb)
  }

  override def main(args: Array[String]) = {
    // No adapter
    println("Experiment 1: test the aircraft engine")
    val aircraft :IAircraft = new Aircraft
    aircraft.TakeOff
    if (aircraft.Airborne) println("The aircraft engine is fine, flying at " + aircraft.Height + "meters")

    // Classic usage of an adapter
    println("\nExperiment 2: Use the engine in the Seabird");
    val seabird :IAircraft = new Seabird
    seabird.TakeOff // And automatically increases speed
    println("The Seabird took off");

    // Two-way adapter: using seacraft instructions on an IAircraft object
    // (where they are not in the IAircraft interface)
    println("\nExperiment 3: Increase the speed of the Seabird:");
    (seabird.asInstanceOf[ISeacraft]).IncreaseRevs
    (seabird.asInstanceOf[ISeacraft]).IncreaseRevs
    if (seabird.Airborne) println("Seabird flying at height " + seabird.Height +
            " meters and speed " + (seabird.asInstanceOf[ISeacraft]).Speed + " knots")
    println("Experiments successful; the Seabird flies!");

    var myAc: Aircraft = new Seabird : SeabirdT
    myAc.TakeOff
    if (myAc.Airborne) println("The aircraft engine is fine, flying at " + myAc.Height + "meters")
  }
}
