import car.cars.Car;
import car.fabricMethodsFactories.CarFactory;
import car.fabricMethodsFactories.FordFactory;
import car.utils.CarType;
import org.junit.Test;

public class CarsTest {

    @Test
    public void create_all_ford_cars_by_fabric_methods_factory() {
        CarFactory fordFactory = FordFactory.getInstance();
        Car sportsCar = fordFactory.orderCar(CarType.SPORTS_CAR);
        Car suvCar = fordFactory.orderCar(CarType.SUV);
        Car sedanCar = fordFactory.orderCar(CarType.SEDAN);
        Car limoCar = fordFactory.orderCar(CarType.LIMO);
        Car hatchBagCar = fordFactory.orderCar(CarType.HATCH_BAG);
    }
}