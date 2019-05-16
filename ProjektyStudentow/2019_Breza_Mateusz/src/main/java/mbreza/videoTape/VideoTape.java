package mbreza.videoTape;

import mbreza.observer.ChangeStatusObserver;

import java.util.ArrayList;

public class VideoTape {

    private AgeRestriction ageRestriction;
    private String title;
    private String director;
    private int releaseYear;
    private int timeInMinutes;
    private boolean available;
    private ArrayList<ChangeStatusObserver> observers = new ArrayList<>();

    public VideoTape(Builder builder) {
        ageRestriction = builder.ageRestriction;
        title = builder.title;
        director = builder.director;
        releaseYear = builder.releaseYear;
        timeInMinutes = builder.timeInMinutes;
        available = builder.available;
    }

    @Override
    public String toString() {
        return "VideoTape{" +
                "title = " + title +
                ", director = " + director +
                ", releaseYear = " + releaseYear +
                ", timeInMinutes = " + timeInMinutes +
                ", available = " + available +
                '}';
    }
    public void addObserver(ChangeStatusObserver o){
        observers.add(o);
    }

    public void removeObserver(ChangeStatusObserver o){
        observers.remove(o);
    }

    public ArrayList<ChangeStatusObserver> getObservers(){
        return observers;
    }

    public AgeRestriction getAgeRestriction() {
        return ageRestriction;
    }

    public String getTitle() {
        return title;
    }

    public String getDirector() {
        return director;
    }

    public int getReleaseYear() {
        return releaseYear;
    }

    public int getTimeInMinutes() {
        return timeInMinutes;
    }

    public boolean isAvailable() {
        return available;
    }

    public void setAvailable(boolean available) {
        this.available = available;
        execute();
    }

    private void execute() {
        for (ChangeStatusObserver observer : observers) {
            observer.update();
        }
    }

    public static class Builder {
        private AgeRestriction ageRestriction;
        private String title;
        private String director;
        private int releaseYear;
        private int timeInMinutes;
        private boolean available;

        public Builder addAgeRestriction(AgeRestriction ageRestriction) {
            this.ageRestriction = ageRestriction;
            return this;
        }

        public Builder addTitle(String title) {
            this.title = title;
            return this;
        }

        public Builder addDirector(String director) {
            this.director = director;
            return this;
        }

        public Builder addReleaseYear(int releaseYear) {
            this.releaseYear = releaseYear;
            return this;
        }

        public Builder addTimeInMinutes(int timeInMinutes) {
            this.timeInMinutes = timeInMinutes;
            return this;
        }

        public Builder addAvailable(boolean available) {
            this.available = available;
            return this;
        }

        public VideoTape build() {
            return new VideoTape(this);
        }
    }

}
