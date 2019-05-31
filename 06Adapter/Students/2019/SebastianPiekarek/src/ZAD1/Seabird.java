package ZAD1;

public class Seabird extends Seacraft implements IAircraft{

    private int height;
    private boolean airbone;

    public Seabird(){
        this.height = 0;
    }

    @Override
    public void takeOff() {
        while (!airbone)
            IncreaseRevs();
    }

    @Override
    public void IncreaseRevs() {
        super.IncreaseRevs();
        if(speed > 40) {
            height += 100;
            this.airbone = getAirbone();
        }
    }

    public boolean getAirbone() {
        return height > 50;
    }

    public int getHeight() {
        return height;
    }



}
