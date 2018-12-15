import builderOrFactory.cars.Car;
import builderOrFactory.cars.CarType;
import builderOrFactory.cars.builder.AudiCar;
import builderOrFactory.cars.builder.AudiCarBuilder;
import builderOrFactory.cars.factory.SimpleAudiFactory;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

public class BuilderOrFactoryCars {

    private SimpleAudiFactory simpleAudiFactory;
    private AudiCarBuilder audiCarBuilder;

    @Before
    public void prepare_factory_and_builder() {
        this.simpleAudiFactory = SimpleAudiFactory.getInstance();
        this.audiCarBuilder = new AudiCarBuilder();
    }

    @Test
    public void create_sports_car_with_simple_factory() {

        Car sportsAudiCar = simpleAudiFactory.createCar(CarType.SPORTS_CAR);

        System.out.println(sportsAudiCar.toString());

        Assert.assertEquals("audi", sportsAudiCar.name);
        Assert.assertEquals("RS7", sportsAudiCar.model);
        Assert.assertEquals(2016, sportsAudiCar.productionYear);
        Assert.assertEquals("manual", sportsAudiCar.gearBoxType);
    }

    @Test
    public void create_sedan_car_with_simple_factory() {

        Car sedanAudiCar = simpleAudiFactory.createCar(CarType.SEDAN);

        System.out.println(sedanAudiCar.toString());

        Assert.assertEquals("audi", sedanAudiCar.name);
        Assert.assertEquals("A6", sedanAudiCar.model);
        Assert.assertEquals(2017, sedanAudiCar.productionYear);
        Assert.assertEquals("automatic", sedanAudiCar.gearBoxType);
    }

    @Test
    public void create_suv_car_with_simple_factory() {

        Car suvAudiCar = simpleAudiFactory.createCar(CarType.SUV);

        System.out.println(suvAudiCar.toString());

        Assert.assertEquals("audi", suvAudiCar.name);
        Assert.assertEquals("Q7", suvAudiCar.model);
        Assert.assertEquals(2015, suvAudiCar.productionYear);
        Assert.assertEquals("automatic", suvAudiCar.gearBoxType);
    }

    @Test
    public void build_sports_car_with_builder() {
        AudiCar sportsAudiCar = audiCarBuilder
                .withName("audi")
                .withModel("RS7")
                .withProductionYear(2016)
                .withGearboxType("manual")
                .buildAudiCar();

        System.out.println(sportsAudiCar.toString());

        Assert.assertEquals("audi", sportsAudiCar.name);
        Assert.assertEquals("RS7", sportsAudiCar.model);
        Assert.assertEquals(2016, sportsAudiCar.productionYear);
        Assert.assertEquals("manual", sportsAudiCar.gearBoxType);

    }

    @Test
    public void build_sedan_car_with_builder() {
        AudiCar sedanAudiCar = audiCarBuilder
                .withName("audi")
                .withModel("A6")
                .withProductionYear(2017)
                .withGearboxType("automatic")
                .buildAudiCar();

        System.out.println(sedanAudiCar.toString());

        Assert.assertEquals("audi", sedanAudiCar.name);
        Assert.assertEquals("A6", sedanAudiCar.model);
        Assert.assertEquals(2017, sedanAudiCar.productionYear);
        Assert.assertEquals("automatic", sedanAudiCar.gearBoxType);

    }

    @Test
    public void build_suv_car_with_builder() {
        AudiCar suvAudiCar = audiCarBuilder
                .withName("audi")
                .withModel("Q7")
                .withProductionYear(2015)
                .withGearboxType("automatic")
                .buildAudiCar();

        System.out.println(suvAudiCar.toString());

        Assert.assertEquals("audi", suvAudiCar.name);
        Assert.assertEquals("Q7", suvAudiCar.model);
        Assert.assertEquals(2015, suvAudiCar.productionYear);
        Assert.assertEquals("automatic", suvAudiCar.gearBoxType);

    }

}
