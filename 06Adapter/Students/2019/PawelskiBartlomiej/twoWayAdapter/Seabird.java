package twoWayAdapter;

public class Seabird extends Seacraft implements IAircraft {
    int height = 0;

    @Override
    public boolean airbone() {
        return height > 50;
    }

    @Override
    public void takeOff() {
        while (!airbone()) increaseRevs();
    }

    @Override
    public int height() {
        return height;
    }

    @Override
    public void increaseRevs() {
        super.increaseRevs();
        height += speed() > 40 ? 100 : 0;
    }
}
