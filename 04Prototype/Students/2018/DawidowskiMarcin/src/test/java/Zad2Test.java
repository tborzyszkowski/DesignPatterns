import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import zad2.Car;
import zad2.CarManager;
import zad2.carType.CarType;
import zad2.carType.Transmission;
import zad2.carType.Type;
import zad2.engine.Engine;
import zad2.engine.EngineType;

public class Zad2Test {

    CarManager carManager;

    @Before
    public void create_car_manager() {
        this.carManager = new CarManager();
    }

    @Test
    public void createDeepPrototype() {

        Car car = carManager.createCar();

        Car car1 = car.clone();
        Car car2 = car.clone();


        Assert.assertNotEquals(car, car1);

        car1.setEngine(new Engine(EngineType.V12, 550));

        car2.setType(new Type(CarType.Sport, Transmission.Automatic));
        car2.setEngine(new Engine(EngineType.V8, 400));

        System.out.println(car.toString());
        System.out.println(car1.toString());
        System.out.println(car2.toString());


    }
}
