package ZAD1;

public class SeabirdTwo extends Aircraft implements ISeacraft{

    private int speed;


    @Override
    public void takeOff() {
        while (!this.airborne)
            IncreaseRevs();
    }

    public void IncreaseRevs() {
        this.speed += 10;
        System.out.println("Seacraft engine increases revs to " + this.speed + " knots");
        if(this.speed > 40) {
            this.height += 100;
            this.airborne = getAirborne();
        }
    }

    @Override
    public boolean getAirborne() {
        return height > 50;
    }

    public int getSpeed() {
        return speed;
    }
}
