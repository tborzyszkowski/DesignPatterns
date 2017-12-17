package pl.devdiary.wzorce.fabryki.abstractfactory.test;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import pl.devdiary.wzorce.fabryki.abstractfactory.*;

import static org.hamcrest.CoreMatchers.instanceOf;

public class AbstractFactoryTest {

    private AbstractArmyFactory greeceBarracks;
    private AbstractArmyFactory romanBarracks;

    @Before
    public void setFactories() {
        greeceBarracks = new GreeceBarracks();
        romanBarracks = new RomanBarracks();
    }

    @Test
    public void checkIfReturnsRomanInfantry()
    {
        Army romanInfantry = romanBarracks.trainUnit(ArmyType.INFANTRY);
        Assert.assertThat(romanInfantry, instanceOf(RomanInfantry.class));
        romanInfantry.attack();
    }

    @Test
    public void checkIfReturnsGreeceArchers()
    {
        Army greeceArchers = greeceBarracks.trainUnit(ArmyType.ARCHERS);
        Assert.assertThat(greeceArchers, instanceOf(GreeceArchers.class));
        greeceArchers.attack();
    }

}
