package twoWayAdapter;

public class Aircraft implements IAircraft {
    private int height;
    private boolean airbone;

    public Aircraft() {
        height = 0;
        airbone = false;
    }

    @Override
    public boolean airbone() {
        return airbone;
    }

    @Override
    public void takeOff() {
        System.out.println("Engine take out...");
        airbone = true;
        height = 200;
    }

    @Override
    public int height() {
        return height;
    }
}
