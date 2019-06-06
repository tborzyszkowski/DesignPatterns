package mbreza.user;

import mbreza.videoTape.VideoTape;

import java.util.ArrayList;

public class PremiumUserDecorator extends UserDecorator {

    private int increaseBy;


    public PremiumUserDecorator(User decoratedUser, int increaseBy) {
        super(decoratedUser);
        this.increaseBy = increaseBy;
    }

    @Override
    public String getName() {
        return decoratedUser.getName();
    }

    @Override
    public int getRentLimit() {
        return decoratedUser.getRentLimit() + increaseBy;
    }

    @Override
    public ArrayList<VideoTape> getRentList() {
        return decoratedUser.getRentList();
    }

    @Override
    public void addRentList(VideoTape vt) {
        decoratedUser.addRentList(vt);
    }

    @Override
    public void removeRentList(String title) {
        decoratedUser.removeRentList(title);
    }

    @Override
    public void setRentLimit(int limit) {
        decoratedUser.setRentLimit(limit - increaseBy);
    }
}
