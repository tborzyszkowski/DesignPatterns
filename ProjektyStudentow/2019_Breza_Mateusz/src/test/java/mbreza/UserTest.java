package mbreza;

import mbreza.user.NormalUser;
import mbreza.user.PremiumUserDecorator;
import mbreza.user.User;
import mbreza.videoTape.AgeRestriction;
import mbreza.videoTape.VideoTape;
import org.junit.Before;
import org.junit.Test;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

public class UserTest {

    User normalUser;
    User premiumUser;
    VideoTape vt;

    @Before
    public void setup(){
        normalUser = new NormalUser("Robert");
        premiumUser = new PremiumUserDecorator(new NormalUser("Dean"), 4);
        vt = new VideoTape.Builder()
                .addAgeRestriction(AgeRestriction.GeneralAudiences)
                .addTitle("IT")
                .addDirector("Andres Muschietti")
                .addReleaseYear(2017)
                .addTimeInMinutes(135)
                .build();
    }

    @Test
    public void createNormalUserTest(){
        User nu = new NormalUser("Mateusz");

        assertEquals(nu.getRentLimit(), 3);
        assertTrue(nu.getRentList().isEmpty());
        assertEquals(nu.getName(), "Mateusz");
    }

    @Test
    public void createPremiumUserTest(){
        User pu = new PremiumUserDecorator(new NormalUser("Sam"), 4);

        assertEquals(pu.getRentLimit(), 7);
        assertTrue(pu.getRentList().isEmpty());
        assertEquals(pu.getName(), "Sam");
    }

    @Test
    public void setLimitTest(){
        normalUser.setRentLimit(2);
        premiumUser.setRentLimit(6);

        assertEquals(normalUser.getRentLimit(), 2);
        assertEquals(premiumUser.getRentLimit(), 6);
    }

    @Test
    public void addToListTest(){
        normalUser.addRentList(vt);
        premiumUser.addRentList(vt);

        assertTrue(normalUser.getRentList().contains(vt));
        assertTrue(premiumUser.getRentList().contains(vt));
    }

    @Test
    public void  removeFromListTest(){
        normalUser.addRentList(vt);
        premiumUser.addRentList(vt);

        normalUser.removeRentList("IT");
        premiumUser.removeRentList("IT");

        assertTrue(normalUser.getRentList().isEmpty());
        assertTrue(premiumUser.getRentList().isEmpty());
    }
}
