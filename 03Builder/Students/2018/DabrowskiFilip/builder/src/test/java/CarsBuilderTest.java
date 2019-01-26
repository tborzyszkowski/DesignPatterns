import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import simpleBuilder.*;

public class CarsBuilderTest {

    BuildingCompany buildingCompany;

    @Before
    public void prepare_car_park() {
        this.buildingCompany = new BuildingCompany();
    }


    @Test
    public void should_build_bridge() {
        ConstructionBuilder bridgeBuilder = new BridgeBuilder();
        buildingCompany.buildConstruction(bridgeBuilder);
        Construction bridge = bridgeBuilder.getConstruction();

        System.out.println(bridge.toString());

        Assert.assertEquals(bridge.foundations, "Bridge foundations");
        Assert.assertEquals(bridge.roof, "Bridge roof");
        Assert.assertEquals(bridge.mainConstruction, "Bridge construction");

    }

    @Test
    public void should_build_monument() {
        ConstructionBuilder monumentBuilder = new MonumentBuilder();
        buildingCompany.buildConstruction(monumentBuilder);
        Construction monument = monumentBuilder.getConstruction();

        System.out.println(monument.toString());

        Assert.assertEquals(monument.foundations, "Monument foundations");
        Assert.assertEquals(monument.roof, "Monument roof");
        Assert.assertEquals(monument.mainConstruction, "Monument construction");

    }

    @Test
    public void should_build_house() {
        ConstructionBuilder houseBuilder = new HouseBuilder();
        buildingCompany.buildConstruction(houseBuilder);
        Construction house = houseBuilder.getConstruction();

        System.out.println(house.toString());

        Assert.assertEquals(house.foundations, "House foundations");
        Assert.assertEquals(house.roof, "House roof");
        Assert.assertEquals(house.mainConstruction, "House construction");

    }

}
