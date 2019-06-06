package pkawa.registered.reflection;

import org.junit.Test;
import pkawa.model.ConsoleCodename;
import pkawa.model.PlayStation4;
import pkawa.model.XboxOne;

import static org.junit.Assert.assertTrue;

public class ReflectionConsoleFactoryTest {

    private String gameTitle = "WITCHER 3";

    @Test
    public void consoleShouldBeInstanceOfPS4() {
        ReflectionConsoleFactory.INSTANCE.registerConsole(ConsoleCodename.PS4, PlayStation4.class);
        var console = ReflectionConsoleFactory.INSTANCE.createConsole(ConsoleCodename.PS4);
        assertTrue(console instanceof PlayStation4);
    }

    @Test
    public void consoleShouldBeInstanceOfXBone() {
        ReflectionConsoleFactory.INSTANCE.registerConsole(ConsoleCodename.XBOX_ONE, XboxOne.class);
        var console = ReflectionConsoleFactory.INSTANCE.createConsole(ConsoleCodename.XBOX_ONE);
        assertTrue(console instanceof XboxOne);

    }

    @Test
    public void bothConsolesAreNotTheSameObject() {

        ReflectionConsoleFactory.INSTANCE.registerConsole(ConsoleCodename.PS4, PlayStation4.class);
        var console = ReflectionConsoleFactory.INSTANCE.createConsole(ConsoleCodename.PS4);
        var console2 = ReflectionConsoleFactory.INSTANCE.createConsole(ConsoleCodename.PS4);

        assert console != null;
        assert console2 != null;
        assertTrue(console.hashCode() != console2.hashCode());
    }

    @Test
    public void timingTest() {
        var beforeTime = System.currentTimeMillis();
        for (long i = 0; i < (int) Math.pow(1024.0, 2); i++) {
            ReflectionConsoleFactory.INSTANCE.registerConsole(ConsoleCodename.XBOX_ONE, XboxOne.class);
            var console = ReflectionConsoleFactory.INSTANCE.createConsole(ConsoleCodename.XBOX_ONE);
        }
        var runTime = System.currentTimeMillis() - beforeTime;
        System.out.println(String.format("Reflection Registered factory runtime: %s milliseconds", runTime));
    }
}