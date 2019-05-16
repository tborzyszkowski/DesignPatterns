package mbreza.service;

import mbreza.user.User;
import mbreza.videoTape.AgeRestriction;
import mbreza.videoTape.VideoTape;

import java.util.ArrayList;

public class SeriesService {

    public User rentOrReturnSeries(User user, ServiceType serviceType, Mediator mediator, SeriesType seriesType) throws InterruptedException {
        switch (seriesType) {
            case LOTR:
                user = mediator.serviceVideoTape(user, "The Fellowship of the Ring", serviceType);
                user = mediator.serviceVideoTape(user, "The Two Towers", serviceType);
                user = mediator.serviceVideoTape(user, "The Return of the King", serviceType);
                break;
            case HP:
                user = mediator.serviceVideoTape(user, "The Philosopher's Stone", serviceType);
                user = mediator.serviceVideoTape(user, "The Chamber of Secrets", serviceType);
                user = mediator.serviceVideoTape(user, "The Prisoner of Azkaban", serviceType);
                user = mediator.serviceVideoTape(user, "The Goblet of Fire", serviceType);
                user = mediator.serviceVideoTape(user, "The Order of the Phoenix", serviceType);
                user = mediator.serviceVideoTape(user, "The Half-Blood Prince", serviceType);
                user = mediator.serviceVideoTape(user, "The Deathly Hallows", serviceType);
                break;
        }
        return user;
    }

    public ArrayList<VideoTape> addSeries(SeriesType seriesType) {
        ArrayList<VideoTape> tapeList = new ArrayList<>();

        switch (seriesType) {
            case LOTR:
                VideoTape lotr1 = new VideoTape.Builder()
                        .addAgeRestriction(AgeRestriction.GeneralAudiences)
                        .addTitle("The Fellowship of the Ring")
                        .addDirector("Peter Jackson")
                        .addReleaseYear(2001)
                        .addTimeInMinutes(178)
                        .addAvailable(true)
                        .build();
                tapeList.add(lotr1);
                VideoTape lotr2 = new VideoTape.Builder()
                        .addAgeRestriction(AgeRestriction.GeneralAudiences)
                        .addTitle("The Two Towers")
                        .addDirector("Peter Jackson")
                        .addReleaseYear(2002)
                        .addTimeInMinutes(179)
                        .addAvailable(true)
                        .build();
                tapeList.add(lotr2);
                VideoTape lotr3 = new VideoTape.Builder()
                        .addAgeRestriction(AgeRestriction.GeneralAudiences)
                        .addTitle("The Return of the King")
                        .addDirector("Peter Jackson")
                        .addReleaseYear(2003)
                        .addTimeInMinutes(211)
                        .addAvailable(true)
                        .build();
                tapeList.add(lotr3);
                break;
            case HP:
                VideoTape hp1 = new VideoTape.Builder()
                        .addAgeRestriction(AgeRestriction.GeneralAudiences)
                        .addTitle("The Philosopher's Stone")
                        .addDirector("Chris Columbus")
                        .addReleaseYear(2001)
                        .addTimeInMinutes(152)
                        .addAvailable(true)
                        .build();
                tapeList.add(hp1);
                VideoTape hp2 = new VideoTape.Builder()
                        .addAgeRestriction(AgeRestriction.GeneralAudiences)
                        .addTitle("The Chamber of Secrets")
                        .addDirector("Chris Columbus")
                        .addReleaseYear(2002)
                        .addTimeInMinutes(161)
                        .addAvailable(true)
                        .build();
                tapeList.add(hp2);
                VideoTape hp3 = new VideoTape.Builder()
                        .addAgeRestriction(AgeRestriction.GeneralAudiences)
                        .addTitle("The Prisoner of Azkaban")
                        .addDirector("Alfonso Cuarón")
                        .addReleaseYear(2004)
                        .addTimeInMinutes(141)
                        .addAvailable(true)
                        .build();
                tapeList.add(hp3);
                VideoTape hp4 = new VideoTape.Builder()
                        .addAgeRestriction(AgeRestriction.GeneralAudiences)
                        .addTitle("The Goblet of Fire")
                        .addDirector("Mike Newell")
                        .addReleaseYear(2005)
                        .addTimeInMinutes(157)
                        .addAvailable(true)
                        .build();
                tapeList.add(hp4);
                VideoTape hp5 = new VideoTape.Builder()
                        .addAgeRestriction(AgeRestriction.GeneralAudiences)
                        .addTitle("The Order of the Phoenix")
                        .addDirector("David Yates")
                        .addReleaseYear(2007)
                        .addTimeInMinutes(138)
                        .addAvailable(true)
                        .build();
                tapeList.add(hp5);
                VideoTape hp6 = new VideoTape.Builder()
                        .addAgeRestriction(AgeRestriction.GeneralAudiences)
                        .addTitle("The Half-Blood Prince")
                        .addDirector("David Yates")
                        .addReleaseYear(2009)
                        .addTimeInMinutes(153)
                        .addAvailable(true)
                        .build();
                tapeList.add(hp6);
                VideoTape hp7 = new VideoTape.Builder()
                        .addAgeRestriction(AgeRestriction.GeneralAudiences)
                        .addTitle("The Deathly Hallows")
                        .addDirector("David Yates")
                        .addReleaseYear(2011)
                        .addTimeInMinutes(130)
                        .addAvailable(true)
                        .build();
                tapeList.add(hp7);
                break;
        }
        return tapeList;
    }
}
