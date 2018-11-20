import abstractFactory.*;
import abstractFactory.audi.AudiServiceFactory;
import abstractFactory.mercedes.MercedesServiceFactory;
import cars.Car;
import fabricMethodsFactories.AudiFactory;
import fabricMethodsFactories.CarFactory;
import fabricMethodsFactories.FordFactory;
import fabricMethodsFactories.MercedesFactory;
import org.junit.Test;
import simpleFactory.SimpleAudiFactory;
import utils.CarType;

public class CarsTest {

    @Test
    public void create_audi_by_simple_factory(){
        SimpleAudiFactory simpleAudiFactory = SimpleAudiFactory.getInstance();
        Car sportsCar = simpleAudiFactory.createCar(CarType.SPORTS_CAR);
        Car hatchBagCar = simpleAudiFactory.createCar(CarType.HATCH_BAG);
        Car sedanCar = simpleAudiFactory.createCar(CarType.SEDAN);
        Car suvCar = simpleAudiFactory.createCar(CarType.SUV);
        Car limoCar = simpleAudiFactory.createCar(CarType.LIMO);

        System.out.println(sportsCar.toString());
        System.out.println(hatchBagCar.toString());
        System.out.println(sedanCar.toString());
        System.out.println(suvCar.toString());
        System.out.println(limoCar.toString());
    }

    @Test
    public void create_all_mercedes_cars_by_fabric_methods_factory() {
        CarFactory mercedesFactory = MercedesFactory.getInstance();
        mercedesFactory.orderCar(CarType.SPORTS_CAR);
        mercedesFactory.orderCar(CarType.SUV);
        mercedesFactory.orderCar(CarType.SEDAN);
        mercedesFactory.orderCar(CarType.LIMO);
        mercedesFactory.orderCar(CarType.HATCH_BAG);
    }

    @Test
    public void create_all_audi_cars_by_fabric_methods_factory() {
        CarFactory audiFactory = AudiFactory.getInstance();
        audiFactory.orderCar(CarType.SPORTS_CAR);
        audiFactory.orderCar(CarType.SUV);
        audiFactory.orderCar(CarType.SEDAN);
        audiFactory.orderCar(CarType.LIMO);
        audiFactory.orderCar(CarType.HATCH_BAG);
    }

    @Test
    public void create_all_ford_cars_by_fabric_methods_factory() {
        CarFactory fordFactory = FordFactory.getInstance();
        fordFactory.orderCar(CarType.SPORTS_CAR);
        fordFactory.orderCar(CarType.SUV);
        fordFactory.orderCar(CarType.SEDAN);
        fordFactory.orderCar(CarType.LIMO);
        fordFactory.orderCar(CarType.HATCH_BAG);
    }

    @Test
    public void create_abstract_audi_service_factory() {
        CarServiceFactory audiServiceFactory = AudiServiceFactory.getInstance();
        CarChecker carChecker = audiServiceFactory.getCarChecker();
        CarCleaner carCleaner = audiServiceFactory.getCarCleaner();

        carChecker.checkGearBox();
        carChecker.checkEngine();
        carCleaner.cleanCar();
    }

    @Test
    public void create_abstract_mercedes_service_factory() {
        CarServiceFactory mercedesServiceFactory = MercedesServiceFactory.getInstance();
        CarChecker carChecker = mercedesServiceFactory.getCarChecker();
        CarCleaner carCleaner = mercedesServiceFactory.getCarCleaner();

        carChecker.checkGearBox();
        carChecker.checkEngine();
        carCleaner.cleanCar();
    }
}
