package pl.devdiary.wzorce.fabryki.factoryclassregistration.test;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import pl.devdiary.wzorce.fabryki.factoryclassregistration.*;

import java.lang.reflect.InvocationTargetException;
import java.util.HashMap;

import static org.hamcrest.CoreMatchers.instanceOf;

public class FactoryClassRegistrationTest {

    private ArmyFactory factory;

    @Before
    public void setFactory() throws InstantiationException, IllegalAccessException {
        loadAllClassess();

        factory = ArmyFactory.getInstance();
    }

    private void loadAllClassess() throws IllegalAccessException, InstantiationException {
        Cavarly.class.newInstance();
        Infantry.class.newInstance();
        Archers.class.newInstance();
    }

    @Test
    public void checkSizeOfHashMap()
    {
        HashMap<ArmyType, Class> map = ArmyFactory.getInstance().getRegisteredClasses();
        Assert.assertNotEquals(map.size(), 0);
    }

    @Test
    public void checkIfReturnsInfantry() throws NoSuchMethodException, IllegalAccessException, InvocationTargetException {
        Army infantry = factory.createArmy(ArmyType.INFANTRY);
        Assert.assertThat(infantry, instanceOf(Infantry.class));
        infantry.attack();
    }
}
