package ZAD1;

public class Experiment {

    public static void main(String[] args) {
        System.out.println("Experiment 1: test the aircraft engine");
        IAircraft aircraft = new Aircraft();
        aircraft.takeOff();
        if (((Aircraft) aircraft).getAirborne()) System.out.println("The aircraft engine is fine, flying at " +
        ((Aircraft) aircraft).getHeight() + "meters");

        System.out.println("\nExperiment 2: Use the engine in the Seabird");
        IAircraft seabird = new Seabird();
        seabird.takeOff();
        System.out.println("The Seabird took off");


        System.out.println("\nExperiment 3: Increase the speed of the Seabird:");
        ((Seabird) seabird).IncreaseRevs();
        ((Seabird) seabird).IncreaseRevs();
        if(((Seabird) seabird).getAirbone()){
            System.out.println("Seabird flying at height" + ((Seabird) seabird).getHeight() +
            " meters and speed " + ((Seabird) seabird).getSpeed() + " knots");
            System.out.println("Experiments successful; the Seabird flies!");
        }


        System.out.println("\nExperiment 4: Seabird as Aircraft object:");
        Aircraft seabirdTwo = new SeabirdTwo();
        seabirdTwo.takeOff();
        System.out.println("The Seabird took off");
        ((SeabirdTwo) seabirdTwo).IncreaseRevs();
        ((SeabirdTwo) seabirdTwo).IncreaseRevs();
        if( seabirdTwo.getAirborne()){
            System.out.println("Seabird flying at height" + seabirdTwo.getHeight() +
                    " meters and speed " + ((SeabirdTwo) seabirdTwo).getSpeed() + " knots");
            System.out.println("Experiments successful; the Seabird flies!");
        }





    }
}
