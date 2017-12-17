package pl.devdiary.wzorce.fabryki.simplefactory.test;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import pl.devdiary.wzorce.fabryki.simplefactory.*;

import static org.hamcrest.CoreMatchers.instanceOf;

public class SimpleFactoryTest {

    private SimpleArmyFactory factory;

    @Before
    public void setFactory() {
        factory = new SimpleArmyFactory();
    }

    @Test
    public void getInfantryTest() {
        Assert.assertThat(factory.createArmy(ArmyType.INFANTRY), instanceOf(Infantry.class));
    }

    @Test
    public void getCavalryTest() {
        Assert.assertThat(factory.createArmy(ArmyType.CAVALRY), instanceOf(Cavalry.class));
    }

    @Test
    public void getArchersTest() {
        Assert.assertThat(factory.createArmy(ArmyType.ARCHERS), instanceOf(Archers.class));
    }
}
