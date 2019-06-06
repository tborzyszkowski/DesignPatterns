package mbreza.user;

import mbreza.videoTape.VideoTape;

import java.util.ArrayList;

public interface User {
    String getName();
    int getRentLimit();
    ArrayList<VideoTape> getRentList();
    void addRentList(VideoTape vt);
    void removeRentList(String title);
    void setRentLimit(int limit);
}
