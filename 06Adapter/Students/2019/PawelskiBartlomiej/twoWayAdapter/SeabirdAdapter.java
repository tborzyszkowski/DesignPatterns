package twoWayAdapter;

public class SeabirdAdapter extends Aircraft implements ISeacraft {
    private Seabird seabird = new Seabird();

    public SeabirdAdapter() {
        super();
    }

    public void takeOff() {
        seabird.takeOff();
    }

    public int height() {
        return seabird.height;
    }

    public boolean airbone() {
        return seabird.airbone();
    }

    public void increaseRevs() {
        seabird.increaseRevs();
    }

    public int speed() {
        return seabird.speed();
    }
}
