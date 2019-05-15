package classic;

import classic.enums.BikeType;
import classic.enums.FrameType;

public class KidsBikeBuilder implements BikeBuilder {

    Bike bike;

    public KidsBikeBuilder() {
        this.bike = new Bike();
        bike.setType(BikeType.KIDS);
    }

    public void putWheels() {
        bike.setWheelsSize(20);
        bike.setWheelsNumber(3);
    }

    public void putEngine() {
        bike.setElectricEngine(false);
    }

    public void putFrame() {
        bike.setFrameType(FrameType.ALUMINIOWA);
    }

    public Bike getBike() {
        return this.bike;
    }
}
