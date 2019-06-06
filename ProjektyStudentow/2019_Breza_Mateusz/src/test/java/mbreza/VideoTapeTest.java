package mbreza;

import mbreza.videoTape.AgeRestriction;
import mbreza.videoTape.VideoTape;
import org.junit.Test;

import static org.junit.Assert.assertEquals;

public class VideoTapeTest {
    @Test
    public void createVideoTapeTest() {
        VideoTape vt = new VideoTape.Builder()
                .addAgeRestriction(AgeRestriction.GeneralAudiences)
                .addTitle("IT")
                .addDirector("Andres Muschietti")
                .addReleaseYear(2017)
                .addTimeInMinutes(135)
                .build();

        assertEquals(vt.getAgeRestriction(), AgeRestriction.GeneralAudiences);
        assertEquals(vt.getTitle(), "IT");
        assertEquals(vt.getDirector(), "Andres Muschietti");
        assertEquals(vt.getReleaseYear(), 2017);
        assertEquals(vt.getTimeInMinutes(), 135);
    }
}
