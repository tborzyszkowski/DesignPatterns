package mbreza;

import mbreza.service.Mediator;
import mbreza.service.SeriesService;
import mbreza.service.SeriesType;
import mbreza.service.ServiceType;
import mbreza.user.NormalUser;
import mbreza.user.PremiumUserDecorator;
import mbreza.user.User;
import mbreza.videoTape.VideoTape;
import org.junit.Before;
import org.junit.Test;

import java.util.ArrayList;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

public class FacadeTest {

    User user;
    User premiumUser;
    SeriesService seriesService;
    Mediator mediator;

    @Before
    public void setup(){
        user = new NormalUser("Mateusz");
        premiumUser = new PremiumUserDecorator(new NormalUser("Robert"), 4);
        seriesService = new SeriesService();
        mediator = Mediator.getInstance(new ArrayList<VideoTape>());

    }

    @Test
    public void hpTest() throws InterruptedException {
        ArrayList<VideoTape> tapeList = seriesService.addSeries(SeriesType.HP);

        assertEquals(tapeList.get(0).getTitle(), "The Philosopher's Stone");
        assertEquals(tapeList.get(1).getTitle(), "The Chamber of Secrets");
        assertEquals(tapeList.get(2).getTitle(), "The Prisoner of Azkaban");
        assertEquals(tapeList.get(3).getTitle(), "The Goblet of Fire");
        assertEquals(tapeList.get(4).getTitle(), "The Order of the Phoenix");
        assertEquals(tapeList.get(5).getTitle(), "The Half-Blood Prince");
        assertEquals(tapeList.get(6).getTitle(), "The Deathly Hallows");

        mediator.addList(tapeList);

        premiumUser = seriesService.rentOrReturnSeries(premiumUser, ServiceType.RENT, mediator, SeriesType.HP);

        assertEquals(premiumUser.getRentLimit(), 0);
        assertEquals(premiumUser.getRentList().get(0).getTitle(), "The Philosopher's Stone");
        assertEquals(premiumUser.getRentList().get(1).getTitle(), "The Chamber of Secrets");
        assertEquals(premiumUser.getRentList().get(2).getTitle(), "The Prisoner of Azkaban");
        assertEquals(premiumUser.getRentList().get(3).getTitle(), "The Goblet of Fire");
        assertEquals(premiumUser.getRentList().get(4).getTitle(), "The Order of the Phoenix");
        assertEquals(premiumUser.getRentList().get(5).getTitle(), "The Half-Blood Prince");
        assertEquals(premiumUser.getRentList().get(6).getTitle(), "The Deathly Hallows");

        premiumUser = seriesService.rentOrReturnSeries(premiumUser, ServiceType.RETURNN, mediator, SeriesType.HP);

        assertEquals(premiumUser.getRentLimit(), 7);
        assertEquals(premiumUser.getRentList().size(), 0);
    }

    @Test
    public void lotrTest() throws InterruptedException {
        ArrayList<VideoTape> tapeList = seriesService.addSeries(SeriesType.LOTR);

        assertEquals(tapeList.get(0).getTitle(), "The Fellowship of the Ring");
        assertEquals(tapeList.get(1).getTitle(), "The Two Towers");
        assertEquals(tapeList.get(2).getTitle(), "The Return of the King");

        mediator.addList(tapeList);

        user = seriesService.rentOrReturnSeries(user, ServiceType.RENT, mediator, SeriesType.LOTR);

        assertEquals(user.getRentLimit(), 0);
        assertEquals(user.getRentList().get(0).getTitle(), "The Fellowship of the Ring");
        assertEquals(user.getRentList().get(1).getTitle(), "The Two Towers");
        assertEquals(user.getRentList().get(2).getTitle(), "The Return of the King");

        user = seriesService.rentOrReturnSeries(user, ServiceType.RETURNN, mediator, SeriesType.LOTR);

        assertEquals(user.getRentLimit(), 3);
        assertEquals(user.getRentList().size(), 0);
    }

}
