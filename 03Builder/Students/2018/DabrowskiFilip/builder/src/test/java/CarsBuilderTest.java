import org.junit.Assert;
import org.junit.Test;

public class CarsBuilderTest {

    @Test
    public void should_build_sports_car() {
        CarBuilder sportsCarBuilder = new SportsCarBuilder();

        sportsCarBuilder.buildWheels();
        sportsCarBuilder.buildEngine();
        sportsCarBuilder.buildBody();
        Car sportsCar = sportsCarBuilder.getCar();

        Assert.assertEquals(sportsCar.wheels, "Sports 21' wheels");
        Assert.assertEquals(sportsCar.bodyType, "sport body");
        Assert.assertEquals(sportsCar.engineCapacity, "4.0");

    }

    @Test
    public void should_build_jeep_car() {
        CarBuilder jeepCarBuilder = new JeepCarBuilder();

        jeepCarBuilder.buildWheels();
        jeepCarBuilder.buildEngine();
        jeepCarBuilder.buildBody();
        Car jeepCar = jeepCarBuilder.getCar();

        Assert.assertEquals(jeepCar.wheels, "23' off-road wheels");
        Assert.assertEquals(jeepCar.bodyType, "off-road body");
        Assert.assertEquals(jeepCar.engineCapacity, "2.0");

    }

    @Test
    public void should_build_city_car() {
        CarBuilder cityCarBuilder = new CityCarBuilder();

        cityCarBuilder.buildWheels();
        cityCarBuilder.buildEngine();
        cityCarBuilder.buildBody();
        Car cityCar = cityCarBuilder.getCar();

        Assert.assertEquals(cityCar.wheels, "14' city wheels");
        Assert.assertEquals(cityCar.bodyType, "14' city wheels");
        Assert.assertEquals(cityCar.engineCapacity, "1.3");

    }

}
