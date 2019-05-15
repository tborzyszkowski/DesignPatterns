package factoryClassRegistrationWithoutReflection;

import model.Bike;
import model.ElectricBike;

import java.util.function.Supplier;

public class ElectricBikeSupplier implements Supplier<Bike> {

    @Override
    public ElectricBike get() {
        return new ElectricBike();
    }
}
