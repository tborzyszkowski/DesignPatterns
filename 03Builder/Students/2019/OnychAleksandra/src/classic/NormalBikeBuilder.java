package classic;

import classic.enums.BikeType;
import classic.enums.FrameType;

public class NormalBikeBuilder implements BikeBuilder {
    Bike bike;

    public NormalBikeBuilder() {
        this.bike = new Bike();
        bike.setType(BikeType.NORMAL);
    }

    public void putWheels() {
        bike.setWheelsSize(26);
        bike.setWheelsNumber(2);
    }

    public void putEngine() {
        bike.setElectricEngine(false);
    }

    public void putFrame() {
        bike.setFrameType(FrameType.STALOWA);
    }

    public Bike getBike() {
        return this.bike;
    }
}
