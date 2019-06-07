package ZAD1;

public class Seacraft implements ISeacraft{

    int speed;


    public Seacraft(){
        this.speed = 0;
    }

    @Override
    public void IncreaseRevs() {
        speed += 10;
        System.out.println("Seacraft engine increases revs to " + speed + " knots");
    }

    public int getSpeed() {
        return speed;
    }
}
