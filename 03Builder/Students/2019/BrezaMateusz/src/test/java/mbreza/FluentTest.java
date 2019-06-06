package mbreza;

import mbreza.classic.GameType;
import mbreza.fluent.RpgSessionFluent;
import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class FluentTest {

    @Test
    public void getSessionTest() {
        RpgSessionFluent rsf = new RpgSessionFluent.Builder()
                .addGameType(GameType.CALLOFCTHULHU)
                .addGameMaster("Scotty")
                .addNumberOfPlayers(4)
                .addSessionLocation("Scotty's basement")
                .build();

        assertEquals(rsf.getGameType(), GameType.CALLOFCTHULHU);
        assertEquals(rsf.getGameMaster(), "Scotty");
        assertEquals(rsf.getNumberOfPlayers(), 4);
        assertEquals(rsf.getSessionLocation(), "Scotty's basement");
    }
}
