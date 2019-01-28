import builderVsFactory.Car;
import builderVsFactory.builder.KIA;
import builderVsFactory.builder.KIABuilder;
import builderVsFactory.factory.CarFactory;
import builderVsFactory.factory.KIAFactory;
import org.junit.*;

public class BuilderVsFactoryTest {

    private KIABuilder kiaBuilder;
    private CarFactory kiaFactory;
    @Before
    public void prepare_builder_and_factory() {
        this.kiaBuilder = new KIABuilder();
        this.kiaFactory = new CarFactory();

    }

    @Test
    public void build_stinger_with_factory() {
        long factoryStartTime = System.nanoTime();
        Car factoryStinger = kiaFactory.getCar(new KIAFactory("KIA", "Stinger", "Sedan", "Gasoline", 160000));
        long factoryEndTime = System.nanoTime();
        System.out.println("Czas fabryki - " + (factoryEndTime-factoryStartTime));
        Assert.assertEquals("KIA", factoryStinger.brandName);
        Assert.assertEquals("Stinger", factoryStinger.model);
        Assert.assertEquals("Sedan", factoryStinger.type);
        Assert.assertEquals("Gasoline", factoryStinger.fuelType);
        Assert.assertEquals(160000, factoryStinger.price);
        System.out.println("Factory => " + factoryStinger.toString());
    }

    @Test
    public void build_stinger_with_builder() {
        long builderStartTime = System.nanoTime();
        KIA builderStinger = kiaBuilder
                .withBrand("KIA")
                .withModel("Stinger")
                .withType("Sedan")
                .withFuelType("Gasoline")
                .withPrice(160000)
                .buildKIA();
        long builderEndTime = System.nanoTime();
        System.out.println("Czas buildera - " + (builderEndTime-builderStartTime));

        Assert.assertEquals("KIA", builderStinger.brandName);
        Assert.assertEquals("Stinger", builderStinger.model);
        Assert.assertEquals("Sedan", builderStinger.type);
        Assert.assertEquals("Gasoline", builderStinger.fuelType);
        Assert.assertEquals(160000, builderStinger.price);
        System.out.println("Builder => " + builderStinger.toString());
    }
}
