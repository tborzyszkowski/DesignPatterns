package mbreza;

import mbreza.observer.ChangeStatusObserver;
import mbreza.videoTape.AgeRestriction;
import mbreza.videoTape.VideoTape;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import java.io.ByteArrayOutputStream;
import java.io.PrintStream;

import static org.junit.Assert.assertEquals;

public class ObserverTest {

    private final ByteArrayOutputStream outContent = new ByteArrayOutputStream();
    private final PrintStream originalOut = System.out;
    VideoTape vt;

    @Before
    public void setup(){
        vt = new VideoTape.Builder()
                .addAgeRestriction(AgeRestriction.GeneralAudiences)
                .addTitle("IT")
                .addDirector("Andres Muschietti")
                .addReleaseYear(2017)
                .addTimeInMinutes(135)
                .build();
        System.setOut(new PrintStream(outContent));
    }

    @After
    public void restoreStreams() {
        System.setOut(originalOut);
    }

    @Test
    public void addObserverTest(){
        new ChangeStatusObserver(vt);
        assertEquals(vt.getObservers().size(), 1);
    }

    @Test
    public void removeObserverTest(){
        ChangeStatusObserver o = new ChangeStatusObserver(vt);
        assertEquals(vt.getObservers().size(), 1);

        vt.removeObserver(o);
        assertEquals(vt.getObservers().size(), 0);
    }

    @Test
    public void observerMessageTest(){
        new ChangeStatusObserver(vt);
        vt.setAvailable(false);
        assertEquals("Status was changed.", outContent.toString());
    }
}
