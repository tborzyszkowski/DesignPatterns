/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package AdapterTwoWay;

/**
 *
 * @author KrzysieK
 */
public class Test {

    public static void main(String[] args) {
        // No adapter
        System.out.println("Experiment 1: test the aircraft engine");
        IAirCraft aircraft = new AirCraft();
        aircraft.TakeOff();
        if (aircraft.Airborne()) {
            System.out.println(
                    "The aircraft engine is fine, flying at "
                    + aircraft.Height() + "meters");
        }

        // Classic usage of an adapter
        System.out.println("\nExperiment 2: Use the engine in the Seabird");
        Adaptor seabird = new Adaptor();
        seabird.TakeOff(); // And automatically increases speed
        System.out.println("The Seabird took off");

        // Two-way adapter: using seacraft instructions on an IAircraft object
        // (where they are not in the IAircraft interface)
        System.out.println("\nExperiment 3: Increase the speed of the Seabird:");
        seabird.IncreaseRevs();
        seabird.IncreaseRevs();
        if (seabird.Airborne()) {
            System.out.println("Seabird flying at height " + seabird.Height()
                    + " meters and speed " + seabird.Speed() + " knots");
        }
        System.out.println("Experiments successful; the Seabird flies!");
    }
}
