package builder;

import lombok.extern.java.Log;
import org.junit.Test;

@Log
public class VehicleTest {

    @Test
    public void test () {
        VehicleConstructor delegate = new VehicleConstructor();

        Vehicle car = delegate.buildCar();
        log.info(car.toString());

        Vehicle motorcycle = delegate.buildMotorCycle();
        log.info(motorcycle.toString());

        Vehicle scooter = delegate.buildScooter();
        log.info(scooter.toString());
    }

}