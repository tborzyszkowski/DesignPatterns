package mbreza.user;

import mbreza.videoTape.VideoTape;

import java.util.ArrayList;
import java.util.Iterator;

public class NormalUser implements User {

    private String name;
    private int rentLimit;
    ArrayList<VideoTape> rentList;

    public NormalUser(String name) {
        this.name = name;
        this.rentLimit = 3;
        this.rentList = new ArrayList<VideoTape>();
    }

    @Override
    public String getName() {
        return this.name;
    }

    @Override
    public int getRentLimit() {
        return this.rentLimit;
    }

    @Override
    public ArrayList<VideoTape> getRentList() {
        return this.rentList;
    }

    @Override
    public void addRentList(VideoTape vt) {
        rentList.add(vt);
    }

    @Override
    public void removeRentList(String title) {
        Iterator i = rentList.iterator();
        VideoTape vt;
        while (i.hasNext()) {
            vt = (VideoTape) i.next();
            if (vt.getTitle().equals(title)) {
                i.remove();
                break;
            }
        }
    }

    @Override
    public void setRentLimit(int limit) {
        this.rentLimit = limit;
    }
}
