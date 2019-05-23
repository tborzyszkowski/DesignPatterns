import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.Assertions;
import pluggableAdapter.*;
import twoWayAdapter.*;

import java.util.ArrayList;

class Tests {

    /////////////////////PLUGGABLE ADAPTER/////////////////////////////////////

    private ArrayList<Person> testList() {
        ArrayList<Person> list = new ArrayList<>();
        list.add(new Person("Marta", "Nowak", 20));
        list.add(new Person("Przemek", "Grzyb", 21));
        list.add(new Person("Grzegorz", "Kowalski", 41));
        return list;
    }

    private PersonsCSV personsCSV() {
        return new PersonsCSV(PersonsCSV.listOfPersonToCSV(testList()));
    }

    private PersonsJSON personsJSON() {
        return new PersonsJSON(PersonsJSON.listOfPersonToJSON(testList()));
    }

    @Test
    void plgA_checkAdapterIfInputIsCSV() {
        PersonsListAdapter adapter = new PersonsListAdapter(personsCSV());
        ArrayList<Person> list = adapter.getPersonsList.apply(personsCSV().getPersonCSV());
        Assertions.assertEquals("Marta", list.get(0).getName());
    }

    @Test
    void plgA_checkAdapterIfInputIsJSON() {
        PersonsListAdapter adapter = new PersonsListAdapter(personsJSON());
        ArrayList<Person> list = adapter.getPersonsList.apply(personsJSON().getPersonJSON());
        Assertions.assertEquals("Marta", list.get(0).getName());
    }

    //////////////////////TWO-WAY ADAPTER/////////////////////////////////////////////////////

    @Test
    void twoWay_ExperimentOne_testTheAircraftEngine() {
        System.out.println("Experiment 1: test the aircraft engine");
        IAircraft aircraft = new Aircraft();
        aircraft.takeOff();
        if (aircraft.airbone()) {
            System.out.println("The aircraft engine is fine, flying at "
                    + aircraft.height() + " meters\n");
        }
    }

    @Test
    void twoWay_ExperimentTwo_useTheEngineInTheSeabird() {
        System.out.println("Experiment 2: Use the engine in the Seabird");
        IAircraft seabird = new Seabird();
        seabird.takeOff();
        if (seabird.airbone()) {
            System.out.println("The aircraft engine is fine, flying at "
                    + seabird.height() + " meters\n");
        }
    }

    @Test
    void twoWay_ExperimentThree_increaseTheSpeedOfTheSeabird() {
        System.out.println("Experiment 3: Increase the speed of the Seabird");
        IAircraft seabird = new Seabird();
        ((ISeacraft) seabird).increaseRevs();
        ((ISeacraft) seabird).increaseRevs();
        seabird.takeOff();
        if (seabird.airbone()) {
            System.out.println("Seabird flying at height " + seabird.height() + " meters and speed " + ((ISeacraft) seabird).speed() + " knots");
            System.out.println("Experiments successful; the Seabird flies!\n");
        }
    }

    @Test
    void twoWay_ExperimentFour_seabirdAdapter() {
        System.out.println("Experiment 4: Use the SeabirdAdapter class");
        Aircraft aircraft = new SeabirdAdapter();
        ((SeabirdAdapter) aircraft).increaseRevs();
        ((SeabirdAdapter) aircraft).increaseRevs();
        aircraft.takeOff();
        if (aircraft.airbone()) {
            System.out.println("Seabird flying at height " + aircraft.height() + " meters and speed " + ((SeabirdAdapter) aircraft).speed() + " knots");
            System.out.println("Experiments successful; the Seabird flies!\n");
        }

    }


}
