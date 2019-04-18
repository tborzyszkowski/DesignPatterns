import builderWins.builder.Car;
import builderWins.factory.CarAbstractFactory;
import builderWins.factory.CarBase;
import builderWins.factory.CarFactory;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

class BuilderWinsTest {

    private CarAbstractFactory factory = CarFactory.getInstance();

    @Test
    public void shouldReturnCarFromFactory() {
        CarBase audi = factory.makeCar("AUDI");

        assertTrue(audi instanceof CarBase);
        System.out.println(audi + "\n");
    }

    @Test
    public void shouldReturnCarFromBuilder() {
        Car car = new Car.Builder()
                .brand("Audi")
                .model("Q8")
                .engine("3500")
                .productionYear("2019")
                .airConditioning(true)
                .radio(true)
                .fuelType("diesel")
                .build();

        assertTrue(car instanceof CarBase);
        System.out.println(car);
    }
}