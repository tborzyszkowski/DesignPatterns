package ZAD1;

public class Aircraft implements IAircraft {

    int height;
    boolean airborne;

    public Aircraft(){
        this.height = 0;
        this.airborne = false;
    }


    @Override
    public void takeOff() {
        System.out.println("Aircraft engine takeoff");
        airborne = true;
        height = 200;
    }

    public boolean getAirborne() {
        return airborne;
    }

    public int getHeight() {
        return height;
    }
}
