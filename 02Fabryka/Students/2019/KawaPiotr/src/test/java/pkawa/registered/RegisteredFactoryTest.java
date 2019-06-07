package pkawa.registered;

import org.junit.Test;
import pkawa.model.ConsoleCodename;
import pkawa.model.PlayStation4;
import pkawa.model.XboxOne;

import static org.junit.Assert.assertTrue;

public class RegisteredFactoryTest {

    private String gameTitle = "WITCHER 3";

    @Test
    public void consoleShouldBeInstanceOfPS4() {
        ConsoleFactory.INSTANCE.registerConsole(ConsoleCodename.PS4, new PlayStationSupplier());
        var console = ConsoleFactory.INSTANCE.createConsole(ConsoleCodename.PS4);
        assertTrue(console instanceof PlayStation4);
    }

    @Test
    public void consoleShouldBeInstanceOfXBone() {
        ConsoleFactory.INSTANCE.registerConsole(ConsoleCodename.XBOX_ONE, XboxOne::new);
        var console = ConsoleFactory.INSTANCE.createConsole(ConsoleCodename.XBOX_ONE);
        assertTrue(console instanceof XboxOne);

    }

    @Test
    public void timingTest() {
        var beforeTime = System.currentTimeMillis();
        for (long i = 0; i < (int) Math.pow(1024.0, 2); i++) {
            ConsoleFactory.INSTANCE.registerConsole(ConsoleCodename.PS4, new PlayStationSupplier());
            var console = ConsoleFactory.INSTANCE.createConsole(ConsoleCodename.XBOX_ONE);
        }
        var runTime = System.currentTimeMillis() - beforeTime;
        System.out.println(String.format("Registered factory runtime: %s milliseconds", runTime));
    }
}

