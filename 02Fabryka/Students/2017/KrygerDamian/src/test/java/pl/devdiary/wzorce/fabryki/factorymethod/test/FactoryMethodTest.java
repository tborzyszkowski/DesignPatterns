package pl.devdiary.wzorce.fabryki.factorymethod.test;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import pl.devdiary.wzorce.fabryki.factorymethod.*;

import static org.hamcrest.CoreMatchers.instanceOf;

public class FactoryMethodTest
{
    private Barracks romanBarracks;
    private Barracks greeceBarracks;

    @Before
    public void setFactories() {
        romanBarracks = new RomanBarracks();
        greeceBarracks = new GreeceBarracks();
    }

    @Test
    public void checkIfReturnsRomanInfantry()
    {
        Army romanInfantry = romanBarracks.trainUnit(ArmyType.INFANTRY);
        Assert.assertThat(romanInfantry, instanceOf(RomanInfantry.class));
        romanInfantry.attack();
    }

    @Test
    public void checkIfReturnsRomanArchers()
    {
        Army romanArchers = romanBarracks.trainUnit(ArmyType.ARCHERS);
        Assert.assertThat(romanArchers, instanceOf(RomanArchers.class));
        romanArchers.attack();
    }

    @Test
    public void checkIfReturnsRomanCavarly()
    {
        Army romanCavarly = romanBarracks.trainUnit(ArmyType.CAVALRY);
        Assert.assertThat(romanCavarly, instanceOf(RomanCavalry.class));
        romanCavarly.attack();
    }

    @Test
    public void checkIfReturnsGreeceInfantry()
    {
        Army greeceInfantry = greeceBarracks.trainUnit(ArmyType.INFANTRY);
        Assert.assertThat(greeceInfantry, instanceOf(GreeceInfantry.class));
        greeceInfantry.attack();
    }

    @Test
    public void checkIfReturnsGreeceArchers()
    {
        Army greeceArchers = greeceBarracks.trainUnit(ArmyType.ARCHERS);
        Assert.assertThat(greeceArchers, instanceOf(GreeceArchers.class));
        greeceArchers.attack();
    }

    @Test
    public void checkIfReturnsGreeceCavarly()
    {
        Army greeceCavarly = greeceBarracks.trainUnit(ArmyType.CAVALRY);
        Assert.assertThat(greeceCavarly, instanceOf(GreeceCavalry.class));
        greeceCavarly.attack();
    }
}
