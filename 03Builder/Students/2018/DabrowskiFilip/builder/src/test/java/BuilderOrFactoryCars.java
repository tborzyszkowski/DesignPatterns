import builderOrFactory.cars.Car;
import builderOrFactory.cars.CarType;
import builderOrFactory.cars.factory.SimpleAudiFactory;
import org.junit.Before;
import org.junit.Test;

public class BuilderOrFactoryCars {

        SimpleAudiFactory simpleAudiFactory;

        @Before
        public void prepare_factory_and_builder() {
            this.simpleAudiFactory = SimpleAudiFactory.getInstance();
        }

        @Test
        public void create_cars_by_simple_factory(){

            Car sportsCar = simpleAudiFactory.createCar(CarType.SPORTS_CAR);
            Car sedanCar = simpleAudiFactory.createCar(CarType.SEDAN);
            Car suvCar = simpleAudiFactory.createCar(CarType.SUV);

            System.out.println(sportsCar.toString());
            System.out.println(sedanCar.toString());
            System.out.println(suvCar.toString());
        }

        @Test
        public void build_sports_car_with_builder() {

        }

}
