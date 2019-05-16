package mbreza.observer;

import mbreza.videoTape.VideoTape;

public class ChangeStatusObserver implements Observer{

    public ChangeStatusObserver(VideoTape videoTape) {
        videoTape.addObserver(this);
    }

    public void update() {
        System.out.print("Status was changed.");
    }
}
