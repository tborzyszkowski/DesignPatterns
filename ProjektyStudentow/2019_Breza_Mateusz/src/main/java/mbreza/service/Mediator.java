package mbreza.service;

import mbreza.user.User;
import mbreza.videoTape.VideoTape;

import java.util.ArrayList;

public class Mediator {

    private static Mediator instance;
    private boolean slotFull = false;
    private ArrayList<VideoTape> tapeList;

    private Mediator(ArrayList<VideoTape> tapeList) {
        this.tapeList = tapeList;
    }

    public static Mediator getInstance(ArrayList<VideoTape> tapeList) {
        synchronized (Mediator.class) {
            if (instance == null) {
                instance = new Mediator(tapeList);
            }
        }
        return instance;
    }

    public void addList(ArrayList<VideoTape> tapeList){
        this.tapeList.addAll(tapeList);
    }

    public synchronized User serviceVideoTape(User user, String title, ServiceType serviceType) throws InterruptedException {
        while (slotFull == true) {
            wait();
        }
        slotFull = true;
        switch (serviceType) {
            case RENT:
                if (user.getRentLimit() > 0) {
                    for (VideoTape tape : tapeList) {
                        if (tape.getTitle().equals(title) && tape.isAvailable()) {
                            user.addRentList(tape);
                            tape.setAvailable(false);
                            user.setRentLimit(user.getRentLimit() - 1);
                            break;
                        }
                    }

                }
                break;
            case RETURNN:
                for (VideoTape tape : tapeList) {
                    if (tape.getTitle().equals(title) && !tape.isAvailable()) {
                        tape.setAvailable(true);
                        user.removeRentList(title);
                        user.setRentLimit(user.getRentLimit() + 1);
                        break;
                    }
                }
                break;
        }
        slotFull = false;
        return user;
    }

    public ArrayList<VideoTape> getTapeList() {
        return tapeList;
    }
}
