package twoWayAdapter;

public class Main {
	public static void main(String[] args) {
        // No adapter
        System.out.println("Experiment 1: test the aircraft engine");
        IAircraft aircraft = new Aircraft();
        aircraft.takeOff();
        
        if(aircraft.airborne()){
            System.out.println("The aircraft engine is fine, flying at " + aircraft.height() + " meters");
        }
        
        // Classic usage of an adapter
        System.out.println("\nExperiment 2: Use the engine in the Seabird");
        IAircraft seabird = new Seabird();
        seabird.takeOff();
        System.out.println("The Seabird took off");
        
        // Two-way adapter: using seacraft instructions on an IAircraft object
        // (where they are not in the IAircraft interface)
        System.out.println("\nExperiment 3: Increase the speed of the Seabird:");
        ((ISeacraft)seabird).increaseRevs();
        ((ISeacraft)seabird).increaseRevs();
        if(seabird.airborne()){
            System.out.println("Seabird flying at height " + seabird.height() + " meters and speed " + ((ISeacraft)seabird).speed() + " knots");     
            System.out.println("Experiments successful; the Seabird flies!");
        }
	}
}
