package mbreza;

import mbreza.service.Mediator;
import mbreza.service.ServiceType;
import mbreza.user.NormalUser;
import mbreza.user.PremiumUserDecorator;
import mbreza.user.User;
import mbreza.videoTape.AgeRestriction;
import mbreza.videoTape.VideoTape;
import org.junit.Before;
import org.junit.Test;

import java.util.ArrayList;

import static org.junit.Assert.*;

public class MediatorTest {

    User user;
    User premiumUser;
    VideoTape videoTapeOne;
    VideoTape videoTapeTwo;
    Mediator mediator;
    ArrayList<VideoTape> tapeList;

    @Before
    public void setup(){
        user = new NormalUser("Mateusz");
        premiumUser = new PremiumUserDecorator(new NormalUser("Robert"), 3);
        videoTapeOne = new VideoTape.Builder()
                .addAgeRestriction(AgeRestriction.GeneralAudiences)
                .addTitle("IT")
                .addDirector("Andres Muschietti")
                .addReleaseYear(2017)
                .addTimeInMinutes(135)
                .addAvailable(true)
                .build();
        videoTapeTwo = new VideoTape.Builder()
                .addAgeRestriction(AgeRestriction.GeneralAudiences)
                .addTitle("Cloud Atlas")
                .addDirector("Tom Tykwer")
                .addReleaseYear(2012)
                .addTimeInMinutes(172)
                .addAvailable(true)
                .build();
        tapeList = new ArrayList<>();
        tapeList.add(videoTapeOne);
        tapeList.add(videoTapeTwo);
        mediator = Mediator.getInstance(new ArrayList<VideoTape>());
        mediator.addList(tapeList);
    }

    @Test
    public void rentAndReturnNormalTapeTest() throws InterruptedException {
        user = mediator.serviceVideoTape(user, videoTapeOne.getTitle(), ServiceType.RENT);

        assertEquals(user.getRentLimit(), 2);
        assertEquals(user.getRentList().get(0).getTitle(), "IT");
        boolean guardian = false;
        for(VideoTape tape : mediator.getTapeList()){
            if(tape.getTitle().equals("IT") && !tape.isAvailable()){
                guardian = true;
                break;
            }
        }
        assertTrue(guardian);


        user = mediator.serviceVideoTape(user, videoTapeOne.getTitle(), ServiceType.RETURNN);

        assertEquals(user.getRentLimit(), 3);
        assertTrue(user.getRentList().isEmpty());
        for(VideoTape tape : mediator.getTapeList()){
            if(tape.getTitle().equals("IT") && tape.isAvailable()){
                guardian = false;
                break;
            }
        }
        assertTrue(!guardian);
    }

    @Test
    public void rentAndReturnPremiumTapeTest() throws InterruptedException {
        premiumUser = mediator.serviceVideoTape(premiumUser, videoTapeTwo.getTitle(), ServiceType.RENT);

        assertEquals(premiumUser.getRentLimit(), 5);
        assertEquals(premiumUser.getRentList().get(0).getTitle(), "Cloud Atlas");
        boolean guardian = false;
        for(VideoTape tape : mediator.getTapeList()){
            if(tape.getTitle().equals("Cloud Atlas") && !tape.isAvailable()){
                guardian = true;
                break;
            }
        }
        assertTrue(guardian);

        premiumUser = mediator.serviceVideoTape(premiumUser, videoTapeTwo.getTitle(), ServiceType.RETURNN);

        assertEquals(premiumUser.getRentLimit(), 6);
        assertTrue(premiumUser.getRentList().isEmpty());
        for(VideoTape tape : mediator.getTapeList()){
            if(tape.getTitle().equals("Cloud Atlas") && tape.isAvailable()){
                guardian = false;
                break;
            }
        }
        assertTrue(!guardian);
    }
}
