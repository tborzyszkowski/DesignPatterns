package mbreza;

import mbreza.classic.*;
import org.junit.Before;
import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class ClassicTest {

    RpgSessionGenerator rsg;

    @Before
    public void setup(){
        rsg = new RpgSessionGenerator();
    }

    @Test
    public void getDungeonsAndDragonsTest() {

        RpgSessionBuilder rsb = new DungeonsAandDragonsSessionBuilder();
        rsg.generateSession(rsb);
        RpgSession rs = rsb.getRpgSession();

        assertEquals(rs.getGameType(), GameType.DUNGEONSANDDRAGONS);
        assertEquals(rs.getGameMaster(), "Mark");
        assertEquals(rs.getNumberOfPlayers(), 5);
        assertEquals(rs.getSessionLocation(), "Mark's basement");
    }

    @Test
    public void getCallOfCthulhuTest() {

        RpgSessionBuilder rsb = new CallOfCthulhuSessionBuilder();
        rsg.generateSession(rsb);
        RpgSession rs = rsb.getRpgSession();

        assertEquals(rs.getGameType(), GameType.CALLOFCTHULHU);
        assertEquals(rs.getGameMaster(), "Luke");
        assertEquals(rs.getNumberOfPlayers(), 3);
        assertEquals(rs.getSessionLocation(), "Luke's basement");
    }

    @Test
    public void getWarhammerTest() {

        RpgSessionBuilder rsb = new WarhammerSessionBuilder();
        rsg.generateSession(rsb);
        RpgSession rs = rsb.getRpgSession();

        assertEquals(rs.getGameType(), GameType.WARHAMMER);
        assertEquals(rs.getGameMaster(), "John");
        assertEquals(rs.getNumberOfPlayers(), 4);
        assertEquals(rs.getSessionLocation(), "John's basement");
    }

}
