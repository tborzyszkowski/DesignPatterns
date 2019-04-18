package classic;

import classic.enums.BikeType;
import classic.enums.FrameType;

public class ElectricBikeBuilder implements BikeBuilder {

    Bike bike;

    public ElectricBikeBuilder() {
        this.bike = new Bike();
        bike.setType(BikeType.ELECTRIC);
    }

    public void putWheels() {
        bike.setWheelsSize(28);
        bike.setWheelsNumber(2);
    }

    public void putEngine() {
        bike.setElectricEngine(true);
    }

    public void putFrame() {
        bike.setFrameType(FrameType.TYTANOWA);
    }

    public Bike getBike() {
        return this.bike;
    }

}
